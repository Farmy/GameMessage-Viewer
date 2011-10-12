using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mooege.Net.GS.Message;
using System.Reflection;
using System.Runtime.Serialization;
using Mooege.Net.GS.Message.Fields;
using Mooege.Net.GS.Message.Definitions.Misc;
using Mooege.Net.GS.Message.Definitions.Skill;

namespace GameMessageViewer
{

    /// <summary>
    /// Proxy to the GameBitBuffer that does not rely on IncomingMessage - Attribute to parse messages
    /// </summary>
    class GameMessageProxy
    {
        static Dictionary<string, Type> MessageTypes = new Dictionary<string,Type>();

        // Load all types in the AppDomain that inherit from GameMessage
        static GameMessageProxy()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (Type type in assembly.GetTypes())
                    if (type.IsSubclassOf(typeof(GameMessage)) || type == typeof(HeroStateData))
                        MessageTypes.Add(type.Name, type);

            // Workarounds of Opcodes not having the same Name as treating class
            MessageTypes["HeroStateData"] = typeof(GenericBlobMessage);
            MessageTypes["AssignSkillMessage1"] = typeof(AssignActiveSkillMessage);
            MessageTypes["AssignSkillMessage2"] = typeof(AssignPassiveSkillMessage);

        }

        public static GameMessage ParseMessage(GameBitBuffer buffer)
        {
            GameMessage message = GameMessage.ParseMessage(buffer);
            if (message == null)
            {
                // If a Message could not be parsed, try finding a Message with the same name as the opcode
                buffer.Position -= 9;
                Opcodes opcode = (Opcodes)buffer.ReadInt(9);

                string name = opcode.ToString();
                if (MessageTypes.ContainsKey(name) == false)
                    for (int i = 0; i < 10; i++)
                        name = name.Replace(i.ToString(), "");

                // Create uninitialized Message (some classes dont have ctor without arguments)
                Type type = MessageTypes[name];
                var msg = FormatterServices.GetUninitializedObject(type);
                (msg as GameMessage).Id = (int)opcode;
                (msg as GameMessage).Parse(buffer);

                return msg as GameMessage;
            }

            return message;
        }
    }

    /// <summary>
    /// Proxys a buffer, so messages created here dont use the Incoming-attribute
    /// </summary>
    class Buffer : GameBitBuffer
    {
        public Buffer(byte[] data) : base(data) { }

        public new GameMessage ParseMessage()
        {
            return GameMessageProxy.ParseMessage(this);
        }

    }
}

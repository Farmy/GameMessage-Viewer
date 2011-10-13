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
        //static Dictionary<string, Type> MessageTypes = new Dictionary<string,Type>();
        private static readonly Dictionary<Opcodes, Type> MessageTypes = new Dictionary<Opcodes, Type>();


        // Load all types in the AppDomain that inherit from GameMessage
        static GameMessageProxy()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (Type type in assembly.GetTypes())
                    if (type.IsSubclassOf(typeof(GameMessage)) || type == typeof(HeroStateData))
                    {
                        var attributes = (MessageAttribute[])type.GetCustomAttributes(typeof(MessageAttribute), true);
                        if (attributes.Length == 0) continue;
                        foreach (MessageAttribute attribute in attributes)
                        {
                            foreach (var opcode in attribute.Opcodes)
                            {
                                MessageTypes.Add(opcode, type);
                            }
                        }

                    }
        }

        public static GameMessage ParseMessage(GameBitBuffer buffer)
        {
            GameMessage msg = null;

            Opcodes opcode = (Opcodes)buffer.ReadInt(9);
            if (MessageTypes.ContainsKey(opcode))
            {
                msg = (GameMessage)FormatterServices.GetUninitializedObject(MessageTypes[opcode]);
                msg.Id = (int)opcode;
                msg.Parse(buffer);
            }

            return msg as GameMessage;
        }
    }

    /// <summary>
    /// Proxys a buffer, so messages created when parsing the buffer dont use the Incoming-attribute
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

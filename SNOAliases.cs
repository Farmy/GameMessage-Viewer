using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameMessageViewer
{
    /// <summary>
    /// Creates a dictionary with names for snos
    /// </summary>
    class SNOAliases
    {
        public static Dictionary<string, string> Aliases;
        public static Dictionary<string, string> AnimationGroups;


        static SNOAliases()
        {
            Aliases = new Dictionary<string, string>();
            AnimationGroups = new Dictionary<string, string>();

            try
            {
                foreach (string filename in new string[] { "snos.txt"})
                    foreach (string entry in File.ReadAllLines(filename))
                        if(Aliases.ContainsKey(entry.Split(' ')[0]) == false)
                            Aliases.Add(entry.Split(' ')[0], entry.Split(' ')[1]);

                foreach (string filename in new string[] { "AnimationGroups.txt" })
                    foreach (string entry in File.ReadAllLines(filename))
                        if (AnimationGroups.ContainsKey(entry.Split(' ')[0]) == false)
                            AnimationGroups.Add(entry.Split(' ')[0], entry.Split(' ')[1]);
            }
            catch (Exception) { Console.WriteLine("Error creating sno list"); }
        }
    }
}

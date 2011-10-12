using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameMessageViewer
{
    class SNOAliases
    {
        public static Dictionary<string, string> Aliases;

        static SNOAliases()
        {
            Aliases = new Dictionary<string, string>();

            try
            {
                foreach (string filename in new string[] { "snos.txt" })
                    foreach (string entry in File.ReadAllLines(filename))
                        if(Aliases.ContainsKey(entry.Split(' ')[0]) == false)
                            Aliases.Add(entry.Split(' ')[0], entry.Split(' ')[1]);
            }
            catch (Exception) { System.Diagnostics.Debugger.Break(); }
        }
    }
}

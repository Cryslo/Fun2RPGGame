using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun2RPGGame
{
    public class RPGMemoryContext : IRPGContext
    {
        private List<string> nameList = new List<string>();

        public RPGMemoryContext()
        {
            nameList.Add("Crashlog");
            nameList.Add("Baz");
            nameList.Add("Dreambough");
            nameList.Add("Xenkai");
            nameList.Add("Zighy");
        }

        public List<string> GetAllCharacters()
        {
            return nameList;
        }

        public string GetCharacter(string name)
        {
            return name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun2RPGGame
{
    public class RPGRepository
    {
        private IRPGContext context;

        public RPGRepository(IRPGContext context)
        {
            this.context = context;
        }

        public List<string> GetAllCharacters()
        {
            return context.GetAllCharacters();
        }

        public string GetCharByName(string name)
        {
            return context.GetCharacter(name);
        }
    }
}

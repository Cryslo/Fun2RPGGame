using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun2RPGGame
{
    public interface IRPGContext
    {

        List<string> GetAllCharacters();

        string GetCharacter(string name);

    }
}

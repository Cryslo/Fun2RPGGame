﻿using System;
using System.Collections.Generic;
using System.Data;
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
        }

        public List<string> GetAllCharacters()
        {
            return nameList;
        }

        public string GetCharacter(string name)
        {
            return name;
        }

        public DataTable Query1(string query)
        {
            throw new NotImplementedException();
        }
    }
}

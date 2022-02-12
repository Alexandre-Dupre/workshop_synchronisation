using System;
using System.Collections.Generic;
using System.Text;

namespace synchronisation
{
    class Tool
    {
        private int _count;
        private readonly string _name;

        public int Count { get => _count; set => _count = value; }

        public string Name => _name;

        public Tool(string name)
        {
            _name = name;
            _count = 0;
        }
    }
}

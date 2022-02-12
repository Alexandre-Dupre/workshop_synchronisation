using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace synchronisation
{
    class Worker
    {
        private string _name;
        private int _count;

        public string Name { get => _name; set => _name = value; }

        public Worker(string name)
        {
            _name = name;
            _count = 0;
        }

        public void DoWork()
        {
            _count += 1;
            Console.WriteLine(_name + " is working... ");
            Thread.Sleep(4000);
        }

        public void NbrOfPiecesCreated()
        {
            Console.WriteLine(_name + " created : " + _count + " pieces from the beginning.");
        }
    }
}

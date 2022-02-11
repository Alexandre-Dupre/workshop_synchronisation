using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace synchronisation
{
    class Worker
    {
        private string _name;
        private bool _hasScrewdriver;
        private int _count;
        bool lockTaken = false;
        public Worker(string name)
        {
            _name = name;
            _hasScrewdriver = false;
            _count = 0;
        }

        public void DoWork()
        {
            Console.WriteLine(_name + "is working... ");
            Thread.Sleep(4000);
        }

        public void CanWork(Tool screwdriver,Tool spanner)
        {
            if (Monitor.TryEnter(screwdriver, 15000) && Monitor.TryEnter(spanner, 15000))
            {
                try
                {
                    this.DoWork();
                }

                finally
                {
                    Monitor.Exit(screwdriver);
                    Monitor.Exit(spanner);
                }
            }
        }
    }
}

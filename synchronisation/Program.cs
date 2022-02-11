using System;
using System.Collections.Generic;
using System.Threading;

namespace synchronisation
{
    class Program
    {
        delegate void Del(Tool, Tool);

        static void Main(string[] args)
        {
            List<Tool> toolList = new List<Tool>();
            Worker workerw1 = new Worker("W1");
            Worker workerw2 = new Worker("W2");
            Worker workerw3 = new Worker("W3");
            Worker workerw4 = new Worker("W4");

            Tool screwdriver1 = new Tool("screwdriver1");
            Tool screwdriver2 = new Tool("screwdriver2");
            Tool spanner1 = new Tool("spanner1");
            Tool spanner2 = new Tool("spanner2");

            toolList.Add(screwdriver1);
            toolList.Add(spanner1);
            toolList.Add(screwdriver2);
            toolList.Add(spanner2);

            ThreadStart threadDelegatew1 = new ThreadStart(workerw1.CanWork);
            ThreadStart threadDelegatew2 = new ThreadStart(workerw2.DoWork);
            ThreadStart threadDelegatew3 = new ThreadStart(workerw3.DoWork);
            ThreadStart threadDelegatew4 = new ThreadStart(workerw4.DoWork);

            Del d1 = workerw1.CanWork;


            Thread w1 = new Thread(d1(toolList[0], toolList[1]));
            Thread w2 = new Thread(threadDelegatew2);
            Thread w3 = new Thread(threadDelegatew3);
            Thread w4 = new Thread(threadDelegatew4);
            
            w1.Start(toolList[0],toolList[1]);
            w2.Start();
            w3.Start();
            w4.Start();
        }
    }
}

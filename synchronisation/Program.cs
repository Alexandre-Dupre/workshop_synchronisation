using System;
using System.Collections.Generic;
using System.Threading;

namespace synchronisation
{
    class Program
    {
        delegate void Del(Tool obj1, Tool obj2, Worker worker);

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

            Del Work = delegate(Tool screwdriver, Tool spanner, Worker worker) 
             {
                 if (Monitor.TryEnter(screwdriver, 15000) && Monitor.TryEnter(spanner, 15000))
                 {
                     try
                     {
                         worker.DoWork();
                     }

                     finally
                     {
                         Monitor.Exit(screwdriver);
                         Monitor.Exit(spanner);
                     }
                 }
             };

            Thread w1 = new Thread(() => Work(toolList[0],toolList[1],workerw1));
            Thread w2 = new Thread(() => Work(toolList[2], toolList[3], workerw2));
            Thread w3 = new Thread(() => Work(toolList[0], toolList[1], workerw3));
            Thread w4 = new Thread(() => Work(toolList[2], toolList[3], workerw4));

            while (true)
            {
                w1.Start();
                w2.Start();
                w3.Start();
                w4.Start();
            }
            
            
        }
    }
}

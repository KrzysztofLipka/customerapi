using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace customerapi.Data
{
    class CpuStress
    {
        public static void CPUKill(object cpuUsage)
        {
            Parallel.For(0, 1, new Action<int>((int i) =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (true)
                {
                    if (watch.ElapsedMilliseconds > (int)cpuUsage)
                    {
                        Thread.Sleep(100 - (int)cpuUsage);
                        watch.Reset();
                        watch.Start();
                    }
                }
            }));

        }

        public static void GenerateStress()
        {
            int cpuUsage = 70;
            int time = 20000;
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(CPUKill));
                t.Start(cpuUsage);
                threads.Add(t);
            }
            Thread.Sleep(time);

            try
            {
                foreach (var t in threads)
                {
                    t.Interrupt();
                }
            }
            catch
            {

            }

        }
    }
}
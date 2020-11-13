using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] Nodes = { 50, 50, 50, 50, 100, 50, 50, 50, 50, 100 };
            double[] Loads = { 0.6, 0.8, 0.9, 0.95, 1.5, 0.6, 0.8, 1.30, 0.6, 0.78 };
            int Threshold = 1;
            string OffloadMessage = "Needs to be offloaded.";
            string Notoffloading = "No need of offloading.";
            string SecondarylinkMessage = "Offloading To Secondary link.";
            string PrimarylinkMessage = "Sending Through Primary Link.";
            string SentMessage = "Sent To the Core Network.";

            Console.WriteLine("Calculating LOAD");
             bool checkLoad(double Load)
             {
                if(Load>Threshold)
                {
                    Console.Write("Load is More.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Load is Less.");
                    return false;
                }
             }

             bool checkCoreNode(int LoadNode)
             {
                int position = LoadNode +1;
                if(Nodes[position]==100)
                {
                    //Console.WriteLine("ETa core na");
                    return true;
                }
                else
                {
                    return false;
                }
             }

            double AddLoad(int LoadIndex)
            {
                double currentLoad = Loads[LoadIndex];
                double nextHopLoad = Loads[LoadIndex + 1];
                double TotalLoad = currentLoad + nextHopLoad;
                //Console.WriteLine(TotalLoad);
                //int TotalLoad;
                return TotalLoad;
            }

            for (int i = 0; i < Loads.Length; i++)
            {
                bool loadresult = checkLoad(Loads[i]);
                bool CoreStatus = checkCoreNode(i);

                if (!loadresult)
                {
                    if(CoreStatus)
                    {
                        Console.Write(Notoffloading);
                        Console.WriteLine(SentMessage);
                        break;
                    }
                    else
                    {
                        double addLoad = AddLoad(i);
                        Console.WriteLine("Eita Core na Bhai");
                        Console.WriteLine(addLoad);  
                    }
                    
                }
                else
                {
                    
                }
                i++;
                //break;
            }
        }
    }
}

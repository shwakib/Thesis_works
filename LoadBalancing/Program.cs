using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancing
{
    class Program
    {
        static void Main(string[] args)
        {
            bool CoreStatus;
            bool loadresult;
            double addLoad = -1.0;
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
                if (Load > Threshold)
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
                int position = LoadNode + 1;
                if (Nodes[position] == 100)
                {
                    //Console.WriteLine("ETa core na");
                    return true;
                }
                else
                {
                    return false;
                }
            }

            double AddLoad(int LoadIndex, double previousLoad)
            {
                double currentLoad = previousLoad;
                double nextHopLoad = Loads[LoadIndex + 1];
                double TotalLoad = currentLoad + nextHopLoad;
                //Console.WriteLine(TotalLoad);
                //int TotalLoad;
                return TotalLoad;
            }

            for (int i = 0; i < Loads.Length; i++)
            {
                
                if (addLoad < 0)
                {
                    Console.WriteLine("The Initial load is: {0}", Loads[i]);
                    //Console.WriteLine(Loads[i]);
                    loadresult = Loads[i] > Threshold ? true : false;
                    //Console.WriteLine(loadresult);
                    // Console.WriteLine("Load is less");
                    if (!loadresult)
                    {
                        CoreStatus = checkCoreNode(i);
                        if (!CoreStatus)
                        {
                            Console.WriteLine("Next Hop is not Core");
                            addLoad = AddLoad(i, Loads[i]);
                            Console.WriteLine("The total Load with previous node is {0}", addLoad);
                        }
                        else
                        {
                            Console.WriteLine(Notoffloading);
                            Console.WriteLine(SentMessage);
                        }
                    }
                    
                    else
                    {
                        Console.WriteLine(OffloadMessage);
                        double Ds = Loads[i] - Threshold;
                        double Dl = Loads[i] - Ds;
                        Console.WriteLine("Data to be sent through Satellite Link: {0}", Ds);
                        Console.WriteLine("Data to be sent through Main Link: {0}", Dl);
                        Console.WriteLine(SecondarylinkMessage);
                        Console.WriteLine(SentMessage);
                        //Console.WriteLine(i);
                        CoreStatus = checkCoreNode(i);
                        //Console.WriteLine(CoreStatus);
                        if (!CoreStatus)
                        {
                            Console.WriteLine("Next Hop is not Core");
                            addLoad = AddLoad(i, Loads[i]);
                            Console.WriteLine("Total Load is {0}", addLoad);
                        }
                        else
                        {
                            Console.WriteLine("Next Hop Is Core.");
                            Console.WriteLine(Notoffloading);
                            Console.WriteLine(SentMessage);
                            break;
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("Done");
                    loadresult = addLoad > Threshold ? true : false;
                    // Console.WriteLine(loadresult);
                    double Ds = addLoad - Threshold;
                    double Dl = addLoad - Ds;
                    Console.WriteLine("Data to be sent through satellite: {0}", Ds);
                    Console.WriteLine("Data to be sent through Main Link: {0}", Dl);
                    Console.WriteLine(SecondarylinkMessage);
                    Console.WriteLine(SentMessage);
                    //Console.WriteLine(i);
                    CoreStatus = checkCoreNode(i);
                    //Console.WriteLine(CoreStatus);
                    if (!CoreStatus)
                    {
                        Console.WriteLine("Next Hop is not Core");
                        addLoad = AddLoad(i, Dl);
                        Console.WriteLine("The total Load is: {0} ", addLoad);
                    }
                    else
                    {
                        Console.WriteLine("Next Hop Is Core.");
                        Console.WriteLine(Notoffloading);
                        Console.WriteLine(PrimarylinkMessage);
                        Console.WriteLine(SentMessage);
                        break;
                    }
                }
            }

        }
    }
}

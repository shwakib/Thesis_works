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
            int NodesPosition = 0;
            int[] Nodes = { 50, 50, 50, 50, 100, 50, 50, 50, 50, 100 };
            double[] Loads = { 0.6, 0.8, 0.9, 0.95, 1.5, 0.6, 0.8, 1.30, 0.6, 0.78 };
            /*double Dla = 0.6;
            double Dlb = 0.8;
            double Dlc = 0.9;
            double Dld = 0.95;
            double Dle = 1.5;
            double Dlf = 0.6;
            double Dlg = 0.8;
            double Dlh = 1.30;
            double Dli = 0.6;
            double Dlj = 0.78;*/
            int Threshold = 1;
            string OffloadMessage = "Needs to be offloaded.";
            string Notoffloading = "No need of offloading.";
            string SecondarylinkMessage = "Offloading To Secondary link.";
            string PrimarylinkMessage = "Sending Through Primary Link.";
            string SentMessage = "Sent To the Core Network.";

            Console.WriteLine("Calculating LOAD");
            /*if (Dle>Threshold)
            {
                Console.WriteLine(OffloadMessage);
            }
            else
            {
                Console.WriteLine(Notoffloading);
            }*/
            //int position = -1;
            for (int i = 0; i < Loads.Length; i++)
            {
                if (Loads[i] > Threshold)
                {
                    //position = i;
                    Console.WriteLine(OffloadMessage);
                    double Ds = Loads[i] - Threshold;
                    Console.WriteLine(Ds);
                    double LeftLoads = Loads[i] - Ds;
                    Console.WriteLine(LeftLoads);
                    Console.WriteLine(SecondarylinkMessage);
                    Console.WriteLine(SentMessage);
                    /*for(double j=Loads[i];j<Nodes.Length;j++)
                    {
                        Console.WriteLine(j);
                    }*/
                    int position = i;
                    NodesPosition = position;
                    if(Nodes[NodesPosition]==100)
                    {
                        Console.WriteLine("The Next Hop is core network");
                        Console.WriteLine(PrimarylinkMessage);
                        Console.WriteLine(SentMessage);
                    }
                    else
                    {
                        int NextIndex = i + 1;
                        Console.WriteLine(NextIndex);
                        double AddLoad = Loads[i] + Loads[NextIndex];
                        Console.WriteLine(AddLoad);
                    }
                    break;

                }
                else
                {
                    Console.Write(Notoffloading);
                    Console.Write(PrimarylinkMessage);
                    Console.WriteLine(SentMessage);
                }
            }
        }
    }
}

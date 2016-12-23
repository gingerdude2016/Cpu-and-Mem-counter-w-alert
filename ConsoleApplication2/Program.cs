using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {


            SpeechSynthesizer voice = new SpeechSynthesizer();
            voice.Speak("Welcome to CPU and Memory counter version 1 point O,");


            #region Preformcounters
            PerformanceCounter cpucount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            PerformanceCounter memcount = new PerformanceCounter("Memory", "Available Mbytes");

            #endregion
            while (true)
            {


                float currentcpu = cpucount.NextValue();
                float currentmem = memcount.NextValue();


                Console.WriteLine("CPU load      :{0}%", (int)currentcpu);
                Console.WriteLine("Memory        :{0}Mb", (int)currentmem);

                //you can edit the if statements to match with the specs of you computer
                if (currentmem < 900)
                {
                    if (currentmem < 300)
                    {
                        string mem = string.Format("Alert Current memory is {0} megabytes", (int)currentmem);
                        voice.Speak(mem);

                    }
                    else
                    {
                        string mem = String.Format("Warning the current memory is {0} megabytes", (int)currentmem);
                        voice.Speak(mem);
                    }
                }
                if (currentcpu > 60)
                {
                    if (currentcpu == 100)
                    {
                        string cpu = string.Format("Alert Cpu work load at {0} %", (int)currentcpu);
                        voice.Speak(cpu);
                    }
                    else
                    {
                        string cpu = string.Format("Warning Cpu work load at {0} %", (int)currentcpu);
                        voice.Speak(cpu);

                    }












                }
                Thread.Sleep(1000);
            }








        }
    }
}

  


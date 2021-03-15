using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessesKillUtil

{
    class Program
    {

    	static private string processName;
    	static private int timeWork;
    	static private int checkFrequency;

        static void Main(string[] args)
        {
        	processName = args[0];
            // Check arguments
        	bool resultWork = int.TryParse(args[1], out timeWork);
        	if (resultWork != true)
        	{
        		Console.WriteLine("To start enter main.exe processname timework checkfrecuency");
        		Environment.Exit(0);
        	}

        	bool resultFrequensy = int.TryParse(args[2], out checkFrequency);
        	if (resultFrequensy != true)
        	{
        		Console.WriteLine("To start enter main.exe processname timework checkfrecuency");
        		Environment.Exit(0);
        	}

        	Timer timer = new Timer(checkedTime, null, 0, checkFrequency*60000);

            Console.WriteLine("Scanning!");

            Console.ReadLine();
        }
        // timer method
        static void checkedTime (Object obj) 
        {
        	// Console.WriteLine("Now date and time: {0} ", DateTime.Now.ToString());
        	ProcessKill (processName, timeWork);
        }
        // close method
        static void ProcessKill (string name, int time)
        {
        	foreach (var process in Process.GetProcessesByName(name))
        	{
        		if ((DateTime.Now - process.StartTime).TotalMilliseconds > time*60000)
        		{
        			process.Kill();
        		}
        		Console.WriteLine("Process successfull killed!");
        	}
        }
    }
}

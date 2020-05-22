using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab3
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatingSystem operatingSystem = new OperatingSystem(16, 4);
            for (int processId = 0; processId < 3; processId++)
            {
                operatingSystem.addProcess();
                for (int pageId = 0; pageId < operatingSystem.getProcess(processId).countPages; pageId++)
                {
                    operatingSystem.addPage(processId);
                }
                operatingSystem.printMemory();
            }
            operatingSystem.printMemory();
            Console.ReadKey();

        }
    }
}


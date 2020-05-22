using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab3
{
    public class OperatingSystem
    {
        private MemoryManagment MM;
        private List<Process> processes;
        private static List<Page> pages;

        public OperatingSystem(int memorySize, int pageSize)
        {
            MM = new MemoryManagment(memorySize, pageSize);
            processes = new List<Process>();
            pages = new List<Page>();
        }

        public void addProcess()
        {
            Process process = new Process(processes.Count, 3);
            processes.Add(process);
            Console.WriteLine("Создание нового процесса " + process.id + " необходимо " + process.countPages + " страниц");
        }

        public Process getProcess(int processId)
        {
            return processes[processId];
        }

        public void addPage(int processId)
        {
            Process process = getProcess(processId);
            
            int pageId = MM.addPage(process);
            getPage(processId, pageId);
            Console.WriteLine("Создание страницы " + pageId + " для процесса " + process.id);
        }

        public void getPage(int processId, int pageId)
        {
            Process process = getProcess(processId);

            if (process.pagesIds.Contains(pageId))
            {
                MM.getPage(pageId);
                Console.WriteLine("Процесс " + process.id + " запрашивание страницы " + pageId);
            }
            else
            {
                Console.WriteLine("У процесса " + process.id + " нет страницы " + pageId);
            }
        }

        public void printMemory()
        {
            Console.WriteLine("Operating memory:\n  Page   Process   Recourse  ");
            for (int pageId = 0; pageId < MM.memory.getPagesCount(); pageId++)
            {
                Page page = MM.memory.getPage(pageId);
                if (page == null)
                {
                    Console.WriteLine(" |    " + pageId);
                }
                else
                {
                    Process process = getProcess(page.processId);
                    Console.WriteLine(" |    " + pageId + " |    " + process.id + " |    " + page.recourse.ToString());
                }
            }
        }

        public static Page returnPage(int pageId)
        {
            return pages[pageId];
        }
    }
}

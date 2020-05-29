using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab3
{
    public class MemoryManagment
    {
        private Process process;
        private List<Page> clock;
        public Memory memory;

        public MemoryManagment(int memorySize, int pageSize)
        {
            memory = new Memory(memorySize, pageSize);
            process = new Process(5, 15);
            clock = new List<Page>();
        }

        public int addPage(Process process)
        {
            int pageId = this.process.addPage(new Page(process.id));
            process.pagesIds.Add(pageId);
            return pageId;
        }

        public Page getPage(int pageId)
        {
            Page page = process.getPage(pageId);
            if (page.presence)
            {
                page.recourse = true;
            }
            else
            {
                int emptyPageId = memory.getEmptyPageId();
                if (emptyPageId != -1)
                {
                    memory.setPage(emptyPageId, page);
                    page.recourse = true;
                    page.presence = true;
                    page.physicalAddress = emptyPageId;
                    clock.Add(page);
                }
                else
                {
                    while (true)
                    {
                        Page replacePage = clock[0];
                        clock.RemoveAt(clock.Count - 1);
                        if (replacePage.recourse)
                        {
                            replacePage.recourse = false;
                            clock.Add(replacePage);
                        }
                        else
                        {
                            if (replacePage.virtualAddress != -1)
                            {
                                memory.setPage(replacePage.virtualAddress,
                                      OperatingSystem.returnPage(replacePage.virtualAddress));
                            }
                            else
                            {
                                memory.setPage(replacePage.physicalAddress, page);
                            }
                            page.recourse = true;
                            page.presence = true;
                            page.physicalAddress = replacePage.physicalAddress;
                            clock.Add(page);
                            replacePage.presence = false;
                            replacePage.virtualAddress = process.addPage(replacePage);
                            replacePage.physicalAddress = -1;
                            break;
                        }
                    }
                }
            }
            return page;
        }
    }
}

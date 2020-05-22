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
        private Queue<Page> pageQueue;
        public Memory memory;

        public MemoryManagment(int memorySize, int pageSize)
        {
            memory = new Memory(memorySize, pageSize);
            process = new Process(5, 15);
            pageQueue = new Queue<Page>();
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
                    pageQueue.Enqueue(page);
                }
                else
                {
                    while (true)
                    {
                        Page replacePage = pageQueue.Peek();
                        pageQueue.Dequeue();
                        if (replacePage.recourse)
                        {
                            replacePage.recourse = false;
                            pageQueue.Enqueue(replacePage);
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
                            pageQueue.Enqueue(page);
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

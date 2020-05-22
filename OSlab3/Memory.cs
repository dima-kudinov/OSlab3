using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab3
{
    public class Memory
    {
        private Page[] pages;

        public Memory(int memorySize, int pageSize)
        {
            pages = new Page[memorySize / pageSize];
        }

        public int getPagesCount()
        {
            return pages.Length;
        }

        public Page getPage(int pageId)
        {
            return pages[pageId];
        }

        public void setPage(int pageId, Page page)
        {
            pages[pageId] = page;
        }

        public int getEmptyPageId()
        {
            for (int index = 0; index <  pages.Length; index++)
            {
                if (pages[index] == null)
                {
                    return index;
                }
            }
            return -1;
        }
    }
}

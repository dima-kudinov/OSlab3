using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab3
{
    public class Process
    {
        public int id { get; private set; }
        public int countPages { get; private set; }
        public List<int> pagesIds { get; private set; }
        private List<Page> pages;

        public Process(int id, int countPages)
        {
            this.id = id;
            this.countPages = countPages;
            pages = new List<Page>();
            pagesIds = new List<int>();
        }

        public Page getPage(int pageId)
        {
            return pages[pageId];
        }

        public int addPage(Page page)
        {
            pages.Add(page);
            return pages.IndexOf(page);
        }
    }
}

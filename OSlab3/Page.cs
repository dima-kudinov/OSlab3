using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab3
{
    public class Page
    {
        public int processId { get; private set; }
        public int physicalAddress { get; set; }
        public int virtualAddress { get; set; }
        public bool recourse { get; set; }
        public bool presence { get; set; }

        public Page(int processId)
        {
            this.processId = processId;
            this.physicalAddress = -1;
            this.virtualAddress = -1;
            this.recourse = false;
            this.presence = false;
        }
    }
}

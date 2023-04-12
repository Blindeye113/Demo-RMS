using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    public class StatusEnum
    {
        public enum Status 
        { 
            Unassigned = 0,
            Allocated = 1,
            Resolved = 2
        }
    }
}

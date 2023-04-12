using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    public class TicketReasonEnum
    {
        public enum TicketReason
        {            
            Battery_Fault = 0,
            Battery_Critical = 1,
            Poor_Connection = 2,
            Other = 3,
        }
    }
}

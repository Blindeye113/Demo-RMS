using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanidateApp.Shared
{
    public abstract class TicketAsignment 
    {
        public int Id { get; set; }
        public Ticket TicketId { get; set; }
        public Guid ContractorID { get; set; }
        public string Contractor { get; set; }
     
    }
}

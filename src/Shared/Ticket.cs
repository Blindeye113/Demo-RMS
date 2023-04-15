using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CanidateApp.Shared.StatusEnum;
using static CanidateApp.Shared.TicketReasonEnum;

namespace CanidateApp.Shared
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketReason Reason { get; set; }
        public Status Status { get; set; } = Status.Unassigned;
        public Guid SiteId { get; set; }
        public string? Details { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateCompleted { get; set; } = null;
    }
}

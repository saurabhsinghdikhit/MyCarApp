using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class Feedback
    {
        public System.Guid FeedbackId { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public string Description { get; set; }

        public virtual FeedbackCategory FeedbackCategory { get; set; }
    }
}

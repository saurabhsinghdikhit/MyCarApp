using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class FeedbackCategory
    {
        public FeedbackCategory()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }

        public System.Guid Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

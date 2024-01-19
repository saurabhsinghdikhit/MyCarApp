using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class RatingVM
    {
        public Guid ReviewId { get; set; }
        public Guid CarId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}

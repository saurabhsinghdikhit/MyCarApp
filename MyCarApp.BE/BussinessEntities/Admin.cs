using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class Employee : UserBase
    {
        public int FacultyId { get; set; } //forginkey
        public Faculty Faculty { get; set; }//navigation
    }
}

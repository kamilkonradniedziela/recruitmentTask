using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Models
{
    public class Contractor
    {
        public int id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string city { get; set;}

        public string departmentName { get; set; }

        public string dateOfBirth { get; set; }
    }
}

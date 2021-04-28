using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServer.Entities
{
    public class Employee
    {
        public string ID { get; set; }

        public string CompanyID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public  GenderType Gender { get; set; }
    }
}

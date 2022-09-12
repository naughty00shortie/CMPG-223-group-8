using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcadia_Hotel_DB
{
    public class EmployeeModel
    {
        public int Employee_ID { get; set; }
        public int Role_ID { get; set; }
        public string Employee_Surname { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Employee_Date_Of_Birth { get; set; }
        public string Employee_Email { get; set; }

    }
}

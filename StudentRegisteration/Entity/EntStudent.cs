using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EntStudent
    {
        public int RegisterationID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set;}

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        public string Gender { get; set; }

        public string CurrentAddress { get; set; }
        public DateTime DOB { get; set; }

        public string PermanentAddress { get; set; }

        public int FatherCNIC { get; set; }

        public string FatherPhoneNumber { get; set; }
        public string MotherPhoneNumber { get; set; }
        public int MotherCNIC { get; set; }

        public int Age { get; set; }

        public int Siblings { get; set; }

            
    }
}

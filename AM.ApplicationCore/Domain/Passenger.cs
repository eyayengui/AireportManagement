using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public String  EmailAdress { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PassportNumber { get; set; }
        public String TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "FirstName=" + this.FirstName + "LastName=" + this.LastName;
        }
        //public bool CheckProfile(String FirstName, String LastName)
        //{
        //    return this.FirstName == FirstName && this.LastName==LastName;
        //}
        //public bool CheckProfile(String FirstName, String LastName, String Email)
        //{
        //    return this.FirstName == FirstName && this.LastName == LastName && this.EmailAdress==Email;
        //}
        public bool CheckProfile(String FirstName, String LastName, String Email=null)
        {
            if (EmailAdress == null) {
                return this.FirstName == FirstName && this.LastName == LastName;
                    }
            else
            {
                return this.FirstName == FirstName && this.LastName == LastName && this.EmailAdress == Email;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I'am a passenger");
        }
    }
}

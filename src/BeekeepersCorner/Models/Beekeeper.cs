using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeekeepersCorner.Models
{
    
    public class Beekeeper
    {

        public Beekeeper()
        {
            Beehives = new List<Beehive>();
        }

        public int BeekeeperID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Beehive> Beehives { get; set; }
    }
}

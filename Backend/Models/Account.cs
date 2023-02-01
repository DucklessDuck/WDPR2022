using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Account : IdentityUser
    {
        public virtual ICollection<Kaart> Tickets { get; set; }
        public double DonatieCounter { 
            get{
                return DonatieCounter;
            }
            set{
                DonatieCounter = 0;
            }
        }
    }
}
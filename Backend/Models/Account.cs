using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Account : IdentityUser
    {
        public virtual ICollection<Kaart> tickets { get; set; }


        // protected Account()
        // {
            
        // }
        // public Account(string GN, string EA, string WW)
        // {
        //     this.Gebruikersnaam = GN;
        //     this.EmailAddres = EA;
        //     this.Wachtwoord = WW;

        // }
    }
}
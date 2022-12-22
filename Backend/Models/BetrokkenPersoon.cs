using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BetrokkenPersoon
    {
        [Key]
        public int PersoonId{get; set;}
        public string Zaalnaam{get; set;}
        public string Functie{get; set;}
        public DateTime Geboortedatum{get; set;}
        public string Foto{get; set;}

        public BetrokkenPersoon CrewLid{get; set;}

        public List<Voorstelling> Voorstellingen{get; set;}
    }
}
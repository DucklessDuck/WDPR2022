using System.ComponentModel.DataAnnotations;

namespace Models
{

    public class Kaart
    {
        [Key]
        public string KaartId{get; set;}
        public Account Bezoeker{get; set;}
        public DateTime Geboortedatum{get; set;}
        public Double Prijs{get; set;}

        public int VoorstellingId{get; set;}
        public int StoelNummer{get; set;}
        public Voorstelling voorstelling{get; set;}
    }
}
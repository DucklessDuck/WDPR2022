using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Voorstelling
    {
        public int VoorstellingId{get; set;}
        public string NaamVoorstelling{get; set;}
        public DateTime VoorstellingsDatum{get; set;}
        public string Beschrijving {get; set; }
        public int ZaalID {get; set;}
        
        [NotMapped]
        public FileModel file {get; set;}
        // public List<BetrokkenPersoon> Crew {get; set;}

        // public List<Kaart> Tickets{get; set;}
    }
}

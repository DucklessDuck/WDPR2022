namespace Models
{
    public class Voorstelling
    {
        public string NaamVoorstelling{get; set;}
        public DateTime VoorstellingsDatum{get; set;}

        public int VoorstellingId{get; set;}


        public List<BetrokkenPersoon> Crew {get; set;}
        public List<Kaart> Tickets{get; set;}

    }
}

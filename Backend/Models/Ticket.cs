namespace Models{

    public class Ticket
    {
        public long Id {get; set;}
        public string UserId {get; set;}
        public Account Account {get; set;}
        public int VoorstellingId {get; set;}
        public int ZaalId {get; set;}
        public DateTime VoorstellingDatum{get; set;}
    }

}
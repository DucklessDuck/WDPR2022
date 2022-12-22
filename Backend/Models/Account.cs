namespace Models
{
    public class Account
    {
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Role { get; set; }
        public int AccountId { get; set; }
        public List<Kaart> TicketLijst{get; set;}

    }
}
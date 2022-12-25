using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Zaal
    {
        [Key]
        public string Zaalnaam{get; set;}
        public List<Stoel> Stoelen{get; set;}
    }
}
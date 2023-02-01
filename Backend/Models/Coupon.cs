namespace Models
{
    public class Coupon
    {
        public int Code
        {
            get
            {
                return Code;
            }
            set
            {
                Random rnd = new Random();
                Code = rnd.Next();
            }
        }

        public enum Status
        {
            Redeemable,
            Redeemed,
            Expired
        }

        public DateTime ExpireDate{ get; set; }

    }
}

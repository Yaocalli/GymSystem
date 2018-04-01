namespace Maintenance.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}

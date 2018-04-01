namespace Maintenance.Domain
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Cellphone { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}

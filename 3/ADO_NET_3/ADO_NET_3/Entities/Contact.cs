namespace geiko.ADO_NET_3.Entities
{
    public class Contact
    {
        public int Id{ get; set; }
        public string Address { get; set; }    
        public string Phone { get; set; }

        public Contact ()
        {
            this.Id = -1;
            this.Address = "unknown";
            this.Phone = "unknown";
        }
    }
}

namespace geiko.ADO_NET_3.Servis
{
    public class UserDTO
    {            
        public int Id { get; set; }
        public int ContactId { get; set; }

        public string Login { get; set; }
        public int Password { get; set; }
        public bool IsAdmin { get; set; }     
        public string Address   { get; set; }
        public string Phone { get; set; }
    }
}

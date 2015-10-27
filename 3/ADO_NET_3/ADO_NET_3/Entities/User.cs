namespace geiko.ADO_NET_3.Entities
{
    public class User
    {
        public Contact Contact { get; set; }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Login { get; set; }
        public int Password  { get; set; }
        public bool IsAdmin { get; set; }


        public User ()
        {
            this.Id = -1;
            this.ContactId = -1;
            this.Login = "unknown";
            this.Password = 0;
            this.IsAdmin = false;
        }
    }
}

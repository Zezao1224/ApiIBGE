namespace ApiIBGE.Models
{
    public class Users
    {
        public Users() { }
        public Users(int id, string email, string password)
        {
            this.id = id;
            Email = email;
            Password = password;
        }

        public int id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

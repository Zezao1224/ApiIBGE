namespace ApiIBGE.Models
{
    public class Users
    {
        public Users() { }
        public Users(int id, string email, string senha)
        {
            this.id = id;
            Email = email;
            Senha = senha;
        }

        public int id { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}

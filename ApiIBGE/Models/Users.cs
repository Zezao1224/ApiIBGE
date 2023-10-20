namespace ApiIBGE.Models
{
    /// <summary>
    /// Classe Users
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Construtor vazio da classe Users
        /// </summary>
        public Users() { }

        /// <summary>
        /// Construtor da classe Users com as propriedades da classe Users
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Users(int id, string email, string password)
        {
            this.id = id;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Propriedade id da classe Users
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Propriedade Email da classe Users
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Propriedade Password da classe Users
        /// </summary>
        public string? Password { get; set; }
    }
}

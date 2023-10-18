namespace ApiIBGE.Models
{
    public class ibge
    {
        public ibge() { }
        public ibge(int id, string? state, string? city)
        {
            this.id = id;
            this.state = state;
            this.city = city;
        }

        public int id { get; set; }
        public string state { get; set; }
        public string city { get; set; }

    }
}

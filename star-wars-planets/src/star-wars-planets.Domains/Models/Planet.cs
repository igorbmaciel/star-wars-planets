namespace star_wars_planets.Domain.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weather { get; set; }
        public string Ground { get; set; }
        public int MovieQuantity { get; set; }
    }
}

namespace CelebritiesApi.Models
{
    public class Celebrity
    {
        public int Id { get; set; } // Kişinin Benzersiz Kimliği
        public string Name { get; set; } = ""; // Kişinin Adı
        public string Profession { get; set; } = ""; // Kişinin Mesleği
    }
}

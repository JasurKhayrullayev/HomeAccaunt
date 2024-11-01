namespace Home.Models
{
    public class EntertainmentsModel
    {
        public int Id { get; set; }
        public string enname { get; set; } = null!;
        public string encategory { get; set; } = null!;
        public string enplace { get; set; } = null!;
        public string enprice { get; set; } = null!;
        public string encomment { get; set; } = null!;
        public DateOnly endate { get; set; }
    }
}

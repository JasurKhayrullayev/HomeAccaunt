namespace Home.Models
{
    public class MobilesModel
    {
        public int Id { get; set; }
        public int mobnumber { get; set; }
        public string mobname { get; set; } = null!;
        public string mobcategory { get; set; } = null!;
        public string mobprice { get; set; } = null!;
        public string mobcomment { get; set; } = null!;
        public DateOnly mobdate { get; set; }
    }
}

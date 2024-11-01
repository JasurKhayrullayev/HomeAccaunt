namespace Home.Models
{
    public class TransportsModel
    {
        public int Id { get; set; }
        public string trname { get; set; } = null!;
        public string trcategory { get; set; } = null!;
        public string trprice { get; set; } = null!;
        public string trcomment { get; set; } = null!;
        public DateOnly trdate { get; set; }
    }
}

namespace Home.Models
{
    public class InternetsModel
    {
        public int Id { get; set; }
        public int inpcodenum { get; set; }
        public string inname { get; set; } = null!;
        public string incategory { get; set; } = null!;
        public string inprice { get; set; } = null!;
        public string incomment { get; set; } = null!;
        public DateOnly indate { get; set; }
    }
}

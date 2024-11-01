using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
namespace Home.Models
{
    public class FoodsModel
    {
        public int Id { get; set; }
        public string foodName { get; set; } = null!;
        public string foodCategory { get; set; } = null!;
        public string foodprice { get; set; } = null!;
        public string foodcomment { get; set; } = null!;
        public DateOnly fooddate { get; set; } 
    }
}
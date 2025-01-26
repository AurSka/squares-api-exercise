using System.ComponentModel.DataAnnotations;

namespace SquarePointsAS.Entities
{
    public class SquarePoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
    }
}

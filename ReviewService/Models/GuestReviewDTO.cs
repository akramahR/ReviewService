using System.ComponentModel.DataAnnotations;

namespace ReviewService.Models
{
    public class GuestReviewDTO
    {
        public int GuestId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(500)]
        public string ReviewText { get; set; }
    }
}

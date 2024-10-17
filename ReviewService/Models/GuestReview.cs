using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReviewService.Models
{
    public class GuestReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate the Review Id
        public int ReviewId { get; set; } // Auto-incrementing Id

        public int GuestId { get; set; } // The ID of the guest providing the review

        [Range(1, 5)]
        public int Rating { get; set; } // Rating (1-5 stars)

        [Required]
        [MaxLength(500)]
        public string ReviewText { get; set; } // The actual review text

        public DateTime ReviewDate { get; set; } // The date the review was submitted
    }
}

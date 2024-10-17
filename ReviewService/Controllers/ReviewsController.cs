using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestReview>>> GetGuestReviews()
        {
            return await _context.GuestReviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestReview>> GetGuestReview(int id)
        {
            var review = await _context.GuestReviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<GuestReview>> PostGuestReview(GuestReviewDTO reviewDto)
        {
            var guestReview = new GuestReview
            {
                GuestId = reviewDto.GuestId,
                Rating = reviewDto.Rating,
                ReviewText = reviewDto.ReviewText,
                ReviewDate = DateTime.Now // Automatically set the review date
            };

            _context.GuestReviews.Add(guestReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuestReview), new { id = guestReview.ReviewId }, guestReview);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestReview(int id, GuestReviewDTO reviewDto)
        {
            var existingReview = await _context.GuestReviews.FindAsync(id);
            if (existingReview == null)
            {
                return NotFound();
            }

            // Update review
            existingReview.Rating = reviewDto.Rating;
            existingReview.ReviewText = reviewDto.ReviewText;

            _context.Entry(existingReview).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(existingReview); // Return the updated review
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestReview(int id)
        {
            var guestReview = await _context.GuestReviews.FindAsync(id);
            if (guestReview == null)
            {
                return NotFound();
            }

            _context.GuestReviews.Remove(guestReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

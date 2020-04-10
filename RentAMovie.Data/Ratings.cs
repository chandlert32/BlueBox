using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAMovie.Data
{
    public abstract class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        [Range(1,10)]
        public int Score { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        /*[ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }*/



    }

    public class MovieRating : Rating
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }

    public class GameRating : Rating
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}

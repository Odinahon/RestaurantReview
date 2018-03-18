using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public abstract class BaseEntity{}
    public class RReview: BaseEntity
    {
        [Key]
        public int ReviewId {get;set;}
        [Required]
        public string Reviewer{get;set;}
        [Required]
        public string RestaurantName{get;set;}
        [Required]
        [MinLength(10)]
        public string newReview{ get;set;}
        [Required]
        public int Stars{get; set;}
        [Required]

        [CheckFuture]
        public DateTime CreatedAt{get; set;}
    }
}
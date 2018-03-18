using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;
 
    public HomeController(RestaurantContext context)
    {
        _context = context;
    }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }
        [HttpPost]
        [Route("addreview")]
        public IActionResult AddReviewToDB( string reviewer, string restaurant, string review, int stars, DateTime date){
            RReview nr= new RReview(){
                Reviewer = reviewer,
                RestaurantName = restaurant,
                newReview = review,
                Stars= stars,
                CreatedAt =date
            };
            TryValidateModel(nr);
            if(ModelState.IsValid){
            _context.RestaurantReview.Add(nr);
            _context.SaveChanges();
                return RedirectToAction("success");
            }
            else{
                ViewBag.errors=ModelState.Values;
                return View("Index");
            }
            
        }



    [HttpGet]
    [Route("success")]
    public IActionResult Success(){
        List<RReview> AllReviews = _context.RestaurantReview.OrderByDescending(rr => rr.CreatedAt).ToList();
        ViewBag.reviews= AllReviews;
        return View();
    }
    //    public IActionResult Error()
    //     {
    //         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //     }

        
    }
}

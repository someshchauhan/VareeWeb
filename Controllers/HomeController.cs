using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VareeWeb.Models;

namespace VareeWeb.Controllers
{
    public class HomeController : Controller
    {

        VareeStroreEntities db = new VareeStroreEntities();
        
        public ActionResult Index()
        {
            var data = db.ProductDetails.ToList();
            return View(data);
        }

        public ActionResult ProductDetails(int id)
        {
            var data = db.ProductDetails.FirstOrDefault(p => p.ProductID == id);
            return View(data);
        }

        public ActionResult SearchProducts(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Content(""); 
            }

            var results = db.ProductDetails
                .Where(p => p.ProductName.Contains(query))
                .ToList();

            if (results.Any())
            {
                string resultHtml = string.Join("", results.Select(p =>
                    $"<div class='search-result-item'><div class='search-result-item-top'><img src='{p.ImageURL}' /></div> <div class='search-result-item-bottom'><h6>{p.ProductName}</h6><span>Current Price: &#8377; {p.Price}</span><span class='btn btn-danger p-1'>MRP: <s>&#8377; {p.MRP}</s></span><span id='displayDiscount'>{p.DiscountPercentage}% Discount</span></div></div>"
                ));

                return Content(resultHtml);  
            } 
            else
            {
                return Content("<p>No products found</p>");
            }
        }

        [Authorize]
        public ActionResult WishList()
        {
            string uName = Session["userName"]?.ToString();
            var userData = db.Users.FirstOrDefault(x => x.UserName == uName);

            if (userData != null)
            {
                var wishlistProductIds = db.Wishlists
                                           .Where(w => w.UserId == userData.Id)
                                           .Select(w => w.ProductId)
                                           .ToList(); 

                var productDetails = db.ProductDetails
                                       .Where(p => wishlistProductIds.Contains(p.ProductID))
                                       .ToList();

                return View(productDetails);
            }

            TempData["Msg"] = "User not found. Please try logging in again.";
            return RedirectToAction("Index", "Login");
        }




        [Authorize]
        [HttpPost]
        public ActionResult AddToWishlist(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string uName = Session["userName"]?.ToString();
                var userData = db.Users.FirstOrDefault(x => x.UserName == uName);

                if (userData != null)
                {
                    var existingWishlistItem = db.Wishlists
                                                  .FirstOrDefault(w => w.UserId == userData.Id && w.ProductId == productId);

                    if (existingWishlistItem != null)
                    {
                        db.Wishlists.Remove(existingWishlistItem);
                        db.SaveChanges();

                        TempData["Msg"] = "Product removed from your Wishlist"; 
                    }
                    else
                    {
                        var wl = new Wishlist()
                        {
                            ProductId = productId,
                            UserId = userData.Id
                        };

                        db.Wishlists.Add(wl);
                        db.SaveChanges();

                        TempData["Msg"] = "Product added to your Wishlist"; 
                    }

                    return Redirect(Request.UrlReferrer?.ToString() ?? "/");
                }
                else
                {
                    TempData["Msg"] = "User not found. Please try logging in again.";
                    return RedirectToAction("Index", "Login");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string uName = Session["userName"]?.ToString();
                var userData = db.Users.FirstOrDefault(x => x.UserName == uName);

                if (userData != null)
                {
                    var existingCartItem = db.Carts
                                                  .FirstOrDefault(w => w.UserId == userData.Id && w.ProductId == productId);

                    if (existingCartItem != null)
                    {
                        db.Carts.Remove(existingCartItem);
                        db.SaveChanges();

                        TempData["Msg"] = "Product removed from your Cart";
                    }
                    else
                    {
                        var wl = new Cart()
                        {
                            ProductId = productId,
                            UserId = userData.Id
                        };

                        db.Carts.Add(wl);
                        db.SaveChanges();

                        TempData["Msg"] = "Product added to your Cart";
                    }

                    return Redirect(Request.UrlReferrer?.ToString() ?? "/");
                }
                else
                {
                    TempData["Msg"] = "User not found. Please try logging in again.";
                    return RedirectToAction("Index", "Login");
                }
            }

            return RedirectToAction("Index", "Home");
        }



        [Authorize]
        public ActionResult Cart()
        {
            string uName = Session["userName"]?.ToString();
            var userData = db.Users.FirstOrDefault(x => x.UserName == uName);

            if (userData != null)
            {
                var CartProductIds = db.Carts
                                           .Where(w => w.UserId == userData.Id)
                                           .Select(w => w.ProductId)
                                           .ToList();

                var productDetails = db.ProductDetails
                                       .Where(p => CartProductIds.Contains(p.ProductID))
                                       .ToList();

                return View(productDetails);
            }

            TempData["Msg"] = "User not found. Please try logging in again.";
            return RedirectToAction("Index", "Login");
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            TempData["Msg"] = "Log Out Successful";
            return RedirectToAction("Index", "Home");
        }







    }
}
using Microsoft.AspNetCore.Mvc;
using DBFirstEFinApp.Models;

namespace DBFirstEFinApp.Controllers
{
    public class NorthWindController : Controller
    {
        public IActionResult SpainCustomers()
        {
            NorthWindContext cnt = new NorthWindContext();
            var spaincustomer = cnt.Customers.Where(x => x.Country == "Spain").
                Select(x=> new SpainCustomerViewModel
                {
                    Cid = x.CustomerId,
                    Cname = x.ContactName,
                    Comname = x.CompanyName
                }).ToList();
            return View(spaincustomer);
        }

        public IActionResult searchCustomer(string contactname)
        {
            NorthWindContext cnt = new NorthWindContext();
            var searchcustomer = from customer in cnt.Customers
                                 where customer.ContactName == contactname
                                 select new Customer
                                 {
                                     ContactName = customer.ContactName,
                                     ContactTitle = customer.ContactTitle,
                                     CompanyName = customer.CompanyName
                                 };
            var searchcustomer2 = cnt.Customers.Where(x=>x.ContactName==contactname)
                .Select(x=>new Customer { 
                    ContactName = x.ContactName,
                    ContactTitle = x.ContactTitle,
                    CompanyName = x.CompanyName
                });
            var query1 = searchcustomer.Single();
            var query2 = searchcustomer2.Single();
            return View(query1); //query2 can also be used
        }

        public ActionResult ProductsInCategory(string categoryName)
        {
            NorthWindContext cnt = new NorthWindContext ();
            var prodsinCategory = cnt.Products.
                Where(x=>x.Category.CategoryName == categoryName).
                Select(x=>new ProdCat
                {
                    prodname=x.ProductName,
                    catname = x.Category.CategoryName
                }).ToList();
            return View(prodsinCategory);
        }
        public ActionResult OrderRange(string range)
        {
            NorthWindContext cnt = new NorthWindContext ();
            var range1 = Convert.ToInt16 (range);
            var custOrderCount = cnt.Customers
                .Where(x => x.Orders.Count > range1)
                .Select(x => new Customer
                {
                    CustomerId = x.CustomerId,
                    ContactName = x.ContactName
                });
            return View(custOrderCount);
        }

        public IActionResult CustomerOrderDetails(string id)
        {
            NorthWindContext cnt = new NorthWindContext();

            var orders = cnt.Orders
                .Where(o => o.CustomerId == id)
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate
                }).ToList();

            ViewBag.CustomerId = id;

            return View(orders);
        }
    }
}

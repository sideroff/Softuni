using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_TODO_List.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> items = (List<string>) this.Session["items"] ?? new List<string>();
            return View(items);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddItem(string newItem)
        {
            List<string> items = (List<string>)this.Session["items"] ?? new List<string>();
            items.Add(newItem);
            this.Session["items"] = items;

            return this.RedirectToAction("index");
        }

        public ActionResult RemoveItem(int index)
        {
            List<string> items = (List<string>)this.Session["items"];

            if (items != null && index < items.Count)
            {
                items.RemoveAt(index);
                this.Session["items"] = items;
            }
            return this.RedirectToAction("Index");
            int a = 5;
        }
        
    }
}
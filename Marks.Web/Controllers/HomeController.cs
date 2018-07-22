using Marks.Core.Models;
using Marks.Core.PagingSorting;
using Marks.Web.Services;
using Marks.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marks.Web.Controllers
{
    public class HomeController : Controller
    {
        

        /// <summary>
        /// Gets paged and sorted people with marks, and renders view.
        /// </summary>
        /// <param name="input">Paging and sorting input</param>
        /// <returns>View with sorted and paged list</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Just returns Create view.
        /// </summary>
        /// <returns>Create view</returns>
        public IActionResult Create()
        {
            return View();
        }


    }
}
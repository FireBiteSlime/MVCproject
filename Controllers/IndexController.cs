using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class IndexController : Controller
    {

        public ViewResult Show()
        {
            return View();
        }
    }
}
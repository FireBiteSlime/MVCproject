using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab3.Interfaces;

namespace lab3.Controllers
{
    public class LabController : Controller
    {

        private INumberSystemComputation _calculatorManager;
        public LabController(INumberSystemComputation calculatorManager)
        {
            _calculatorManager = calculatorManager;
        }
        public IActionResult Show()
        {
            Random rnd = new Random();
            string[] model = new string[1];
            for(int i = 0; i < 15; i++)
            {
                model[0] += Convert.ToString(rnd.Next(-10, 20));
                if (i != 14) model[0] += " ";
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Sum(string numstring)
        {
            string[] model = new string[2];
            model[0] = numstring;

            try
            {

                string[] numarray = numstring.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double[] numbers = new double[numarray.Length];
                for (int i = 0; i < numarray.Length; i++) {
                    numbers[i] = Convert.ToDouble(numarray[i]);
                }

                model[1] = Convert.ToString(this._calculatorManager.EvenSum(numbers));
            }
            catch (ArgumentException e) when (e.ParamName == "numbers")
            {
                model[1] = e.Message;
            }
            catch (FormatException)
            {
                model[1] = "Неправильно введено какое-то число.";
            }
            catch (Exception)
            {
                model[1] = "Неправильно введено выражение.";
            }

            return View("Show", model);
        }
    }
}
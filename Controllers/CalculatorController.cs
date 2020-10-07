using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Classes;
using lab3.Interfaces;
using lab3.Manager;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class CalculatorController : Controller
    {
        private INumberSystemComputation _calculatorManager;
        public CalculatorController(INumberSystemComputation calculatorManager)
        {
            _calculatorManager = calculatorManager;
        }
        public IActionResult Computation()
        {
            string[] empty = new string[1];
            empty[0] = "10";
            return View(empty);
        }

        [HttpPost]
        public ActionResult Calculate(string operations, string base_num)
        {
            String[] model = new String[5];
            model[0] = base_num;

            try
            {
                operations = operations.Replace(" ", String.Empty);
                String result = "";
                String[] stringSeparators = new string[] { "+", "-", "*", "/", "%", "^", "root", "log", "xor", "concat" };
                String[] numbers = operations.Split(stringSeparators, StringSplitOptions.None);

                String operation = operations.Remove(0, numbers[0].Length);
                operation = operation.Replace(numbers[1], String.Empty);

                int basenum = Int32.Parse(base_num);
                double[] temp_numbers = new double[2];

                temp_numbers[0] = basenum == 10 ? Convert.ToDouble(numbers[0]) : BaseConvertation.ArbitraryToDecimalSystem(numbers[0].ToUpper(), basenum);
                temp_numbers[1] = basenum == 10 ? Convert.ToDouble(numbers[1]) : BaseConvertation.ArbitraryToDecimalSystem(numbers[1].ToUpper(), basenum);
                double temp_result = 0;

                switch (operation)
                {
                    case "+":
                        temp_result = this._calculatorManager.Sum(temp_numbers[0], temp_numbers[1]);
                        break;
                    case "-":
                        temp_result = this._calculatorManager.Sub(temp_numbers[0], temp_numbers[1]);
                        break;
                    case "*":
                        temp_result = this._calculatorManager.Mul(temp_numbers[0], temp_numbers[1]);
                        break;
                    case "/":
                        temp_result = this._calculatorManager.Div(temp_numbers[0], temp_numbers[1]);
                        break;
                    case "%":
                        temp_result = this._calculatorManager.Mod(temp_numbers[0], temp_numbers[1]);
                        break;
                    case "^":
                        temp_result = this._calculatorManager.Exp(temp_numbers[0], temp_numbers[1]);
                        break;
                    case "root":
                        temp_result = this._calculatorManager.Root(temp_numbers[1], temp_numbers[0]);
                        break;
                    case "log":
                        temp_result = this._calculatorManager.Log(temp_numbers[1], temp_numbers[0]);
                        break;
                    case "xor":
                        temp_result = this._calculatorManager.Xor(Convert.ToInt32(temp_numbers[0]), Convert.ToInt32(temp_numbers[1]));
                        break;
                    case "concat":
                        temp_result = Convert.ToDouble(Convert.ToString(temp_numbers[0]) + Convert.ToString(temp_numbers[1]));
                        break;
                }

                model[1] = numbers[0];
                model[2] = operation.ToLower();
                model[3] = numbers[1];
                model[4] = basenum == 10 ? Convert.ToString(temp_result) : BaseConvertation.DecimalToArbitrarySystem(Convert.ToInt64(temp_result), basenum);

            }
            catch (DivideByZeroException)
            {
                model[1] = "error";
                model[2] = "Деление на ноль.";
            }
            catch (ArgumentException e) when (e.ParamName == "number")
            {
                model[1] = "error";
                model[2] = "Неправильно введено число в данной системе счисления.";
            }
            catch(FormatException)
            {
                model[1] = "error";
                model[2] = "Неправильно введено число в данной системе счисления.";
            }
            catch (Exception e)
            {
                model[1] = "error";
                //model[2] = e.ToString();
                model[2] = "Неправильно введено выражение. См. пример.";
            }

            return View("Computation", model);
        }
    }
}
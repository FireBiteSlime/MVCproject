using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Interfaces;
using lab3.Classes;

namespace lab3.Manager
{
    //работает на основе десятеричной системы счисления
    public class CalculatorManager : INumberSystemComputation
    {
        public CalculatorManager() { }

        public double Sum(double first, double second)
        {
            return first + second;
        }
        public double Sub(double first, double second)
        {
            return first - second;
        }
        public double Mul(double first, double second) 
        {
            return first * second;
        }
        public double Div(double first, double second)
        {
            if (second == 0) throw new DivideByZeroException();
            return first / second;
        }
        public double Mod(double first, double second)
        {
            if (second == 0) throw new DivideByZeroException();
            return first % second;
        }
        public double Exp(double number, double exponent)
        {
            return Math.Pow(number, exponent);
        }
        public double Root(double number, double base_num)
        {
            if (base_num == 0) throw new DivideByZeroException();
            return Math.Pow(number, 1 / base_num);
        }
        public double Log(double number, double base_num)
        {
            return Math.Log(number, base_num);
        }

        public long Xor(long first, long second)
        {
            return first ^ second;
        }

        public double EvenSum(double[] numbers)
        {
            double sum = 0;
            bool is_even_exists = false;

            if(numbers.Length < 15) 
                throw new ArgumentException(
                    "Должно быть минимум 15 элементов.",
                    "numbers");

            foreach (double num in numbers)
            {
                if (num % 2 == 0)
                {
                    sum += num;
                    is_even_exists = true;
                }
            }
            if (!is_even_exists) 
                throw new ArgumentException(
                    "Не найдено четных чисел.",
                    "numbers");

            return sum;
        }
    }
}

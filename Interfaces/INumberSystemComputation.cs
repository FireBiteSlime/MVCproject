using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.Interfaces
{
    public interface INumberSystemComputation
    {
        double Sum(double first, double second); // Сумма
        double Sub(double first, double second); // Разность
        double Mul(double first, double second); // Умножение
        double Div(double first, double second); // Деление
        double Mod(double first, double second); // Остаток от деления
        double Exp(double number, double exponent); // Возведение в степень
        double Root(double number, double base_num); // Корень
        double Log(double number, double base_num); // Логарифм
        long Xor(long first, long second); // XOR
        double EvenSum(double[] numbers); // сумма четных чисел в массиве
    }
}

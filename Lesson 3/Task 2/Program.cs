using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Володин Артем
//
//2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
//Требуется подсчитать сумму всех нечетных положительных чисел. 
//    Сами числа и сумму вывести на экран, используя tryParse;
//   б) Добавить обработку исключительных ситуаций на то, что могут 
//    быть введены некорректные данные.При возникновении ошибки 
//    вывести сообщение.Напишите соответствующую функцию;

namespace Task_2
{
    class Program
    {

        static void Main(string[] args)
        {
            double summ = 0;
            do
            {
                Console.Write("\nВведите число: ");
                if(double.TryParse(Console.ReadLine(), out double number))
                {
                    if (number > 0)
                    {
                        if ((number % 2) == 1)
                        {
                            summ = summ + number;
                        }
                    } else if (number == 0)
                    {
                        Console.WriteLine("Ввод окончен");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Введено некорректное число.");
                }
                       

            } while (true);
            Console.WriteLine("\nСумма нечетных положительных чисел равна: " + summ);
            Console.ReadLine();
        }
    }
}

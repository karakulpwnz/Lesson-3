using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Володин Артем

//3. * Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
// Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать
// программу, демонстрирующую все разработанные элементы класса.
//** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
// ArgumentException("Знаменатель не может быть равен 0");
//** Добавить упрощение дробей.

namespace Task_3
{
    class Fraction
    {
        public int top; //Задаем числитель
        public int bot; //Задаем знаменатель

        public Fraction Plus(Fraction y)
        {
            Fraction result = new Fraction();
            result.top = this.top * y.bot + y.top * this.bot;
            result.bot = this.bot * y.bot;
            result = result.Collapse(result);
            return result;
        }

        public Fraction Minus(Fraction y)
        {
            Fraction result = new Fraction();
            result.top = this.top * y.bot - y.top * this.bot;
            result.bot = this.bot * y.bot;
            result = result.Collapse(result);
            return result;
        }

        public Fraction Multi(Fraction y)
        {
            Fraction result = new Fraction();
            result.top = this.top * y.top;
            result.bot = this.bot * y.bot;
            result = result.Collapse(result);
            return result;
        }

        public Fraction Div(Fraction y)
        {
            Fraction result = new Fraction();
            result.top = this.top * y.bot;
            result.bot = this.bot * y.top;
            result = result.Collapse(result);
            return result;
        }

        public Fraction Collapse(Fraction x)//метод сокращения дробей
        {
            int min = 0;
            bool divflag = false;

            do
            {
                min = x.top;//находим наименьшее число из числителя и знгаменателя
                if (x.top > x.bot)
                {
                    min = x.bot;
                }

                divflag = false;

                for (int i = 2; i <= min; i++)
                {
                    if (x.top % i == 0)
                    {
                        if (x.bot % i == 0)//если остаток от деления числителя и знаменателя на i ноль - перезаписываем числитель и знаменатель
                        {
                            x.top = x.top / i;
                            x.bot = x.bot / i;
                            i = min + 1;
                            divflag = true;//если хоть одно сокрашение за цикл успешно - запускаем цикл снова
                        }
                    }
                }
            } while (divflag == true);//если за цикл ни одного сокращения не было - завершаем метод сокращения
            return x;
        }

        public string ToString()
        {
            return top + "/" + bot;
        }
    }

    class Program
    {
        static bool CheckBot(int bot)
        {
            try
            {
                if (bot == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;//ложь, если ноль
            }
            return true;//правда, если не ноль
        }

        static int Bot()//ввод знаменателя
        {
            do
            {
                Console.WriteLine("\nВведите знаменатель: ");
                if (Int32.TryParse(Console.ReadLine(), out int bot))//проверям, является ли числом вводимые данные
                {
                    if (CheckBot(bot) == true)//если tryparse отработал, проверяем, является ли число нулем
                    {
                        return bot;//если не ноль - выходим из цикла. если ноль - идем вводить опять число.
                    }
                }
                else
                {
                    Console.WriteLine("Введены некорректные данные. Введите число.");
                }
            } while (true);
        }

        static int Top()//ввод числителя
        {
            do
            {
                Console.WriteLine("\nВведите числитель: ");
                if (Int32.TryParse(Console.ReadLine(), out int top))//проверям, является ли числом вводимые данные
                {
                    return top;
                }
                else
                {
                    Console.WriteLine("Введены некорректные данные. Введите число.");
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите первую дробь. ");
            Fraction x1 = new Fraction();
            x1.top = Top();
            x1.bot = Bot();
            Console.Clear();
            x1 = x1.Collapse(x1);
            Console.WriteLine("Первая дробь: " + x1.ToString());

            Console.Write("Введите вторую дробь. ");
            Fraction x2 = new Fraction();
            x2.top = Top();
            x2.bot = Bot();
            Console.Clear();
            x2 = x2.Collapse(x2);
            Console.WriteLine("Первая дробь: " + x1.ToString());
            Console.WriteLine("Вторая дробь: " + x2.ToString());

            Fraction result = x1.Plus(x2);
            Console.WriteLine("Сумма: " + result.ToString());
            result = x1.Minus(x2);
            Console.WriteLine("Разность: " + result.ToString());
            result = x1.Multi(x2);
            Console.WriteLine("Произведение: " + result.ToString());
            result = x1.Div(x2);
            Console.WriteLine("Деление: " + result.ToString());



            Console.ReadLine();
        }
    }
}

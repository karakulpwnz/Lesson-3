using System;

//Володин Артем
//
//1. б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;

class Complex
{
    // Все методы и поля публичные. Мы можем получить доступ к ним из другого класса.
    public double im;
    public double re;
    public Complex Plus(Complex x2)
    {
        Complex result = new Complex();
        result.im = x2.im + this.im;
        result.re = x2.re + this.re;
        return result;
    }
    public Complex Minus(Complex x2)
    {
        Complex result = new Complex();
        result.im = this.im - x2.im;
        result.re = this.re - x2.re;
        return result;
    }
    public Complex Multi(Complex x2)
    {
        Complex result = new Complex();
        result.re = this.re * x2.re - this.im * x2.im;
        result.im = this.re * x2.im + this.im * x2.re;
        return result;
    }

    public string ToString()
    {
        //Условие для того, чтобы не выводился лишний минус при отрицательном im
        if (im >= 0)
        {
            return re + "+" + im + "i";
        }
        else
        {
            return re + "" + im + "i";
        }
        // return re + "+" + im + "i";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Complex complex1 = new Complex();
        complex1.re = 1;
        complex1.im = 1;
        Console.WriteLine("Первое число: " + complex1.ToString());
        Complex complex2 = new Complex();
        complex2.re = 2;
        complex2.im = 2;
        Console.WriteLine("Первое число: " + complex2.ToString());
        Complex result = complex1.Plus(complex2);
        Console.WriteLine("Сумма чисел: " + result.ToString());
        result = complex1.Minus(complex2);
        Console.WriteLine("Разность чисел: " + result.ToString());
        result = complex1.Multi(complex2);
        Console.WriteLine("Произведение чисел: " + result.ToString());
        Console.ReadLine();
    }
}
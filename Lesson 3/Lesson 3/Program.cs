using System;

//Володин Артем
//
//1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;

struct Complex
{
    public double im;
    public double re;
    // в C# в структурах могут храниться также действия над данными
    public Complex Plus(Complex x)
    {
        Complex result;
        result.im = im + x.im;
        result.re = re + x.re;
        return result;
    }
    //Метод вычитания комплексных чисел
    public Complex Minus(Complex x)
    {
        Complex result;
        result.im = im - x.im;
        result.re = re - x.re;
        return result;
    }
    // Пример произведения двух комплексных чисел
    public Complex Multi(Complex x)
    {
        Complex result;
        result.im = re * x.im + im * x.re;
        result.re = re * x.re - im * x.im;
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
    }
}
class Program
{
    static void Main(string[] args)
    {
        Complex complex1;
        complex1.re = 1;
        complex1.im = 1;
        Console.WriteLine("Первое число: " + complex1.ToString());
        Complex complex2;
        complex2.re = 2;
        complex2.im = 2;
        Console.WriteLine("Второе число: " + complex2.ToString());
        Complex result = complex1.Plus(complex2);        Console.WriteLine("Сумма чисел: " + result.ToString());
        result = complex1.Minus(complex2);
        Console.WriteLine("Разность чисел: " + result.ToString());
        result = complex1.Multi(complex2);
        Console.WriteLine("Произведение чисел: " + result.ToString());
        Console.ReadLine();
    }
}
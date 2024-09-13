using System;

namespace ConsoleApp5
{       
    class Program    //класс используемый для вызова методов
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите радиус круга: ");
                int r = int.Parse(Console.ReadLine());
                Circle circle = new Circle(r);    //создание объекта круг с введенным с клавиатуры радиусом
                Console.WriteLine();
                circle.Show();
                Console.WriteLine();

                Cone cone = new Cone();    //создание объекта конус со случайным значением радиуса и высоты
                cone.Show();
                Console.WriteLine();

                Console.Write("Введите новый радиус конуса: ");
                cone.Radius = int.Parse(Console.ReadLine());   //замена значения поля радиус для конуса
                Console.WriteLine();
                cone.Show();
                Console.WriteLine();

                Cylinder cylinder = new Cylinder();    //создание объекта цилиндр со случайным значением радиуса и высоты
                cylinder.Show();
            }
            catch
            {
                Console.WriteLine("\nВведены неверные данные. Работа завершена");    //вывод исключения, если введены любые данные, кроме положительного числа
            }
            Console.ReadLine();
        }
    }
}
using System;

namespace ConsoleApp5
{
    class Circle    //базовый класс Круг
    {
        protected int radius;    //поле доступно в дочерних классах
        protected static Random rnd = new Random();
        protected static string name = "Круг";
        public Circle()    //конструктор с заданием случайного значения
        {
            radius = rnd.Next(1, 11);
        }

        public Circle(int radius)    //конструктор с заданием введенного значения
        {
            if (radius <= 0) throw new Exception();    //проверка для введенного значения
            this.radius = radius;
        }

        public int Radius    //свойства для получения и задания значения поля радиус
        {
            get
            {
                return radius;
            }
            set
            {
                if (value <= 0) throw new Exception();    //проверка для введенного значения
                radius = value;
            }
        }
                    
        public virtual void Show()    //виртуальный метод выводит на экран информацию о круге, вызывая метод Площадь
        {
            Console.WriteLine(name+":");
            Console.WriteLine("Радиус = {0}\tПлощадь = {1}", radius, Area());
        }

        public virtual double Area()    //виртуальный метод для подсчета площади
        {
            return Math.Round(Math.PI * radius * radius, 2);
        }
    }
}
using System;

namespace ConsoleApp5
{
    class Cone : Circle    //дочерний класс Конус
    {
        protected int height;

        public Cone() : base()    //наследованный конструктор с заданием случайного значения
        {
            height = rnd.Next(1, 11);
            name = "Конус";
        }

        public Cone(int radius, int height) : base(radius)    //наследованный конструктор с заданием введенного значения
        {
            if (height <= 0) throw new Exception();    //проверка для введенного значения
            this.height = height;
            name = "Конус";
        }

        public override void Show()    //наследованный метод выводит на экран информацию о конусе, вызывая метод Объем
        {
            base.Show();
            Console.WriteLine("Высота = {0}\tОбъем = {1}", height, Volume());
        }

        public override double Area()    //наследованный метод для подсчета площади переписан для конуса
        {
            return Math.Round(Math.PI * radius * (radius + Math.Sqrt(radius * radius + height * height)), 2);
        }

        public double Volume()    //просто метод для подсчета объема
        {
            return Math.Round((Math.PI * radius * radius * height) / 3.000, 2);
        }
    }
}
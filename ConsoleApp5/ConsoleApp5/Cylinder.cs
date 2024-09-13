using System;

namespace ConsoleApp5
{
    class Cylinder : Circle    //дочерний класс Цилиндр
    {
        protected int height;

        public Cylinder() : base()    //наследованный конструктор с заданием случайного значения
        {
            height = rnd.Next(1, 11);
            name = "Цилиндр";
        }
        
        public Cylinder(int radius, int height) : base(radius)    //наследованный конструктор с заданием введенного значения
        {
            if (height <= 0) throw new Exception();    //проверка для введенного значения
            this.height = height;
            name = "Цилиндр";
        }

        public override void Show()    //наследованный метод выводит на экран информацию о цилиндре, вызывая метод Объем
        {
            base.Show();
            Console.WriteLine("Высота = {0}\tОбъем = {1}", height, Volume());
        }

        public override double Area()    //наследованный метод для подсчета площади переписан для цилиндра
        {
            return Math.Round(2 * Math.PI * radius * (radius + height), 2);
        }

        public double Volume()    //просто метод для подсчета объема
        {
            return Math.Round(Math.PI * radius * radius * height, 2);
        }
    }
}
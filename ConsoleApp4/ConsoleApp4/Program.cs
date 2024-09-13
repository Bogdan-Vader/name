using System;
using System.Collections.Generic;

namespace Структуры_и_коллекции
{
    class Program
    {
        enum Package //перечисляемый тип виды упаковок
        {
            пакет = 1,
            коробка,
            бутылка,
            другое
        }

        struct Note //структура с записями о продуктах
        {
            public string name;
            public int price;
            public DateTime implement_by; //реализовать до
            public Package package;
        }

        static List<Note> Products = new List<Note>(); //список структур

        static void AddProduct(int n) //добавление записей в изначальный список
        {
            for (int i = 0; i < n; i++)
            {
                Note Product = new Note()
                {
                    name = "Name" + (i + 1),
                    price = 1000 * (i + 1),
                    implement_by = DateTime.Today.AddDays(i * i + 2),
                    package = (Package)i + 1
                };
                Products.Add(Product);
            }
            Console.WriteLine("Список из 4 элементов создан");
        }

        static void AddProduct() //добавление записей с клавиатуры
        {
            Note Product = new Note();
            try
            {
                Console.Write("Введите уникальное название продукта: ");
                Product.name = Console.ReadLine();
                if (Product.name == "" || Products.Exists(i => i.name == Product.name))
                    throw new Exception(); //если название пустое или повторяющееся

                Console.Write("Введите цену в рублях: ");
                Product.price = Convert.ToInt32(Console.ReadLine());
                if (Product.price <= 0)
                    throw new Exception();

                Console.Write("Введите срок реализации (дд.мм.гггг): ");
                Product.implement_by = Convert.ToDateTime(Console.ReadLine());
                if (Product.implement_by < DateTime.Today)
                {
                    Console.Write("Продукт не должен быть просрочен. ");
                    throw new Exception();
                }
                Console.Write("Виды упаковки:\n  1 - пакет\n  2 - коробка\n  3 - бутылка\n  4 - другое\nВведите номер вида упаковки: ");
                Product.package = (Package)Convert.ToInt32(Console.ReadLine());
                if (!Enum.IsDefined(typeof(Package), Product.package))
                    throw new Exception(); //если нет такого номера вида упаковки

                Products.Add(Product);
                Console.WriteLine("Продукт добавлен");
            }
            catch
            { Console.WriteLine("Введены неверные данные"); }
        }

        static void ShowList() //вывод всего списка
        {
            if (Products.Count == 0)
                Console.WriteLine("Список пуст");
            else
                for (int i = 0; i < Products.Count; i++)
                    Show(i);
        }

        static void Show(int n) //вывод записи
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\tНомер " + (n + 1) + " по списку");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\tНазвание: " + Products[n].name);
            Console.WriteLine("\tЦена: " + Products[n].price + " руб.");
            Console.WriteLine("\tРеализовать до: " + Products[n].implement_by.ToShortDateString());
            Console.WriteLine("\tВид упаковки: " + Products[n].package);
        }

        static void DeleteProduct() //удаление записи
        {
            Console.Write("Введите номер (по списку) продукта, который нужно удалить: ");
            try
            {
                Products.Remove(Products[int.Parse(Console.ReadLine()) - 1]);
                Console.WriteLine("Продукт удален");
            }
            catch
            { Console.WriteLine("Введен несуществующий номер"); }
        }

        static void Edit() //редактирование поля записи
        {
            bool not_found = true;
            Console.Write("Введите название продукта: ");
            string item = Console.ReadLine();
            Console.Write("Введите категорию данных для коррекции (1 - название, 2 - цена, 3 - срок реализации, 4 - номер вида упаковки): ");
            string category = Console.ReadLine();
            Console.Write("Введите данные на замену: ");
            string replacement = Console.ReadLine();
            try
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].name == item) //поиск записи с введенным названием
                    {
                        Note Product = new Note() //сохранение информации из записи в новый объект
                        {
                            name = Products[i].name,
                            price = Products[i].price,
                            implement_by = Products[i].implement_by,
                            package = Products[i].package
                        };

                        switch (category)
                        {
                            case "1":
                                if (Products.Exists(n => n.name == replacement) || replacement == "")
                                    throw new Exception(); //если название пустое или повторяющееся
                                Product.name = replacement;
                                Console.WriteLine("Данные заменены");
                                break;
                            case "2":
                                if (int.Parse(replacement) <= 0)
                                    throw new Exception();
                                Product.price = Convert.ToInt32(replacement);
                                Console.WriteLine("Данные заменены");
                                break;
                            case "3":
                                if (Product.implement_by < DateTime.Today)
                                {
                                    Console.Write("Продукт не должен быть просрочен. ");
                                    throw new Exception();
                                }
                                Product.implement_by = Convert.ToDateTime(replacement);
                                Console.WriteLine("Данные заменены");
                                break;
                            case "4":
                                Product.package = (Package)Convert.ToInt32(replacement);
                                if (!Enum.IsDefined(typeof(Package), Product.package))
                                    throw new Exception(); //если нет вида упаковки с таким номером
                                Console.WriteLine("Данные заменены");
                                break;
                            default:
                                Console.WriteLine("Введен неверный номер");
                                break;
                        }
                        Products[i] = Product; //установка нового объекта на место
                        not_found = false;
                    }
                }
                if (not_found) throw new Exception();
            }
            catch
            { Console.WriteLine("Введены неверные данные"); }
        }

        static void Search() //поиск записи по полю
        {
            try
            {
                int found = 0;

                Console.Write("Введите категорию поиска: 1 - название, 2 - цена, 3 - срок реализации, 4 - название вида упаковки: ");
                int category = int.Parse(Console.ReadLine());

                Console.Write("Введите запрос: ");
                string query = Console.ReadLine();

                Console.WriteLine("Результат: ");
                switch (category)
                {
                    case 1:
                        for (int i = 0; i < Products.Count; i++)
                            if (Products[i].name == query)
                            { Show(i); found++; }
                        break;
                    case 2:
                        for (int i = 0; i < Products.Count; i++)
                            if (Products[i].price == int.Parse(query))
                            { Show(i); found++; }
                        break;
                    case 3:
                        for (int i = 0; i < Products.Count; i++)
                            if (Products[i].implement_by == Convert.ToDateTime(query))
                            { Show(i); found++; }
                        break;
                    case 4:
                        for (int i = 0; i < Products.Count; i++)
                            if (Convert.ToString(Products[i].package) == query)
                            { Show(i); found++; }
                        break;
                    default: Console.Write("Введена неверная категория. "); break;
                }
                if (found == 0)
                    Console.WriteLine("По вашему запросу ничего не найдено");
            }
            catch
            { Console.WriteLine("Введены неверные данные"); }
        }

        static void FindExpensive() //вывод записей с наибольшей ценой
        {
            int max = 0;
            Console.WriteLine("Продукты с наибольшей ценой:");

            for (int i = 0; i < Products.Count; i++) //нахождение наибольшей цены
                if (max < Products[i].price)
                    max = Products[i].price;

            for (int i = 0; i < Products.Count; i++)
                if (Products[i].price == max)
                    Show(i); //вывод всех записей с такой ценой

            if (max == 0)
                Console.WriteLine("\nСписок пуст");
        }

        static void FindExpiring() //вывод продуктов с истекающим сроком реализации
        {
            try
            {
                Console.WriteLine("Будет выведен список продуктов, срок реализации которых истекает меньше, чем через введенное количество дней"); 
                Console.Write("Введите количество дней: ");
                int days = int.Parse(Console.ReadLine()), showed = 0;

                for (int i = 0; i < Products.Count; i++)
                    if (Products[i].implement_by < DateTime.Today.AddDays(days))
                    { Show(i); showed++; }
                if (showed == 0) Console.WriteLine("Таких продуктов нет");
            }
            catch
            { Console.WriteLine("Вводимые данные должны быть положительным числом"); }
        }

        static void Main(string[] args)
        {
            string function = "0";
            AddProduct(4);
            while (function != "")
            {
                Console.Write("\nСписок функций: \n1 - добавление в список \n2 - вывод всего списка \n3 - удаление из списка " +
                    "\n4 - корректировка записи \n5 - поиск записей по одному из полей \n6 - вывод продуктов с наибольшей ценой " +
                    "\n7 - вывод продуктов с истекающим сроком реализации \nEnter (пустая строка) - завершение работы \n\nВведите номер функции: ");
                function = Console.ReadLine();
                Console.WriteLine();
                switch (function)
                {
                    case "1": AddProduct(); break;
                    case "2": ShowList(); break;
                    case "3": DeleteProduct(); break;
                    case "4": Edit(); break;
                    case "5": Search(); break;
                    case "6": FindExpensive(); break;
                    case "7": FindExpiring(); break;
                    case "": Console.WriteLine("Работа завершена\n"); break;
                    default: Console.WriteLine("Введены неверные данные"); break;
                }
            }
        }
    }
}
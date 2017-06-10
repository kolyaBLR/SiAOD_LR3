using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            string name = "";
            int priority = 0, result = 0;
            MyList list = new MyList();
            Console.WriteLine("add - добавление");
            Console.WriteLine("delete - удаление приоритетного");
            Console.WriteLine("search - поиск по имени");
            Console.WriteLine("exit - выход");
            while (true)
            {
                Console.Write("Введите команду:");
                command = Console.ReadLine();
                switch (command)
                {
                    case "delete":
                        list.DeleteEnd();
                        Console.WriteLine("Команда удаления выполнена успешно.");
                        break;
                    case "add":
                        Console.Write("name:");
                        name = Console.ReadLine();
                        Console.Write("priority:");
                        priority = Convert.ToInt32(Console.ReadLine());
                        list.Add(name, priority);
                        break;
                    case "search":
                        Console.Write("name:");
                        name = Console.ReadLine();
                        result = list.GetPriority(name);
                        string execute = result == -1 ? "Ничего не найдено." : "name:" + name + ", priority:" + result;
                        Console.WriteLine(execute);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("не верная команда.");
                        break;
                }
            }
        }
    }
}

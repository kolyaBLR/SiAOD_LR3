using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR3
{
    public class MyList
    {
        public Item List { get; set; }

        public MyList() { List = new Item(); }

        //добавление нового элемента по его приоритету
        //если приоритет одинаковый то первым в списке
        //октажется тот кто раньше пришёл
        public void Add(string name, int priority)
        {
            ReverseBegin();
            bool maxPriority = true;
            while (!IsEnd())
            {
                List = List.Next;
                if (priority <= List.Priority)
                {
                    Item local = new Item()
                    {
                        Name = name,
                        Priority = priority,
                        Next = List,
                        Back = List.Back
                    };
                    List.Back.Next = local;
                    List.Back = local;
                    List = local;
                    maxPriority = false;
                    break;
                }
            }
            //проверка если список пуст
            //или если приоритет самый большой
            if (IsEmpty() || maxPriority)
            {
                AddEnd(name, priority);
            }
        }

        public void AddEnd(string name, int priority)
        {
            ReverseEnd();
            Item local = new Item()
            {
                Name = name,
                Priority = priority,
                Back = List
            };
            List.Next = local;
            List = List.Next;
        }

        public int GetPriority(string name)
        {
            ReverseBegin();
            while(!IsEnd())
            {
                List = List.Next;
                if (List.Name == name)
                {
                    return List.Priority;
                }
            }
            return -1;
        }

        //удаление последнего
        public void DeleteEnd()
        {
            ReverseEnd();
            if (!IsEmpty())
            {
                List = List.Back;
                List.Next = null;
            }
        }

        //функция для перехода к началу списка
        public void ReverseBegin()
        {
            while (List.Back != null)
            {
                List = List.Back;
            }
            if (List.Back != null && List.Next != null)
                List = List.Next;
        }

        //функция для перехода к концу списка
        public void ReverseEnd()
        {
            while (List.Next != null)
            {
                List = List.Next;
            }
        }

        //являемся ли мы в начале списка
        public bool IsBegin()
        {
            return List.Back == null && List.Next != null;
        }

        //являемся ли мы в конце списка
        public bool IsEnd()
        {
            return List.Next == null;
        }

        //проверяем пустой ли список
        public bool IsEmpty()
        {
            return List.Next == null && List.Back == null && List.Priority == 0 && List.Name == null;
        }
    }
}
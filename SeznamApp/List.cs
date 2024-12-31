using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeznamApp
{
    internal class List
    {
        private Item? head;  // Ukazatel na první prvek seznamu
        private Item? tail;  // Ukazatel na poslední prvek seznamu
        private Item? actual;  // Ukazatel na aktuální prvek

        
        public void Init() // Inicializuje seznam (nastaví všechny ukazatele na null)
        {
            head = null;
            tail = null;
            actual = null;
        }

        public bool IsEmpty() // Zjistí, jestli je seznam prázdný
        {
            return head == null;
        }

        public int GetItem() // Vrátí hodnotu aktuálního prvku
        {
            if (actual == null)
            {
                Console.WriteLine("Aktuální prvek neexistuje.");
                return -1;
            }
            return actual.value;
        }

        public void ToLeft() // Posune aktuální ukazatel doleva (na předchozí prvek)
        {
            if (actual?.previous != null)
            {
                actual = actual.previous;
            }
            else
            {
                Console.WriteLine("Jste již na prvním prvku.");
            }
        }

        public void ToRight() // Posune aktuální ukazatel doprava (na následující prvek)
        {
            if (actual?.next != null)
            {
                actual = actual.next;
            }
            else
            {
                Console.WriteLine("Jste již na posledním prvku.");
            }
        }

        public void InsertToLeft(int value) // Vloží nový prvek nalevo od aktuálního
        {
            var newItem = new Item(value);

            if (IsEmpty())
            {
                head = tail = actual = newItem;
            }
            else if (actual == head)
            {
                newItem.next = head;
                head!.previous = newItem;
                head = newItem;
            }
            else
            {
                newItem.previous = actual?.previous;
                newItem.next = actual;
                if (actual?.previous != null)
                {
                    actual.previous.next = newItem;
                }
                actual.previous = newItem;
            }
        }

        public void InsertToRight(int value) // Vloží nový prvek napravo od aktuálního
        {
            var newItem = new Item(value);

            if (IsEmpty())
            {
                head = tail = actual = newItem;
            }
            else if (actual == tail)
            {
                newItem.previous = tail;
                tail!.next = newItem;
                tail = newItem;
            }
            else
            {
                newItem.next = actual?.next;
                newItem.previous = actual;
                if (actual?.next != null)
                {
                    actual.next.previous = newItem;
                }
                actual.next = newItem;
            }
        }

        public void RemoveActual() // Odstraní aktuální prvek
        {
            if (IsEmpty() || actual == null)
            {
                Console.WriteLine("Není žádný aktuální prvek k odstranění.");
                return;
            }

            if (actual == head)
            {
                head = actual.next;
                if (head != null)
                {
                    head.previous = null;
                }
            }
            else if (actual == tail)
            {
                tail = actual.previous;
                if (tail != null)
                {
                    tail.next = null;
                }
            }
            else
            {
                actual.previous!.next = actual.next;
                actual.next!.previous = actual.previous;
            }

            actual = actual.next ?? actual.previous;
        }

        public void RemoveTail() // Odstraní poslední prvek
        {
            if (IsEmpty())
            {
                Console.WriteLine("Seznam je prázdný.");
                return;
            }

            if (tail == head)
            {
                head = tail = actual = null;
            }
            else
            {
                tail = tail!.previous;
                tail!.next = null;
            }
        }

        public void WriteAll() // Vypíše všechny hodnoty v seznamu
        {
            if (IsEmpty())
            {
                Console.WriteLine("Seznam je prázdný.");
                return;
            }

            var current = head;
            while (current != null)
            {
                Console.Write($"{current.value} ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}

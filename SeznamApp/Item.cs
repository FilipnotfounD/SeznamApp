using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeznamApp
{
    public class Item // Třída představující jeden prvek v seznamu
    {
        public int value;  // Hodnota uložená v prvku
        public Item? next;  // Ukazatel na následující prvek
        public Item? previous;  // Ukazatel na předchozí prvek

        public Item(int v)
        {
            value = v;
            next = null!;
            previous = null!;
        }
    }
}

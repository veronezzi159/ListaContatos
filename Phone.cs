using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaContatos
{
    internal class Phone
    {
        string num;
        Phone? next;
        public Phone(string n)
        {
            num = n;
            next = null;
        }

        public string getNum()
        {
            return num;
        }
        public void setNext(Phone next)
        {
            this.next = next;
        }
        public Phone getNext()
        {
            return this.next;
        }
        public override string ToString() 
        {
            return this.num;
        }
    }
}

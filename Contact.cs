using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaContatos
{
    internal class Contact
    {
        string name;
        string email;
        string andress;
        PhoneList phoneList;
        Contact? next;
        public Contact(string name, string email, string andress)
        {
            this.name = name;
            this.email = email;
            this.andress = andress;
            this.phoneList = new PhoneList();
            this.next = null;
        }

        public PhoneList getPhoneList()
        {
            return this.phoneList;
        }

        public string getName()
        {
            return this.name;
        }

        public void setNext(Contact contact)
        {
            this.next= contact;
        }

        public Contact getNext()
        {
            return this.next;
        }

        public void editName(string name, ContactList cl)
        {
            if (this.name != name)
            {
                cl.RemoveByName(this.name);
                this.name = name;
                cl.Add(this);
            }
            else
            {
                Console.WriteLine("Nome igual!");
            }
        }

        public void Print()
        {
            Console.WriteLine($"Nome: {this.name}, email: {this.email}, endereço: {this.email}\n");
            this.phoneList.ShowAll();
        }

    }
}

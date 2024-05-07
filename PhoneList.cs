using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ListaContatos
{
    internal class PhoneList
    {
        Phone? head;
        Phone? tail;
        public PhoneList()
        {
            head = tail = null;
        }
        bool isEmpty()
        {
            return head == null && tail  == null;
        }

        public void Add( Phone phone)
        {
            if (isEmpty())
            {
                this.head = this.tail = phone;
            } else
            {
                if (head == tail)
                    head = tail = phone;
                else
                {
                    Phone curr = this.head;
                    Phone prev = this.head;
                    bool compare;
                    do
                    {
                        compare = phone.Equals(curr.getNum());
                        if (!compare)
                        {
                            prev = curr;
                            curr = curr.getNext();
                        }
                    } while (compare == true && curr != null);
                    if (compare == false)
                    {
                        curr = this.tail;
                        this.tail.setNext(phone);
                        this.tail = curr;
                    }
                    else
                    {
                        Console.WriteLine("O telefone informado ja existe na lista");
                    }
                }
            }

        }

        public void RemoveByNum()
        {
            if (!isEmpty())
            {
                Console.WriteLine("Digite o numero que você deseja remover");
                string num = Console.ReadLine();   
                if (num == head.getNum()) 
                {
                    if (head == tail)
                        head = tail =null;
                    else
                        head = head.getNext();
                }
                else
                {
                    Phone aux = head;
                    Phone prev = head;
                    bool compare;
                    do
                    {
                        compare= num.Equals(aux.getNum());
                        if (compare)
                        {
                            prev.setNext(aux.getNext());
                            if (prev.getNext() == null)
                                tail = prev;
                        }
                        else
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                    } while (compare == false && aux != null);
                }

            }
        }
        public void ShowAll()
        {
            Phone aux = head;
            Console.WriteLine("Telefones: ");
            do
            {
                Console.WriteLine(aux.ToString());
                aux = aux.getNext();
            } while (aux != null);
            Console.WriteLine("Fim dos telefones");
        }
    }
}

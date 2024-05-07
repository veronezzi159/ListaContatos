using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListaContatos
{
    internal class ContactList
    {
        Contact? head;
        Contact? tail;
        public ContactList()
        {
            head = tail = null;
        }

        bool isEmpty()
        {
            return head == null && tail == null;
        }
        public void Add(Contact contact)
        {
            if (isEmpty())
            {
                this.head = this.tail = contact;
            }
            else
            {
                Contact curr = this.head;
                Contact prev = this.head;
                int compare;
                compare = string.Compare(contact.getName(), curr.getName(), comparisonType: StringComparison.OrdinalIgnoreCase);
                if (compare <= 0)
                {
                    this.head = contact;
                    this.head.setNext(curr);
                }
                else
                {
                    do
                    {
                        compare = string.Compare(contact.getName(), curr.getName(), comparisonType: StringComparison.OrdinalIgnoreCase);
                        if (compare > 0)
                        {
                            prev = curr;
                            curr = curr.getNext();
                        }
                    } while (curr != null && compare > 0);

                    prev.setNext(contact);
                    contact.setNext(curr);
                    if (curr == null)
                        this.tail = prev;
                }
            }
        }

        public void RemoveByName(string name)
        {
            if (!isEmpty())
            {
                if (name == this.head.getName())
                {
                    if (head == tail)
                        tail = head = null;
                    else
                    {
                        head = head.getNext();
                    }
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    bool compare;
                    do
                    {
                        compare = name.Equals(aux.getName());
                        if (!compare)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                        else
                        {
                            prev.setNext(aux.getNext());
                            if (prev.getNext() == null)
                                tail = prev;
                        }

                    } while (compare == false && aux != null);

                    if (aux == null)
                    {
                        Console.WriteLine("Não existe o contato na lista.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Lista vazia!! Impossivel remoção.");
            }
        }

        public void EditContact()
        {
            Console.WriteLine("Digite o nome que deseja editar");
            string edit = Console.ReadLine();

            if (isEmpty())
            {
                Console.WriteLine("Agenda vazia!");
            }
            else
            {

                if (edit == this.head.getName())
                {
                    Contact aux = head;
                    Console.WriteLine("Digite o novo nome");
                    aux.editName(Console.ReadLine(), this);
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    bool compare;
                    do
                    {
                        compare = edit.Equals(aux.getName());
                        if (!compare)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                        else
                        {
                            Console.WriteLine("Digite o novo nome: ");
                            aux.editName(Console.ReadLine(), this);
                        }

                    } while (compare == false && aux != null);

                    if (compare == false)
                    {
                        Console.WriteLine("Não existe o nome buscado");
                    }
                }
            }
        }

        public void ShowAll()
        {
            if (!isEmpty())
            {
                Contact aux = head;
                Console.WriteLine("Agenda completa");
                do
                {
                    aux.Print();
                    aux = aux.getNext();
                } while (aux != null);
                Console.WriteLine("Fim!");
            }
            else
                Console.WriteLine("lista vazia!!");
        }

        public void ShowByName(string sh)
        {
            if (isEmpty())
            {
                Console.WriteLine("Agenda vazia!");
            }
            else
            {
                if (sh == this.head.getName())
                {
                    head.Print();
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    bool compare;
                    do
                    {
                        compare = sh.Equals(aux.getName());
                        if (!compare)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                        else
                        {
                            aux.Print();
                        }

                    } while (compare == false && aux != null);

                    if (compare == false)
                    {
                        Console.WriteLine("Não existe o nome buscado");
                    }
                }

            }
        }

        public void AskNameRemove()
        {
            if (!isEmpty())
            {
                Console.WriteLine("Digite o nome de quem você deseja remover o numero");
                string rem = Console.ReadLine();
                if (rem == this.head.getName())
                {
                    Contact aux = head;
                    PhoneList l1 = aux.getPhoneList();
                    l1.RemoveByNum();
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    bool compare;
                    do
                    {
                        compare = rem.Equals(aux.getName());
                        if (!compare)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                        else
                        {
                            PhoneList l1 = aux.getPhoneList();
                            l1.RemoveByNum();
                        }

                    } while (compare == false && aux != null);

                    if(compare == false)
                    {
                        Console.WriteLine("Nome não encontrado!");
                    }
                }
            }
        }

        public void AskNameAdd()
        {
            if (!isEmpty())
            {
                Console.WriteLine("Digite o nome de quem você deseja adicionar o numero");
                string adc = Console.ReadLine();
                if (adc == this.head.getName())
                {
                    Contact aux = head;
                    PhoneList l1 = aux.getPhoneList();
                    Console.WriteLine("Digite o numero que deseja adiconar");
                    l1.Add(new(Console.ReadLine()));
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    bool compare;
                    do
                    {
                        compare = adc.Equals(aux.getName());
                        if (!compare)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                        else
                        {
                            PhoneList l1 = aux.getPhoneList();
                            Console.WriteLine("Digite o numero que deseja cadastrar: ");
                            l1.Add(new(Console.ReadLine()));
                        }

                    } while (compare == false && aux != null);

                    if (compare == false)
                    {
                        Console.WriteLine("Nome não encontrado!");
                    }
                }
            } else
                Console.WriteLine("agenda vazia! cadastre um contato!");
        }
    }
}

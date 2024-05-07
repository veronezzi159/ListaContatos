using ListaContatos;

ContactList contactList = new ContactList();
int Menu()
{
    Console.WriteLine("Digite a opção desejada: ");
    Console.WriteLine("1 - Cadastrar um contato");
    Console.WriteLine("2 - Cadastrar um numero");
    Console.WriteLine("3 - Deletar um contato");
    Console.WriteLine("4 - Deletar um numero");
    Console.WriteLine("5 - Ver um contato");
    Console.WriteLine("6 - Ver agenda");
    Console.WriteLine("7 - Editar o nome de um contato existe");
    Console.WriteLine("0 - Sair");
    return int.Parse(Console.ReadLine());
}

void pause()
{
    Console.WriteLine("Pressione qualquer tecla pra continuar");
    Console.ReadKey();
    Console.Clear();
}

do
{
    switch (Menu())
    {
        case 1:
            Console.WriteLine("Digite o nome, email e endereço");
            contactList.Add(new(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
            pause();
            break;
        case 2:
            contactList.AskNameAdd();
            pause();
            break;
        case 3:
            Console.WriteLine("Digite o nome do contato que deseja remover");
            contactList.RemoveByName(Console.ReadLine());
            pause();
            break;
        case 4:
            contactList.AskNameRemove();
            pause();    
            break;
        case 5:
            Console.WriteLine("Digite o nome que deseja buscar: ");
            contactList.ShowByName(Console.ReadLine());
            pause();
            break;
        case 6:
            contactList.ShowAll();
            pause();
            break;
        case 7:
            contactList.EditContact();
            pause();
            break;
        case 0:
            Console.WriteLine("Encerrando!!");
            pause();
            break;
        default:
            Console.WriteLine("Escolha uma opção valida!");
            pause();
            break;
    }
} while (Menu() != 0);
using System.Threading.Tasks.Sources;
using AgendaContatos;

List<Contact> phonebook = new List<Contact>();

int op;
do
{
    op = Menu();

    switch (op)
    {
        case 1:
            phonebook.Add(CreateContact());
            break;
        case 2:
            EditContact();
            break;
        case 3:
            phonebook.Remove(DeleteContact());
            break;
        case 4:
            PrintPhoneBook();
            break;
        case 5:
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
} while (true);

void EditContact()
{
    PrintPhoneBook();
    Console.WriteLine("Digite o nome do contato que você quer mudar: ");
    string name = Console.ReadLine();
    foreach (Contact contact in phonebook)
    {
        if (contact.Name.Equals(name))
        {
            int x = 1;
            while (x != 9)
            {
                x = OptionsMenu();
                switch (x)
                {
                    case 1:
                        contact.EditALL();
                        break;
                    case 2:
                        contact.EditName();
                        break;
                    case 3:
                        contact.EditPhone();
                        break;
                    case 4:
                        contact.Address.EditStreet();
                        break;
                    case 5:
                        contact.Address.EditCity();
                        break;
                    case 6:
                        contact.Address.EditState();
                        break;
                    case 7:
                        contact.Address.EditCountry();
                        break;
                    case 8:
                        contact.Address.EditPostalcode();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            }
        }
    }
}

Contact DeleteContact()
{
    Console.WriteLine("Informe o nome: ");
    var n = Console.ReadLine();
    foreach (var item in phonebook)
    {
        if (item.Name.Equals(n))
        {
            return item;
        }
    }
    return null;
}

Contact CreateContact()
{
    Console.WriteLine("Informe o nome: ");
    string n = Console.ReadLine();

    Console.WriteLine("Informe o telefone: ");
    var t = Console.ReadLine();

    foreach (var item in phonebook)
    {
        while (item.Phone.Equals(t))
        {
            Console.WriteLine("O número digitado ja está em um contato existente");
            Console.Write("Digite outro numero para esse conato: ");
            t = Console.ReadLine();
        }
    }
    Contact contact = new Contact(n, t);
    return contact;
}

void PrintPhoneBook()
{
    foreach (var i in phonebook)
    {
        Console.WriteLine(i);
    }
}

int Menu()
{
    Console.WriteLine("MENU DE OPÇÕES \n 1 - Insere Contato" +
        "\n 2 - Editar contato\n 3 - Remover contato\n 4 - Mostrar Agenda\n 5 -  Sair");
    Console.WriteLine("Escolha uma opção: ");
    var xpto = int.Parse(Console.ReadLine());
    return xpto;
}

int OptionsMenu()
{
    int number;
    Console.WriteLine("MENU DE OPÇÕES DA EDIÇÃO \n 1 - Edite todas as informações do Contato" +
    "\n 2 - Editar apenas o nome\n 3 - Editar apenas o telefone\n " +
    "4 - Editar apenas rua \n 5 - Editar apenas cidade \n 6 - Editar apenas estado\n 7 - Editar apenas país" +
    "\n 8 - Editar apenas o cep \n 9 - Sair");
    Console.Write("Escolha uma das opções: ");
    number = int.Parse(Console.ReadLine());

    return number;
}
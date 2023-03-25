using System.Diagnostics.Metrics;
using System.IO;
using System.Text;
using System.Threading.Tasks.Sources;
using AgendaContatos;

string path = @"C:\\Users\\" + System.Environment.UserName + "\\";
string contactlist = path + "listacontato.txt";

if (File.Exists(contactlist) == false)
{
    using (var file = new StreamWriter(contactlist))
    {
        var text = new StringBuilder();
        file.Write(text);
    }
}
List<Contact> phonebook = new List<Contact>();
LoadFromFile(contactlist, phonebook);

List<Contact> LoadFromFile(string path, List<Contact> phone)
{
    if (File.Exists(path))
    {
        StreamReader sr = new StreamReader(path);
        while (!sr.EndOfStream)
        {
            Address address = new Address();
            string[] book = sr.ReadLine().Split(",");
            string name = book[0];
            string phones = book[1];
            address.Street = book[2];
            address.City = book[3];
            address.State = book[4];
            address.PostalCode = book[5];
            address.Country = book[6];
            phone.Add(new(name, phones,address));
        }
        sr.Close();
    }
    return phone;
}

int op;
do
{
    op = Menu();

    switch (op)
    {
        case 1:
            phonebook.Add(CreateContact());
            SaveToFile(phonebook);
            break;
        case 2:
            EditContact();
            SaveToFile(phonebook);
            break;
        case 3:
            phonebook.Remove(DeleteContact());
            SaveToFile(phonebook);
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

void SaveToFile(List<Contact> phonebook)
{
    StreamWriter sw = new(contactlist);
    foreach (var item in phonebook)
    {
        sw.Write(item.ToFile());
    }
    sw.Close();
}

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
    Address newaddress = new Address();
    Console.WriteLine("Informe o nome: ");
    string n = Console.ReadLine();

    Console.WriteLine("Informe o telefone: ");
    var t = Console.ReadLine();

    Console.WriteLine("Digite o nome da nova rua: ");
    newaddress.Street = Console.ReadLine();
    Console.WriteLine("Digite o nome da nova cidade: ");
    newaddress.City = Console.ReadLine();
    Console.WriteLine("Digite o nome do novo estado: ");
    newaddress.State = Console.ReadLine();
    Console.WriteLine("Digite o nome do novo país: ");
    newaddress.Country = Console.ReadLine();
    Console.WriteLine("Digite o novo cep: ");
    newaddress.PostalCode = Console.ReadLine();
    foreach (var item in phonebook)
    {
        while (item.Phone.Equals(t))
        {
            Console.WriteLine("O número digitado ja está em um contato existente");
            Console.Write("Digite outro numero para esse conato: ");
            t = Console.ReadLine();
        }
    }
    Contact contact = new Contact(n, t,newaddress);
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
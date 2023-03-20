using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos
{
    internal class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }

        public Contact(string n, string p) 
        {
            this.Name = n;
            this.Phone = p;
            this.Address = new Address();
        }

        public void EditALL() 
        {
            string p, n,street,state,city,country,postalcode;
            Console.Write("Digite o novo nome: ");
            n = Console.ReadLine();
            Console.WriteLine("Digite o novo número");
            p = Console.ReadLine();
            Console.WriteLine("Digite o nome da nova rua: ");
            street = Console.ReadLine();
            Console.WriteLine("Digite o nome da nova cidade: ");
            city = Console.ReadLine();
            Console.WriteLine("Digite o nome do novo estado: ");
            state = Console.ReadLine();
            Console.WriteLine("Digite o nome do novo país: ");
            country = Console.ReadLine();
            Console.WriteLine("Digite o novo cep: ");
            postalcode = Console.ReadLine();


            Address.Street = street;
            Address.City = city;
            Address.Country = country;
            Address.PostalCode = postalcode;
            Address.State = state;
            this.Name = n;
            this.Phone = p;
        }

        public void EditPhone()
        {
            string p;
            Console.Write("Digite o novo número: ");
            p = Console.ReadLine();
            this.Phone = p;
        }

        public void EditEmail(string e)
        {
            this.Email = e;
        }

        public void EditName()
        {
            string n;
            Console.Write("Digite o novo nome: ");
            n = Console.ReadLine();
            this.Name = n;
        }
        public override string ToString() 
        {
            return $"Nome : {Name} \nTelefone {Phone} {Address}";
        }
    }
}

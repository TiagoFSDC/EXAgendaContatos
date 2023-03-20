using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos
{
    internal class Address
    {
        public string Street;
        public string City;
        public string State;
        public string PostalCode;
        public string Country;

        public Address() 
        {
        }

        public void EditStreet()
        {
            Console.WriteLine("Digite o nome da nova rua: ");
            string s = Console.ReadLine();
            this.Street = s;
        }
        public void EditCity()
        {
            Console.WriteLine("Digite o nome da nova cidade: ");
            string c = Console.ReadLine();
            this.City = c;
        }
        public void EditState()
        {
            Console.WriteLine("Digite o nome do novo estado: ");
            string s = Console.ReadLine();
            this.State = s;
        }
        public void EditCountry()
        {
            Console.WriteLine("Digite o nome do novo país: ");
            string c = Console.ReadLine();
            this.Country = c;
        }
        public void EditPostalcode()
        {
            Console.WriteLine("Digite o novo cep: ");
            string p = Console.ReadLine();
            this.PostalCode = p;
        }

        public override string ToString()
        {
            return "\n\nEndereço: " + Street + "\nEstado: " + State+"\nPaís: " + Country + "\nCidade: " + City + "\nCEP: " + PostalCode + "\n\n";
        }
    }
}

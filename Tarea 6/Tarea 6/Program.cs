using System;
using System.Collections.Generic;

namespace ContactesApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Mi Agenda Perrón");
            Console.WriteLine("Bienvenido a tu lista de contactes");
            ContactManager manager = new ContactManager();

            bool running = true;
            while (running)
            {
                try
                {
                    Console.WriteLine("1. Agregar Contacto  ");
                    Console.WriteLine("2. Ver Contactos  ");
                    Console.Write("3. Buscar Contacto  ");
                    Console.Write("4. Modificar Contacto  ");
                    Console.Write("5. Eliminar Contacto  ");
                    Console.WriteLine("6. Salir");
                    Console.Write("Elige una opción: ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            if (manager.AddContact())
                                Console.WriteLine("Contacto agregado exitosamente!\n");
                            break;
                        case 2:
                            manager.ViewContacts();
                            break;
                        case 3:
                            manager.SearchContact();
                            break;
                        case 4:
                            manager.EditContact();
                            break;
                        case 5:
                            manager.DeleteContact();
                            break;
                        case 6:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            }
        }
    }

    class Contact
    {
        public int Id { get; private set; }
        private string name;
        private string phone;
        private string email;
        private string address;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Contact(int id, string name, string phone, string email, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }

    class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();
        private int nextId = 1;

        public bool AddContact()
        {
            try
            {
                Console.WriteLine("Vamos a agregar ese contacto que te trae loco.");
                Console.Write("Digite el Nombre: ");
                string name = Console.ReadLine();
                Console.Write("Digite el Teléfono: ");
                string phone = Console.ReadLine();
                Console.Write("Digite el Email: ");
                string email = Console.ReadLine();
                Console.Write("Digite la Dirección: ");
                string address = Console.ReadLine();

                contacts.Add(new Contact(nextId++, name, phone, email, address));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar contacto: {ex.Message}");
                return false;
            }
        }

        public void ViewContacts()
        {
            DisplayContactList();
        }

        public void DisplayContactList()
        {
            Console.WriteLine("Id   Nombre   Teléfono   Email   Dirección");
            Console.WriteLine("----------------------------------------");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}   {contact.Name}   {contact.Phone}   {contact.Email}   {contact.Address}");
            }
        }

        public void SearchContact()
        {
            try
            {
                Console.Write("Digite un Id de Contacto Para Mostrar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Contact contact = contacts.Find(c => c.Id == id);
                if (contact != null)
                {
                    Console.WriteLine($"Nombre: {contact.Name}\nTeléfono: {contact.Phone}\nEmail: {contact.Email}\nDirección: {contact.Address}\n");
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número válido.");
            }
        }

        public void EditContact()
        {
            try
            {
                DisplayContactList();
                Console.Write("Digite un Id de Contacto Para Editar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Contact contact = contacts.Find(c => c.Id == id);
                if (contact != null)
                {
                    Console.Write($"El nombre actual es {contact.Name}, digite el nuevo: ");
                    contact.Name = Console.ReadLine();
                    Console.Write($"El teléfono actual es {contact.Phone}, digite el nuevo: ");
                    contact.Phone = Console.ReadLine();
                    Console.Write($"El email actual es {contact.Email}, digite el nuevo: ");
                    contact.Email = Console.ReadLine();
                    Console.Write($"La dirección actual es {contact.Address}, digite la nueva: ");
                    contact.Address = Console.ReadLine();
                    Console.WriteLine("Contacto actualizado!\n");
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número válido.");
            }
        }

        public void DeleteContact()
        {
            try
            {
                DisplayContactList();
                Console.Write("Digite un Id de Contacto Para Eliminar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Contact contact = contacts.Find(c => c.Id == id);
                if (contact != null)
                {
                    contacts.Remove(contact);
                    Console.WriteLine("Contacto eliminado correctamente!\n");
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número válido.");
            }
        }
    }
}

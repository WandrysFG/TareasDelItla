
Console.WriteLine("Bienvenido a mi lista de Contactes");


bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (running)
{

    try
    {
        Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
        Console.WriteLine("Digite el número de la opción deseada");

        int typeOption = Convert.ToInt32(Console.ReadLine());

        switch (typeOption)
        {
            case 1:
                {

                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                }
                break;
            case 2:
                {

                    PrintFriendList(names, lastnames, addresses, telephones, emails, ages, bestFriends, ids);

                }
                break;
            case 3:
                {

                    SearchContact(ids, names, lastnames);

                }
                break;
            case 4:
                {

                    ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                }
                break;
            case 5:
                {

                    DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                }
                break;
            case 6:
                running = false;
                break;
            default:
                Console.WriteLine("Tu eres o te haces el idiota?");
                break;

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se ha producido un error: {ex.Message}");
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al agregar contacto: {ex.Message}");
    }
}

static void PrintFriendList(Dictionary<int, string> names, Dictionary<int, string> lastnames,
                            Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                            Dictionary<int, string> emails, Dictionary<int, int> ages,
                            Dictionary<int, bool> bestFriends, List<int> ids)
{
    Console.WriteLine("Nombre          Apellido            Dirección           Teléfono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine("____________________________________________________________________________________________________________________________");

    foreach (var id in ids)
    {
        var isBestFriend = bestFriends[id];
        string isBestFriendStr = isBestFriend ? "Si" : "No";

        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
    }
}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames)
{
    Console.WriteLine("Digite el nombre o apellido del contacto que desea buscar:");
    string query = Console.ReadLine().ToLower();

    bool found = false;

    foreach (var id in ids)
    {
        if (names[id].ToLower().Contains(query) || lastnames[id].ToLower().Contains(query))
        {
            Console.WriteLine($"ID: {id}, Nombre: {names[id]}, Apellido: {lastnames[id]}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("No se encontró ningún contacto con ese nombre o apellido.");
    }
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                          Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                          Dictionary<int, string> emails, Dictionary<int, int> ages,
                          Dictionary<int, bool> bestFriends)
{

    try
    {
        Console.WriteLine("Digite el ID del contacto que desea modificar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (ids.Contains(id))
        {
            Console.WriteLine("Digite el nuevo nombre:");
            names[id] = Console.ReadLine();
            Console.WriteLine("Digite el nuevo apellido:");
            lastnames[id] = Console.ReadLine();
            Console.WriteLine("Contacto modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al modificar contacto: {ex.Message}");
    }
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                          Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                          Dictionary<int, string> emails, Dictionary<int, int> ages,
                          Dictionary<int, bool> bestFriends)
{
    try
    {
        Console.WriteLine("Digite el ID del contacto que desea eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (ids.Contains(id))
        {
            ids.Remove(id);
            names.Remove(id);
            lastnames.Remove(id);
            addresses.Remove(id);
            telephones.Remove(id);
            emails.Remove(id);
            ages.Remove(id);
            bestFriends.Remove(id);
            Console.WriteLine("Contacto eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar contacto: {ex.Message}");
    }
}

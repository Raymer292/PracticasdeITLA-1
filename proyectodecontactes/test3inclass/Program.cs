using System.Net;
using System.Numerics;
using System.Xml.Linq;

Console.WriteLine("Bienvenido a mi lista de Contactes");

//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (runing)
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
        case 2: //extract this to a method
            {
                extractthis( ids,  names,  lastnames,  addresses,  telephones,  emails,  ages,  bestFriends);
            }
            break;
        case 3: //search
            {
                searchcontact(ref ids,ref names,ref lastnames,ref addresses,ref telephones,ref emails,ref ages,ref bestFriends);
                //Console.WriteLine porque \n no me funciona
                Console.WriteLine();
            }
            break;
        case 4: //modify
            {
                modifycontact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5: //delete
            {
                deletecontact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
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

static void searchcontact(ref List<int> ids,ref Dictionary<int, string> names,ref Dictionary<int, string>  lastnames,ref Dictionary<int, string> addresses,ref Dictionary<int, string> telephones,ref Dictionary<int, string> emails,ref Dictionary<int, int> ages,ref Dictionary<int, bool> bestFriends)
{
    //esta funcion conpara el nombre que se escriba con el nombre igual en el diccionario names y muestra el conntacto
    // copie el formato de addcontacto 
    //posible fallo cuando busacas el nombre por mallusculas 

    Console.WriteLine($" escriba el nombre que desea buscar ");
    var seaecher = Console.ReadLine();
    foreach (var id in ids)
    {

        if (seaecher == names[id])
        {
            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {bestFriends[id]}");
        }
    }
}

static void extractthis(List<int> ids,  Dictionary<int, string> names,  Dictionary<int, string> lastnames,  Dictionary<int, string> addresses,  Dictionary<int, string> telephones,  Dictionary<int, string> emails,  Dictionary<int, int> ages,  Dictionary<int, bool> bestFriends)
{
    //esta ya estaba hecho lo converti en funcion por comodidad para editar
    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");
    foreach (var id in ids)
    {
        var isBestFriend = bestFriends[id];
        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
    }
}

static void modifycontact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    //esta funcion modifica un contacto ya creado usando el nombre como base
    //aqui se sestutiye los valores y se remueve y añaden alos discionarios 
    //los clear son porque se veia horrible todo junto sin ellos 
    //posible error en 'escriba el nombre del contacto que deseasa editar ' 
    //puede aver mejores alternativas que foreach para firtral 


    Console.Clear();  
    extractthis(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
    Console.WriteLine($"\n escriba el nombre del contacto que desesa editar\n ");
    string selecchange = Console.ReadLine();

    foreach (var id in ids)
    {

        if (selecchange == names[id])
        {
            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {bestFriends[id]}");


            Console.WriteLine($"escriba el nuevo nombre de {names[id]} ");
            string name = Console.ReadLine();
            Console.WriteLine($"escriba el nuevo apellido de {lastnames[id]} ");
            string lastname = Console.ReadLine();
            Console.WriteLine($"escriba la nueva direccion  ");
            string address = Console.ReadLine();
            Console.WriteLine($"escriba el nuevo numero de telefono / anterior numero {telephones[id]}");
            string phone = Console.ReadLine();
            Console.WriteLine("escriba el nuevo gmail");
            string email = Console.ReadLine();
            Console.WriteLine("escriba la nueva edad de la persona ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                      
            bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;
            names.Remove(id);
            names.Add(id, name);
            lastnames.Remove(id) ;
            lastnames.Add(id, lastname);
            addresses.Remove(id);
            addresses.Add(id, address);
            telephones.Remove(id) ;
            telephones.Add(id, phone);
            emails.Remove(id);
            emails.Add(id, email);
            ages.Remove(id);
            ages.Add(id, age);
            bestFriends.Remove(id) ;
            bestFriends.Add(id, isBestFriend);

            Console.Clear();
            Console.WriteLine("\n su contacto modificado seria :\n");
            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {bestFriends[id]}");
        }
    }
}

static void deletecontact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    //esta funcion borra un contacto de la lista 
    //se usa la formula anterior y se remueve todos los datos 
    //el foreach fallaba por eso use .TOlist() para provar y se quedo 

    //posible error en foreach  cambiar foreach seria una mejor opcion talvez
    Console.Clear() ;
    Console.WriteLine("lista de contactos en la agenda ");

    extractthis(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
    Console.WriteLine("\n selecciones el nombre del contacto que desea eliminar \n ");
    string selecdelete = Console.ReadLine();

    foreach (var id in ids.ToList())
    {

        if (selecdelete == names[id])
        {
            ids.Remove(id);
            names.Remove(id);
            lastnames.Remove(id);
            addresses.Remove(id);
            telephones.Remove(id);
            emails.Remove(id);
            ages.Remove(id);
            bestFriends.Remove(id);

        }
    }

}




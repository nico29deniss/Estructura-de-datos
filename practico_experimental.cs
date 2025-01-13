using System;
using System.Collections.Generic;

class Contacto
{
    public string Nombre { get; set; }
    public string Numero { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; }

    public Contacto(string nombre, string numero, string correo, string direccion)
    {
        Nombre = nombre;
        Numero = numero;
        Correo = correo;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Teléfono: {Numero}, Correo: {Correo}, Dirección: {Direccion}";
    }
}

class Agenda
{
    private List<Contacto> contactos;

    public Agenda()
    {
        contactos = new List<Contacto>();
    }

    public void AgregarContacto(string nombre, string numero, string correo, string direccion)
    {
        Contacto contacto = new Contacto(nombre, numero, correo, direccion);
        contactos.Add(contacto);
        Console.WriteLine($"Contacto '{nombre}' agregado exitosamente.");
    }

    public void EliminarContacto(string nombre)
    {
        Contacto contacto = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (contacto != null)
        {
            contactos.Remove(contacto);
            Console.WriteLine($"Contacto '{nombre}' eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine($"Contacto '{nombre}' no encontrado.");
        }
    }

    public void BuscarContacto(string nombre)
    {
        Contacto contacto = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (contacto != null)
        {
            Console.WriteLine("Contacto encontrado:");
            Console.WriteLine(contacto);
        }
        else
        {
            Console.WriteLine($"Contacto '{nombre}' no encontrado.");
        }
    }

    public void ListarContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos en la agenda.");
        }
        else
        {
            Console.WriteLine("Lista de contactos:");
            foreach (var contacto in contactos)
            {
                Console.WriteLine(contacto);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda();

        while (true)
        {
            Console.WriteLine("\n--- Menú de Agenda Telefónica ---");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Eliminar contacto");
            Console.WriteLine("3. Buscar contacto");
            Console.WriteLine("4. Listar contactos");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el teléfono: ");
                    string numero = Console.ReadLine();
                    Console.Write("Ingrese el correo: ");
                    string correo = Console.ReadLine();
                    Console.Write("Ingrese la dirección: ");
                    string direccion = Console.ReadLine();
                    agenda.AgregarContacto(nombre, numero, correo, direccion);
                    break;
                case "2":
                    Console.Write("Ingrese el nombre del contacto a eliminar: ");
                    nombre = Console.ReadLine();
                    agenda.EliminarContacto(nombre);
                    break;
                case "3":
                    Console.Write("Ingrese el nombre del contacto a buscar: ");
                    nombre = Console.ReadLine();
                    agenda.BuscarContacto(nombre);
                    break;
                case "4":
                    agenda.ListarContactos();
                    break;
                case "5":
                    Console.WriteLine("Saliendo del programa. ¡Hasta pronto!");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente nuevamente.");
                    break;
            }
        }
    }
}

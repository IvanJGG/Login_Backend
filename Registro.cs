using System;
using System.Collections.Generic;

namespace Inventario
{
    class Program
    {
        // Definición de la clase Producto
        class Producto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }

            public Producto(string nombre, int cantidad, decimal precio)
            {
                Nombre = nombre;
                Cantidad = cantidad;
                Precio = precio;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio:C}";
            }
        }

        public static void Main(string[] args)
        {
            List<Producto> inventario = new List<Producto>();
            string opcion;

            do
            {
                Console.WriteLine("\n--- Sistema de Inventario ---");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar inventario");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto(inventario);
                        break;
                    case "2":
                        MostrarInventario(inventario);
                        break;
                    case "3":
                        EliminarProducto(inventario);
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del sistema de inventario.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            } while (opcion != "4");
        }

        // Método para agregar un producto al inventario
        static void AgregarProducto(List<Producto> inventario)
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            inventario.Add(new Producto(nombre, cantidad, precio));
            Console.WriteLine("Producto agregado exitosamente.");
        }

        // Método para mostrar el inventario completo
        static void MostrarInventario(List<Producto> inventario)
        {
            if (inventario.Count == 0)
            {
                Console.WriteLine("El inventario está vacío.");
            }
            else
            {
                Console.WriteLine("\n--- Inventario ---");
                foreach (Producto producto in inventario)
                {
                    Console.WriteLine(producto);
                }
            }
        }

        // Método para eliminar un producto del inventario.
        static void EliminarProducto(List<Producto> inventario)
        {
            Console.Write("Ingrese el nombre del producto a eliminar: ");
            string nombre = Console.ReadLine();

            Producto productoAEliminar = inventario.Find(p => p.Nombre.ToLower() == nombre.ToLower());

            if (productoAEliminar != null)
            {
                inventario.Remove(productoAEliminar);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrimeroBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SistemasEntities();
            /* var libro = new Libro()
             {
                 id = 2,
                 autor = "Perez Naranjes",
                 titulo = "El bote",
                 precio = Convert.ToDecimal(14.54),
                 editorial = "Chespirito"
             };
             //insertar libro
             context.Libros.Add(libro);
             context.SaveChanges();
            */
            //borrar un libro
            var libro2 = new Libro()
            {
                id = 2
    
            };
            context.Libros.Attach(libro2);
            context.Libros.Remove(libro2);
            context.SaveChanges();
            Console.WriteLine("Pulse enter para continual.....");
            Console.ReadLine();
        }
    }
}

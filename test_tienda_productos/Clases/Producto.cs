using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tienda_productos.Clases
{
    public class Producto
    {
        public Producto(string? nombre, float precio, string? categoria)
        {
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");

            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }
        public string? Nombre { get; set; }
        public float Precio { get; set; }
        public string? Categoria { get; set; }
    }
}

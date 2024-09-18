using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace test_tienda_productos.Clases
{
    public class Tienda
    {
        public List<Producto> Productos { get; set; }

        public Tienda()
        {
            this.Productos = new List<Producto>();
        }


        public void AgregarProducto(Producto producto)
        {
            if(producto == null)
            {
                throw new KeyNotFoundException("Producto nulo");
            }
            else
            {
                Productos.Add(producto);
            }
        }

        public Producto BuscarProducto(string nombre)
        {
            var producto = Productos.FirstOrDefault(p => p.Nombre == nombre);
            if(producto == null)
            {
                throw new KeyNotFoundException("Producto no encontrado");
            }

            return producto;
        }

        public bool EliminarProducto(string nombre)
        {
            var producto = Productos.FirstOrDefault(p => p.Nombre == nombre);
            if (producto == null)
            {
                throw new KeyNotFoundException("Producto no encontrado");
            }

            return Productos.Remove(producto);
        }

        public float CalcularTotal()
        {
            float total = 0;
            foreach(var producto in Productos)
            {
                total += producto.Precio;
            }
            return total;
        }

        public void Aplicar_Descuento(string nombre, float descuento)
        {
            var producto_descuento = BuscarProducto(nombre);

            if(producto_descuento == null)
            {
                throw new KeyNotFoundException("Producto no encontrado");
            }

            if(descuento <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(descuento), "El descuento no puede ser negativo ni cero");
            }

            var nuevo_precio = producto_descuento.Precio - (producto_descuento.Precio * (descuento / 100));

            producto_descuento.ActualizarPrecio(nuevo_precio);

        }
    }
}

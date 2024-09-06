using test_tienda_productos.Clases;

namespace Test_Tienda_XUnit
{
    public class ProductoTests
    {
        [Fact]
        public void CrearProducto_ConPrecioNegativo_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() => new Producto("Producto Invalido", -10, "Categoria"));
        }
    }

    public class TiendaTests
    {
        [Fact]
        public void AgregarProducto_EnTienda()
        {
            var tienda = new Tienda();
            var producto = new Producto("Producto1", 100, "Categoria");
            tienda.AgregarProducto(producto);

            var productoEncontrado = tienda.BuscarProducto("Producto1");
            Assert.Equal("Producto1", productoEncontrado.Nombre);
        }

        [Fact]
        public void CalcularTotalCarrito()
        {
            var tienda = new Tienda();
            var producto1 = new Producto("Producto1", 100, "Categoria");
            var producto2 = new Producto("Producto2", 200, "Categoria");
            tienda.AgregarProducto(producto1);
            tienda.AgregarProducto(producto2);

            var total = tienda.CalcularTotal();
            Assert.Equal(300, total);
        }
    }
}
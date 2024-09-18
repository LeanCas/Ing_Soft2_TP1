using Moq;
using test_tienda_productos.Clases;

namespace Test_Tienda_XUnit
{
    public class ProductoTests
    {
        [Fact]
        public void CrearProducto_ConPrecioNegativo()
        {
            Assert.Throws<ArgumentException>(() => new Producto("Producto Invalido", -10, "Categoria"));
        }

        [Fact]
        public void ActualizarPrecio_ProductoValorNegativo()
        {
            var producto = new Producto("Producto Invalido", 10, "Categoria");

            Assert.Throws<ArgumentOutOfRangeException>(() => producto.ActualizarPrecio(-10));
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
        public void BuscarProducto_EnTienda_Existente()
        {
            var tienda = new Tienda();
            var producto = new Producto("Producto1", 100, "Categoria");
            tienda.AgregarProducto(producto);

            var productoBuscado = tienda.BuscarProducto("Producto1");
            Assert.Equal("Producto1", productoBuscado.Nombre);
        }

        [Fact]
        public void BuscarProducto_EnTienda_NoExistente()
        {
            var tienda = new Tienda();
            var producto = new Producto("Producto1", 100, "Categoria");
            tienda.AgregarProducto(producto);

            Producto productoBuscado;

            Assert.Throws<KeyNotFoundException>(() => productoBuscado = tienda.BuscarProducto("Producto NO ENCONTRADO"));  
        }

        [Fact]
        public void EliminarProducto_EnTienda_Existente()
        {
            var tienda = new Tienda();
            var producto = new Producto("Producto1", 100, "Categoria");
            tienda.AgregarProducto(producto);

            tienda.EliminarProducto("Producto1");

            Assert.DoesNotContain(producto, tienda.Productos);

        }

        [Fact]
        public void EliminarProducto_EnTienda_NoExistente()
        {
            var tienda = new Tienda();

            Assert.Throws<KeyNotFoundException>(() => tienda.EliminarProducto("Producto1"));

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

        [Fact]
        public void AplicarDescuento()
        {
            var mockProducto = new Mock<Producto>("Producto1", 100, "Categoria1");
            var tienda = new Tienda();

            tienda.AgregarProducto(mockProducto.Object);

            tienda.Aplicar_Descuento("Producto1", 20);

            Assert.Equal(80, mockProducto.Object.Precio);

        }

    }
}
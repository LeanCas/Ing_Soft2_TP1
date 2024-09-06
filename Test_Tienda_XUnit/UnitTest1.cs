using test_tienda_productos.Clases;

namespace Test_Tienda_XUnit
{
    public class UnitTest1
    {
        [Fact]
        public void CrearProducto_ConPrecioNegativo_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() => new Producto("Producto Invalido", -10, "Categoria"));
        }
    }
}
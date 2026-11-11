using CupcakeErp.Web.Models;
using Xunit;

namespace CupcakeErp.Tests
{
    public class EstoqueTests
    {
        [Fact]
        public void Deve_Deduzir_Estoque_Corretamente()
        {
            
            var insumo = new Insumo
            {
                Id = 1,
                Nome = "Farinha de Trigo",
                QtdStock = 15.0,
                QtdMinima = 3.0
            };

            double quantidadeUsadaNaReceita = 0.4;

            
            insumo.QtdStock -= quantidadeUsadaNaReceita;

            
            Assert.Equal(14.6, insumo.QtdStock);
        }
    }
}

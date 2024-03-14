using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary.xUnit.Tests._1_Manual
{
    public class TaxCalculatorUnitTests
    {
        private readonly TaxCalculator _taxCalculator;
        public TaxCalculatorUnitTests()
        {
            _taxCalculator = new TaxCalculator(new MockDatabase()); // Paso como parametro de un objeto anual simulado
        }

        [Theory]
        [InlineData(112, 100, 0)]
        [InlineData(127, 100, 1)]
        [InlineData(104, 100, 2)]
        [InlineData(118, 100, 6)]

        public void CalculateTotalValueForPerson_SloudBeExpectedValue(double expected, double amount, int personId)
        {
            //Arrange

            //Act
            var resul = _taxCalculator.CalculateTotalValueForPerson(amount, personId);

            //Assert
            Assert.Equal(expected, resul);
        }

    }
}
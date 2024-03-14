using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary.xUnit.Tests._3_Moq
{
    public class TaxCalculatorTest
    {
        private readonly TaxCalculator _taxCalculator;

        public TaxCalculatorTest()

        {
            //Crear Mock
            var mock = new Mock<IDatabase>(MockBehavior.Default);

            //Definir el comportamiento del mock
            mock.Setup(db => db.GetTaxPercentageByPersonId(It.IsAny<int>())).Returns(0.18);
            mock.Setup(db => db.GetTaxPercentageByPersonId(0)).Returns(0.12);
            mock.Setup(db => db.GetTaxPercentageByPersonId(1)).Returns(0.27);
            mock.Setup(db => db.GetTaxPercentageByPersonId(2)).Returns(0.04);

            _taxCalculator = new TaxCalculator(mock.Object);
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
            var result = _taxCalculator.CalculateTotalValueForPerson(amount, personId);


            //Assert
            Assert.Equal(expected, result, 2);
        }

    }
}

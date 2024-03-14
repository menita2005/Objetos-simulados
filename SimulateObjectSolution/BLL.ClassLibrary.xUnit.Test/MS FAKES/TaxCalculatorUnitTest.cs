using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary.xUnit.Tests._2_MS_Fakes
{
    public class TaxCalculatorUnitTests
    {
        private readonly TaxCalculator _taxCalculator;

        public TaxCalculatorUnitTests()
        {
            var database = new BLL.ClassLibrary.Fakes.StubIDatabase()
            {
                GetTaxPercentageByPersonIdInt32 = (idPerson) =>
                {
                    switch (idPerson)
                    {
                        case 0:
                            return 0.12;
                        case 1:
                            return 0.27;
                        case 2:
                            return 0.04;
                        default:
                            return 0.18;
                    }
                }
            };

            _taxCalculator = new TaxCalculator(database);
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

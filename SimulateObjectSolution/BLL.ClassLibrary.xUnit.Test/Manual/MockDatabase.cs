using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary.xUnit.Tests._1_Manual
{
    public class MockDatabase : IDatabase
    {
        public double GetTaxPercentageByPersonId(int personId)
        {
            switch (personId)
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
    }
}

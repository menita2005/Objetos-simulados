using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary
{
    public interface IDatabase
    {
        double GetTaxPercentageByPersonId(int personId);
    }
}
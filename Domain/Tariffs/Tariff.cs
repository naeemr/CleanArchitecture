using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Product;

namespace Domain.Tariffs;

public interface ITariff
{
    decimal CalculateAnnualCost(Product product, int consumption);
}

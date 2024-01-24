using Microsoft.EntityFrameworkCore;
using PolistirolbetonDomCalc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolistirolbetonDomCalc
{
    class PriceRepository : IPriceRepository
    {
        // Соединение с БД
        public async Task<int> GetPriceByIdAsync(int id)
        {
            int resault = 0;
            using (AppContext appContext = new AppContext())
            {
                var komplektObject = await appContext.Prices.SingleOrDefaultAsync(el => el.Id == id);
                if (komplektObject == null)
                {
                    throw new InvalidOperationException("Price is not found");
                }
                else
                {
                    resault = komplektObject.Value;
                }
            }
            return resault;
        }


    }
}

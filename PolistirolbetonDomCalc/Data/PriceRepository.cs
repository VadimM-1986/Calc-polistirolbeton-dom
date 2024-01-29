using Microsoft.EntityFrameworkCore;
using PolistirolbetonDomCalc.Core;

namespace PolistirolbetonDomCalc;

public class PriceRepository : IPriceRepository
{
    private readonly AppContext _context;

    public PriceRepository(AppContext context)
    {
        _context = context;
    }

    // Соединение с БД
    public async Task<int> GetPriceByIdAsync(int id)
    {
        int resault = 0;

        var komplektObject = await _context.Prices.SingleOrDefaultAsync(el => el.Id == id);

        if (komplektObject == null)
        {
            throw new InvalidOperationException($"Price is not found ID: {id}");
        }
        else
        {
            resault = komplektObject.Value;
        }

        return resault;
    }
}

using PolistirolbetonDomCalc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolistirolbetonDomCalc
{
    public class CalculatorService
    {
        // Бизнес логика
        public int Service_Id { get; set; } // ID
        public int Input_square { get; set; } // Площадь дома
        public int CheckRes_1 { get; set; } // Умножение
        public int CheckRes_1_2 { get; set; } // Прибовление
        public int CheckRes_1_3 { get; set; } // Прибовление и умножение
        public int CheckRes_1_4 { get; set; } // Прибовление и умножение
        public int CheckRes_2 {  get; set; } // 0

        public CalculatorService(int Id, int Input_filed) 
        {
            this.Service_Id = Id;
            this.Input_square = Input_filed;
        }

        public async Task InitializeAsync()
        {
            int ServicePrice = await GetPriceByIdAsync(Service_Id);
            this.CheckRes_1 = Input_square *= ServicePrice - Input_square;
            this.CheckRes_2 = Input_square *= 0;
        }
        public async Task InitializePlus()
        {
            int ServicePrice = await GetPriceByIdAsync(Service_Id);
            this.CheckRes_1_2 = Input_square += ServicePrice - Input_square;
            this.CheckRes_2 = Input_square *= 0;
        }
        public async Task InitializePlusMulti(int plOkon_value )
        {
            int ServicePrice = await GetPriceByIdAsync(Service_Id);
            this.CheckRes_1_3 = Input_square += ServicePrice * plOkon_value - Input_square;
            this.CheckRes_2 = Input_square *= 0;
        }
        public async Task InitializeDeliveri(int km_value)
        {
            int ServicePrice = await GetPriceByIdAsync(Service_Id);
            this.CheckRes_1_4 = Input_square += km_value * ServicePrice - Input_square;
            this.CheckRes_2 = Input_square *= 0;
        }


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

using PolistirolbetonDomCalc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PolistirolbetonDomCalc
{
    public class CalculatorService
    {
        // Бизнес логика

        // Передаем Id услуги
        const int SETWALLS_ID = 1;
        const int PROJECT_ID = 2;
        const int GEOLOGI_ID = 3;
        const int GEODESY_ID = 4;
        const int CONSTRUCTION_ID = 5;
        const int ARMO_ID = 6;
        const int SEAMS_ID = 7;
        const int DELIVERY_ID = 8;
        const int FUNDATION_ID = 9;
        const int ROOF_ID = 10;
        const int WINDOWS_ID = 11;
        const int DOOR_ID = 12;

  
        public async Task<int> GetWallsCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(SETWALLS_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetProjectsCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(PROJECT_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetGeologyCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(GEOLOGI_ID);
            int resultCost = areaHouseValue += ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetGeodesyCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(GEODESY_ID);
            int resultCost = areaHouseValue += ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetConstructionCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(CONSTRUCTION_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetArmoCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(ARMO_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetSeamsCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(SEAMS_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetDeliveryCost(int areaHouseValue, int km_value)
        {
            if (km_value != 0)
            {
                int ServicePrice = await GetPriceByIdAsync(DELIVERY_ID);
                int resultCost = areaHouseValue += km_value * ServicePrice - areaHouseValue;
                return resultCost;
            } 
            else
            {
                MessageBox.Show("Enter distance of the object!");
                return 0;
            }
        }

        public async Task<int> GetFundationCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(FUNDATION_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetRoofCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(ROOF_ID);
            int resultCost = areaHouseValue *= ServicePrice - areaHouseValue;
            return resultCost;
        }

        public async Task<int> GetWindowsCost(int areaHouseValue, int filedWindowArea)
        {

            if (filedWindowArea != 0)
            {
                int ServicePrice = await GetPriceByIdAsync(WINDOWS_ID);
                int resultCost = areaHouseValue += ServicePrice * filedWindowArea - areaHouseValue;
                return resultCost;  
            } 
            else 
            {
                MessageBox.Show("Enter the area m² of the windows!");
                return 0;
            }

        }

        public async Task<int> GetDoorCost(int areaHouseValue)
        {
            int ServicePrice = await GetPriceByIdAsync(DOOR_ID);
            int resultCost = areaHouseValue += ServicePrice - areaHouseValue;
            return resultCost;
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

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

  
        public async Task<int> GetWallsCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(SETWALLS_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetProjectsCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(PROJECT_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetGeologyCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(GEOLOGI_ID);
            int resultCost = areaHouseValueSquarMeter + servicePrice - areaHouseValueSquarMeter;
            return resultCost;
        }

        public async Task<int> GetGeodesyCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(GEODESY_ID);
            int resultCost = areaHouseValueSquarMeter + servicePrice - areaHouseValueSquarMeter;
            return resultCost;
        }

        public async Task<int> GetConstructionCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(CONSTRUCTION_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetArmoCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(ARMO_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetSeamsCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(SEAMS_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetDeliveryCost(int areaHouseValueSquarMeter, int DistanceKilometersValue)
        { 
            if (DistanceKilometersValue != 0)
            {
                int servicePrice = await GetPriceByIdAsync(DELIVERY_ID);
                int resultCost = areaHouseValueSquarMeter + DistanceKilometersValue * servicePrice - areaHouseValueSquarMeter;
                return resultCost;
            }
            else
            {
                throw new Exception("Enter distance of the object!");
            }
        }

        public async Task<int> GetFundationCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(FUNDATION_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetRoofCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(ROOF_ID);
            int resultCost = areaHouseValueSquarMeter * servicePrice;
            return resultCost;
        }

        public async Task<int> GetWindowsCost(int areaHouseValueSquarMeter, int filedWindowArea)
        {
            if (filedWindowArea != 0)
            {
                int servicePrice = await GetPriceByIdAsync(WINDOWS_ID);
                int resultCost = areaHouseValueSquarMeter + servicePrice * filedWindowArea - areaHouseValueSquarMeter;
                return resultCost;
            }
            else
            {
                throw new Exception("Enter the area m² of the windows!");
            }
        }

        public async Task<int> GetDoorCost(int areaHouseValueSquarMeter)
        {
            int servicePrice = await GetPriceByIdAsync(DOOR_ID);
            int resultCost = areaHouseValueSquarMeter + servicePrice - areaHouseValueSquarMeter;
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

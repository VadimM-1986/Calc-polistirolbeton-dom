﻿using Microsoft.EntityFrameworkCore;
using PolistirolbetonDomCalc.Core;
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
        PriceRepository priceRepository = new PriceRepository();

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

  
        public async Task<int> GetWallsCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(SETWALLS_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetProjectsCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(PROJECT_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetGeologyCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(GEOLOGI_ID);
            int resultCost = areaHouseSquarMeters + servicePrice - areaHouseSquarMeters;
            return resultCost;
        }

        public async Task<int> GetGeodesyCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(GEODESY_ID);
            int resultCost = areaHouseSquarMeters + servicePrice - areaHouseSquarMeters;
            return resultCost;
        }

        public async Task<int> GetConstructionCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(CONSTRUCTION_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetArmoCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(ARMO_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetSeamsCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(SEAMS_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetDeliveryCost(int areaHouseSquarMeters, int distanceKilometers)
        { 
            if (distanceKilometers <= 0)
            {
                throw new ArgumentException("Incorrect value of the variable Distance! Should be greater than 0!", nameof (distanceKilometers));
            }
            int servicePrice = await priceRepository.GetPriceByIdAsync(DELIVERY_ID);
            int resultCost = areaHouseSquarMeters + distanceKilometers * servicePrice - areaHouseSquarMeters;
            return resultCost;
        }

        public async Task<int> GetFundationCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(FUNDATION_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetRoofCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(ROOF_ID);
            int resultCost = areaHouseSquarMeters * servicePrice;
            return resultCost;
        }

        public async Task<int> GetWindowsCost(int areaHouseSquarMeters, int filedWindowArea)
        {
            if (filedWindowArea <= 0)
            {
                throw new ArgumentException("Incorrect value of the Window variable! Must be greater than 0!", nameof (filedWindowArea));
            }
            int servicePrice = await priceRepository.GetPriceByIdAsync(WINDOWS_ID);
            int resultCost = areaHouseSquarMeters + servicePrice * filedWindowArea - areaHouseSquarMeters;
            return resultCost;
        }
        public async Task<int> GetDoorCost(int areaHouseSquarMeters)
        {
            int servicePrice = await priceRepository.GetPriceByIdAsync(DOOR_ID);
            int resultCost = areaHouseSquarMeters + servicePrice - areaHouseSquarMeters;
            return resultCost;
        }



    }
}

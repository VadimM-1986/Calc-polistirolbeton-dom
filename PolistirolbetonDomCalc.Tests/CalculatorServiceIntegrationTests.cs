using Microsoft.EntityFrameworkCore;

namespace PolistirolbetonDomCalc.Tests;

public class CalculatorServiceIntegrationTests
{

    // Подготовка теста
    // 1. Подготовить базу
    // 1.1 Убедиться что она существует
    // 1.2 Очистить её
    // 1.3 Заполнить тестовыми данными


    [Fact]
    public async Task GetWallsCost_100_160000return()
    {
        int areaHouseSquar = 100;
        int expected = 1600000;

        // 1.1 Убедиться что она существует
        var context = new AppContext("Data Source = :memory:");
        // 1.2 Очистить её
        await ClearDatabaseAsync(context);
        // 1.3 Заполнить тестовыми данными
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetWallsCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetProjectsCost_100_65000return()
    {
        int areaHouseSquar = 100;
        int expected = 65000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetProjectsCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetGeologyCost_40000return()
    {
        int expected = 40000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetGeologyCost();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetGeodesyCost_15000return()
    {
        int expected = 15000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetGeodesyCost();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetConstructionCost_100_550000return()
    {
        int areaHouseSquar = 100;
        int expected = 550000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetConstructionCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetArmo_100_30000return()
    {
        int areaHouseSquar = 100;
        int expected = 30000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetArmoCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetSeamsCost_100_30000return()
    {
        int areaHouseSquar = 100;
        int expected = 30000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetSeamsCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetDeliveryCost_50_10000return()
    {
        int distanceKilometers = 50;
        int expected = 10000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetDeliveryCost(distanceKilometers);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetFundationCost_100_1150000return()
    {
        int areaHouseSquar = 100;
        int expected = 1150000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetFundationCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetRoofCost_100_1350000return()
    {
        int areaHouseSquar = 100;
        int expected = 1350000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetRoofCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetWindowsCost_100_387500return()
    {
        int filedWindowArea = 25;
        int expected = 387500;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetWindowsCost(filedWindowArea);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetDoorCost_65000return()
    {
        int expected = 65000;

        var context = new AppContext();
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetDoorCost();

        Assert.Equal(expected, actual);
    }

    private static async Task FillDatabaseAsync(AppContext context)
    {
        await context.GetDatabase().ExecuteSqlAsync(
            $"""
            INSERT INTO Prices 
            ( "Id", "Name", "Value" )
            VALUES
            (1, "SetWalls", 16000),
            (2, "Projects", 650),
            (3, "Geology", 40000),
            (4, "Geodesy", 15000),
            (5, "Construction", 5500),
            (6, "Armo", 300),
            (7, "Seams", 300),
            (8, "Devilery", 200),
            (9, "Fundation", 11500),
            (10, "Roof", 13500),
            (11, "Windows", 15500),
            (12, "Door", 65000)
            """);
    }

    private static async Task ClearDatabaseAsync(AppContext context)
    {
        await context.GetDatabase().ExecuteSqlAsync($"DELETE FROM Prices");
    }
}
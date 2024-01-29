using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PolistirolbetonDomCalc.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolistirolbetonDomCalc;

public class AppContext : DbContext
{
    private readonly string _dataSource;
    public DbSet<Price> Prices { get; set; }

    public AppContext(string dataSource = "Data Source=helloapp.db")
    {
        _dataSource = dataSource;
        Database.EnsureCreated();
    }

    public DatabaseFacade GetDatabase()
    {
        return Database;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilder = new SqliteConnection(_dataSource);
        connectionStringBuilder.Open();
        optionsBuilder.UseSqlite(connectionStringBuilder);
    }
}
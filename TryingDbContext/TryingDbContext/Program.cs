using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TryingDbContext.Models;

namespace TryingDbContext;

public class Program
{
    private const string DbName = "dbo.Users";

    static async Task Main(string[] args)
    {
        //PopulateDb(10_000);
        //PopulateConstantly(1_000_000);

        using var dbContext = new UserDbContext();
        var allUsers = dbContext.Database.SqlQuery<User>($"SELECT * FROM {DbName}").ToList();
        Console.WriteLine($"count {allUsers.Count}");

        MeasureAll(20);

        Console.ReadLine();
    }

    public static void PopulateConstantly(int count)
    {
        using var dbContext = new UserDbContext();

        for (int i = 0; i < count; i++)
        {
            var randomString = RandomStringGenerator.GetRandomString();
            var user = new User()
            {
                Name = randomString,
                Password = randomString
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }

    public static void PopulateDb(int count)
    {
        using var dbContext = new UserDbContext();

        for (int i = 0; i < count; i++)
        {
            var randomString = RandomStringGenerator.GetRandomString();
            var user = new User()
            {
                Name = randomString,
                Password = randomString
            };

            dbContext.Users.Add(user);
        }

        dbContext.SaveChanges();
    }

    private static void MeasureAll(int times)
    {
        Expression<Func<User, bool>> where = user => user.Name.Contains("1");

        Console.WriteLine("current");
        Measure(() => GetAllCurrent(where), times);
        Console.WriteLine("direct where");
        Measure(() => GetAllDirectWhere(where), times);
        Console.WriteLine("enumerable to list");
        Measure(() => GetAllEnumerableToList(where), times);
        Console.WriteLine("enumerable to array");
        Measure(() => GetAllEnumerableToArray(where), times);
        Console.WriteLine("custom");
        Measure(GetAllCustom, times);
        Console.WriteLine("custom parametrized");
        Measure(GetAllCustomParametrized, times);
        Console.WriteLine("db set");
        Measure(() => GetAllDbSet(where), times);
    }

    private static void Measure<T>(Func<IEnumerable<T>> func, int times)
    {
        var average = Enumerable.Range(0, times)
            .Select(time => RunOnce(func))
            .Average();

        Console.WriteLine($"Elapsed time: {average} ms");
        Console.WriteLine();
    }

    private static long RunOnce<T>(Func<IEnumerable<T>> func)
    {
        var stopwatch = Stopwatch.StartNew();
        var all = func();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    public static IEnumerable<User> GetAllDirectWhere(Expression<Func<User, bool>> where)
    {
        var func = where.Compile();
        using var dbContext = new UserDbContext();
        return dbContext.Database.SqlQuery<User>($"SELECT * FROM {DbName}")
            .Where(user => func(user))
            .ToList();
    }

    public static IEnumerable<User> GetAllCurrent(Expression<Func<User, bool>> where)
    {
        using var dbContext = new UserDbContext();
        return dbContext.Database.SqlQuery<User>($"SELECT * FROM {DbName}")
            .AsQueryable()
            .Where(where)
            .ToList();
    }

    public static IEnumerable<User> GetAllEnumerableToList(Expression<Func<User, bool>> where)
    {
        var list = GetAllEnumerable(where).ToList();
        return list;
    }

    public static IEnumerable<User> GetAllEnumerableToArray(Expression<Func<User, bool>> where)
    {
        var list = GetAllEnumerable(where).ToArray();
        return list;
    }

    public static IEnumerable<User> GetAllEnumerable(Expression<Func<User, bool>> where)
    {
        var func = where.Compile();
        using var dbContext = new UserDbContext();
        using var enumerator = dbContext.Database.SqlQuery<User>($"SELECT * FROM {DbName}")
            .GetEnumerator();

        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;

            if (func(current))
                yield return current;
        }
    }

    public static IEnumerable<User> GetAllCustom()
    {
        using var dbContext = new UserDbContext();
        return dbContext.Database.SqlQuery<User>($"SELECT * FROM {DbName} WHERE Name LIKE '%1%'")
            .ToList();
    }

    public static IEnumerable<User> GetAllCustomParametrized()
    {
        using var dbContext = new UserDbContext();
        return dbContext.Database.SqlQuery<User>(
            $"SELECT * FROM {DbName} WHERE Name LIKE @p1",
            new SqlParameter("@p1","%1%"))
            .ToList();
    }

    public static IEnumerable<User> GetAllDbSet(Expression<Func<User, bool>> where)
    {
        using var dbContext = new UserDbContext();
        return dbContext.Users
            .Where(where)
            .ToList();
    }
}

// 1
//count 300436
//current
//Elapsed time: 510.64 ms

//direct where
//Elapsed time: 519.01 ms

//enumerable
//Elapsed time: 0 ms

//enumerable to list
//Elapsed time: 521.07 ms

//enumerable to array
//Elapsed time: 520.29 ms

//custom
//Elapsed time: 316.25 ms

//custom parametrized
//Elapsed time: 314.03 ms

//db set
//Elapsed time: 363.61 ms


// 2
//count 387421
//current
//Elapsed time: 677.4 ms

//direct where
//Elapsed time: 703.65 ms

//enumerable to list
//Elapsed time: 666 ms

//enumerable to array
//Elapsed time: 664.55 ms

//custom
//Elapsed time: 407.2 ms

//custom parametrized
//Elapsed time: 411.65 ms

//db set
//Elapsed time: 459.5 ms
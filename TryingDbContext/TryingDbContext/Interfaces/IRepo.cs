using System;
using System.Linq;

namespace TryingDbContext;

public interface IRepo : IDisposable
{
    IQueryable<string> Strings1 { get; }
    IQueryable<string> Strings2 { get; }
}
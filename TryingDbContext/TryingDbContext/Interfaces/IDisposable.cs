using System;

namespace TryingDbContext;

public abstract class BaseDisposable : IDisposable
{
    protected bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~BaseDisposable()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        _disposed = true;
    }
}
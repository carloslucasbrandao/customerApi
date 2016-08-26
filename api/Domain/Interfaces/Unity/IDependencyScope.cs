using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Unity
{
    public interface IDependencyScope : IDisposable
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}

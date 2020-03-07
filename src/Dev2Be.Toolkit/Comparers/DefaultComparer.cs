using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Comparers
{
    public class DefaultComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            return (x.GetHashCode() == y.GetHashCode());
        }

        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
}

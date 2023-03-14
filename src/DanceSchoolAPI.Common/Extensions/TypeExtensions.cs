using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceSchoolAPI.Common.Extensions;

public static class TypeExtensions
{
    public static bool IsAssignableAs(this Type parentType, Type subType)
    {
        if (subType.IsAssignableFrom(parentType) || (parentType.GetInterfaces().Concat(Enumerable.Repeat(parentType, 1))
            .Any(o => o.IsGenericType && o.GetGenericTypeDefinition() == subType)))
            return true;
        else if (parentType.BaseType == null)
            return false;

        return IsAssignableAs(parentType.BaseType, subType);
    }
}

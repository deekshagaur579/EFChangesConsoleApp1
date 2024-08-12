using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSPConsoleApp1
{
    public class SPCreation
    {
        //string GetReturnType(EdmFunction sp)
        //{
        //    if (sp.ReturnType == null)
        //        return "int";
        //    else if (sp.ReturnType.EdmType is CollectionType)
        //        return $"ObjectResult<{((CollectionType)sp.ReturnType.EdmType).TypeUsage.EdmType.Name}>";
        //    else
        //        return $"ObjectResult<{sp.ReturnType.EdmType.Name}>";
        //}

        //string GetParameters(EdmFunction sp)
        //{
        //    return string.Join(", ", sp.Parameters.Select(p => $"{GetClrType(p.TypeUsage)} {p.Name}"));
        //}

        //string GetClrType(TypeUsage typeUsage)
        //{
        //    var edmType = typeUsage.EdmType;
        //    var nullableUnderlying = Nullable.GetUnderlyingType(edmType.ClrType);
        //    return nullableUnderlying != null ? nullableUnderlying.Name + "?" : edmType.ClrType.Name;
        //}

        //string GetExecutionCode(EdmFunction sp)
        //{
        //    var parameterNames = string.Join(", ", sp.Parameters.Select(p => p.Name));
        //    var genericType = sp.ReturnType == null ? "int" : GetReturnType(sp).Replace("ObjectResult<", "").Replace(">", "");
        //    return $"return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<{genericType}>(\"{sp.Name}\", {parameterNames});";
        //}
    }
}

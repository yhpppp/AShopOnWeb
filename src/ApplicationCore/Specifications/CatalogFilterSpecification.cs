using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : Specification<CatalogItem>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId)
        {
            Query.Where(ci => (!brandId.HasValue || ci.CatalogBrandId == brandId) && (!typeId.HasValue || ci.CatalogTypeId == typeId));
        }
    }
}

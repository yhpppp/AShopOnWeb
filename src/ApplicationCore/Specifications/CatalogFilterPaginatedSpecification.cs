using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId) : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query.Where(ci => (!brandId.HasValue || ci.CatalogBrandId == brandId) && (!typeId.HasValue || ci.CatalogTypeId == typeId)).Skip(skip).Take(take);

        }
    }
}

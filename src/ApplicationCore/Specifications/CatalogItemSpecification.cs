using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class CatalogItemSpecification : Specification<CatalogItem>
    {
        public CatalogItemSpecification(string name)
        {
            Query.Where(ci => ci.Name == name);
        }

        public CatalogItemSpecification(int catalogId)
        {
            Query.Where(ci => ci.Id == catalogId);
        }
    }
}

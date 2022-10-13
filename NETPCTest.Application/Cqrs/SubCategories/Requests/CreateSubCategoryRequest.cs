using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETPCTest.Application.Cqrs.SubCategories.Requests
{
    public record CreateSubCategoryRequest(string SubCategoryName)
    {
    }
}

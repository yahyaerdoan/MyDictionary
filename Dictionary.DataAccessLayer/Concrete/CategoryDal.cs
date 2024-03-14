using Dictionary.DataAccessLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Context
{
    public class CategoryDal : GenericRepository<Category>, ICategoryDal
    {
        DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext();
        public int GetCategoryCount()
        {
            var values = _dbDictionaryContext.Categories.Count();
            return values;
        }
    }
}

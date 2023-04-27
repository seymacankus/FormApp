using FormApp.Data.Abstract;
using FormApp.Data.Concrete.EfCore.Context;
using FormApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Data.Concrete.EfCore
{
    public class EfCoreTestFormFieldRepository : EfCoreGenericRepository<TestFormField>, ITestFormFieldRepository
    {
        public EfCoreTestFormFieldRepository(FormAppContext _appContext) : base(_appContext)
        {
        }
        FormAppContext AppContext
        {
            get { return _dbContext as FormAppContext; }
        }
    }
}

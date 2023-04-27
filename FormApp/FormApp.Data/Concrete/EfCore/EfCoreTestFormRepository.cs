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
    public class EfCoreTestFormRepository : EfCoreGenericRepository<TestForm>, ITestFormRepository
    {
        public EfCoreTestFormRepository(FormAppContext _appContext) : base(_appContext)
        {
        }
        FormAppContext AppContext
        {
            get { return _dbContext as FormAppContext; }
        }

        public async Task<TestForm> GetFormsWithFieldsById(int id)
        {
            return await AppContext
                .TestForms
                .Include(x => x.Fields)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

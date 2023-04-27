using FormApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Business.Abstract
{
    public interface ITestFormService 
    {
        Task CreateAsync(TestForm testForm);
        Task<TestForm> GetByIdAsync(int id);
        Task<List<TestForm>> GetAllAsync();
        void Update(TestForm testForm);
        void Delete(TestForm testForm);
        Task<TestForm> GetFormsWithFieldsById(int id);
    }
}

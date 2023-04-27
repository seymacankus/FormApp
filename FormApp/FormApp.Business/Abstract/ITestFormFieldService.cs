using FormApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Business.Abstract
{
    public interface ITestFormFieldService
    {
        Task CreateAsync(TestFormField testFormField);
        Task<TestFormField> GetByIdAsync(int id);
        Task<List<TestFormField>> GetAllAsync();
        void Update(TestFormField testFormField);
        void Delete(TestFormField testFormField);
    }
}

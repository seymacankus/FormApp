using FormApp.Business.Abstract;
using FormApp.Data.Abstract;
using FormApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Business.Concrete
{
    public class TestFormFieldManager : ITestFormFieldService
    {
        private ITestFormFieldRepository _testFormFieldRepository;
        public TestFormFieldManager(ITestFormFieldRepository testFormFieldRepository)
        {
            _testFormFieldRepository = testFormFieldRepository;
        }
        public async Task CreateAsync(TestFormField testFormField)
        {
            await _testFormFieldRepository.CreateAsync(testFormField);
        }

        public void Delete(TestFormField testFormField)
        {
            _testFormFieldRepository.Delete(testFormField);
        }

        public async Task<List<TestFormField>> GetAllAsync()
        {
            return await _testFormFieldRepository.GetAllAsync();
        }

        public async Task<TestFormField> GetByIdAsync(int id)
        {
            return await _testFormFieldRepository.GetByIdAsync(id);
        }

        public void Update(TestFormField testFormField)
        {
            _testFormFieldRepository.Update(testFormField);
        }
    }
}

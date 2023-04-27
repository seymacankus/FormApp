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
    public class TestFormManager : ITestFormService
    {
        private ITestFormRepository _testFormRepository;
        public TestFormManager(ITestFormRepository testFormRepository)
        {
            _testFormRepository = testFormRepository;
        }
        public async Task CreateAsync(TestForm testForm)
        {
            await _testFormRepository.CreateAsync(testForm);
        }

        public void Delete(TestForm testForm)
        {
            _testFormRepository.Delete(testForm);
        }

        public async Task<List<TestForm>> GetAllAsync()
        {
            return await _testFormRepository.GetAllAsync();
        }

        public async Task<TestForm> GetByIdAsync(int id)
        {
            return await _testFormRepository.GetByIdAsync(id);
        }

        public async Task<TestForm> GetFormsWithFieldsById(int id)
        {
            return await _testFormRepository.GetFormsWithFieldsById(id);
        }

        public void Update(TestForm testForm)
        {
            _testFormRepository.Update(testForm);
        }
    }
}

using FormApp.Business.Abstract;
using FormApp.Entity;
using FormApp.Entity.Identity;
using FormApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace FormApp.MVC.Controllers
{
    [Authorize]
    public class FormsController : Controller
    {
        private readonly ITestFormService _testFormService;
        private readonly ITestFormFieldService _testFormFieldService;
        private readonly UserManager<User> _userManager;
        public FormsController(ITestFormService testFormService, ITestFormFieldService testFormFieldService, UserManager<User> userManager)
        {
            _testFormService = testFormService;
            _testFormFieldService = testFormFieldService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<TestForm> formList = await _testFormService.GetAllAsync();
            List<TestFormModel> testForms = new List<TestFormModel>();
            foreach (var form in formList)
            {
                testForms.Add(new TestFormModel
                {
                    Id = form.Id,
                    Name = form.Name,
                    Description = form.Description,
                    CreatedAt = form.CreatedAt,
                    CreatedBy = form.CreatedBy
                });
            }

            return View(testForms);
        }

        public IActionResult GetFormFieldPartial()
        {
            return PartialView("_FormFieldPartial");
        }

        public JsonResult AddFormField(TestFormFieldModel testFormFieldModel)
        {
            var formFieldListStr = HttpContext.Session.GetString("TestFormFieldList");
            var formFieldList = string.IsNullOrEmpty(formFieldListStr) ? new List<TestFormFieldModel>() : JsonSerializer.Deserialize<List<TestFormFieldModel>>(formFieldListStr);

            var id = formFieldList.Any() ? formFieldList.Max(x => x.Id) : 0;
            testFormFieldModel.Id = id + 1;

            formFieldList.Add(testFormFieldModel);

            HttpContext.Session.SetString("TestFormFieldList", JsonSerializer.Serialize(formFieldList));

            return Json(true);
        }

        public JsonResult DeleteFormField(int id)
        {
            var formFieldListStr = HttpContext.Session.GetString("TestFormFieldList");
            var formFieldList = string.IsNullOrEmpty(formFieldListStr) ? new List<TestFormFieldModel>() : JsonSerializer.Deserialize<List<TestFormFieldModel>>(formFieldListStr);

            var field = formFieldList.FirstOrDefault(x => x.Id == id);
            if (field != null)
            {
                formFieldList.Remove(field);
                HttpContext.Session.SetString("TestFormFieldList", JsonSerializer.Serialize(formFieldList));
            }


            return Json(true);
        }

        public async Task<JsonResult> AddForm(TestFormModel testFormModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var formFieldListStr = HttpContext.Session.GetString("TestFormFieldList");
            var formFieldList = string.IsNullOrEmpty(formFieldListStr) ? new List<TestFormFieldModel>() : JsonSerializer.Deserialize<List<TestFormFieldModel>>(formFieldListStr);

            var testFormEntity = new TestForm()
            {
                Name = testFormModel.Name,
                Description = testFormModel.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Id,
                Fields = formFieldList.Select(x => new TestFormField()
                {
                    Name = x.Name,
                    DataType = x.DataType,
                    Required = x.Required,
                }).ToList()
            };

            await _testFormService.CreateAsync(testFormEntity);

            HttpContext.Session.SetString("TestFormFieldList", JsonSerializer.Serialize(new List<TestFormFieldModel>()));

            return Json(true);
        }

        [Route("Form/{id}")]
        public async Task<IActionResult> ShowForm(int id)
        {
            var form = await _testFormService.GetFormsWithFieldsById(id);

            var model = new TestFormModel()
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description,
                CreatedAt = form.CreatedAt,
                CreatedBy = form.CreatedBy,
                FieldModels = form.Fields.Select(x => new TestFormFieldModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DataType = x.DataType,
                    Required = x.Required,
                }).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var form = await _testFormService.GetByIdAsync(id);
            _testFormService.Delete(form);
            return RedirectToAction("Index");
        }

        public JsonResult ResetFieldList()
        {
            HttpContext.Session.SetString("TestFormFieldList", JsonSerializer.Serialize(new List<TestFormFieldModel>()));
            return Json(true);
        }
    }
}
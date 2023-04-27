namespace FormApp.MVC.Models
{
    public class TestFormModel
    {
        public TestFormModel()
        {
            FieldModels = new List<TestFormFieldModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public List<TestFormFieldModel> FieldModels { get; set; }
    }
}

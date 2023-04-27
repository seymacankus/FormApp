using System.ComponentModel.DataAnnotations;

namespace FormApp.MVC.Models
{
    public class TestFormFieldModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool Required { get; set; }
        public int TestFormId { get; set; }
    }
}

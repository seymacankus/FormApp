using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Entity
{
    public class TestFormField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool Required { get; set; }
        public int TestFormId { get; set; }
        public TestForm TestForm { get; set; }
    }
}

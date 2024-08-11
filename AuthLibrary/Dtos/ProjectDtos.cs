using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Dtos
{
    public class ProjectDtos
    {
        public  int Project_Id { get; set; }
        public  string Project_Name { get; set; }
        public  string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}

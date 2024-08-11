using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace AuthLibrary.Dtos
{
    public class TasksDtos
    {
        public int? Project_Id { get; set; }
        public int Task_Id { get; set; }
        public string Task_Name { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }

         
       
         
         
    }
}

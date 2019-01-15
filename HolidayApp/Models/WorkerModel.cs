using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class WorkerModel
    {
        
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public int HolidaysLeft { get; set; }
       


}
}
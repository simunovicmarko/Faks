using System;
using System.ComponentModel.DataAnnotations;

namespace DRS_Simunovic.Models
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimal) : base(typeof(DateTime), minimal, DateTime.Now.AddDays(-1).ToShortDateString())
        { }
    }
}

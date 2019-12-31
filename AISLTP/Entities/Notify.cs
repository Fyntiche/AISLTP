using System;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Notify
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Lico Lico { get; set; }
        public string Content { get; set; }
    }
}
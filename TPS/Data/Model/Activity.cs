using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS.Data.Model
{
    public class Activity
    {
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } 

        public Activity(string name, DateTime timestamp){
            Name = name;
            Timestamp = timestamp;
        }
        
    }
}
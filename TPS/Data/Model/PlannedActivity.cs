using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS.Data.Model
{
    // Maybe leave only Activity.cs with bool to check if it's planned? I'm a bit confused
    public class PlannedActivity
    {
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public virtual HashSet<Activity>? Activities { get; set; }

        public PlannedActivity(string name, bool status){
            Name = name;
            Status = status;
        }
        
    }
}
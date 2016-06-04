using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Models
{
    public class TaskModel:IModel
    {      
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}

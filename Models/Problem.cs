using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWorks_TestToo.Models
{
    public class Problem { 
        public string Description { get; set; }
        public DateTime CompletionTime { get; set; }
        public DateTime InputTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSimpleCommandExecutor.Models
{
    public class StartTaskViewModel
    {
        [Required]
        [MinLength(3)]
        public  string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Params { get; set; }
    }
}
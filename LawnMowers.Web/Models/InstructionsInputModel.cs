using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lawnmowers.Web.Models
{
    public class InstructionsInputModel
    {
        [Required(ErrorMessage = "You must provide some intructions for the lawn mowers!")]
        [DisplayName("Input instructions")]
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }
    }
}
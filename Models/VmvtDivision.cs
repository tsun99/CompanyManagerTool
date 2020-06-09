using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagerTool.Models
{
    public class VmvtDivision
    {
        [Key]
        public int Id { get; set; }

        public string vmvtDivision { get; set; }
    }
}

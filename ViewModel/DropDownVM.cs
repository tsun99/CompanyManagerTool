using CompanyManagerTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagerTool.ViewModel
{
    public class DropDownVM : Company
    {
        public List<VmvtDivision> VmvtDropDownList { get; set; }
    }
}

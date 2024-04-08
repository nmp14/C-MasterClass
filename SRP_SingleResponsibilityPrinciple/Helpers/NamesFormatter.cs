using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SingleResponsibilityPrinciple.Helpers
{
    class NamesFormatter
    {
        public string Format(List<string> names)
        {
            return string.Join(Environment.NewLine + "-----" + Environment.NewLine, names);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [AttributeUsage(AttributeTargets.Property)]
    class HeaderAttribute:Attribute
    {
        public string Name;

        public HeaderAttribute(string varname)
        {
            this.Name = varname;
        }
    }
}

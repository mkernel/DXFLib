using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [AttributeUsage(AttributeTargets.Class)]
    class EntityAttribute : Attribute
    {
        public string EntityName;
        public EntityAttribute(string Name)
        {
            this.EntityName = Name;
        }
    }
}

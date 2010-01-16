using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [AttributeUsage(AttributeTargets.Property)]
    class TableAttribute : Attribute
    {
        public string TableName;
        public Type TableParser;

        public TableAttribute(string name, Type parser)
        {
            this.TableName = name;
            this.TableParser = parser;
        }
    }
}

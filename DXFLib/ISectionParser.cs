using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    interface ISectionParser
    {
        void ParseGroupCode(DXFDocument doc, int groupcode, string value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    class ClassParser:ISectionParser
    {
        private DXFClass currentClass;
        #region ISectionParser Member

        public void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            switch (groupcode)
            {
                case 0:
                    currentClass = new DXFClass();
                    doc.Classes.Add(currentClass);
                    break;
                case 1:
                    currentClass.DXFRecord = value;
                    break;
                case 2:
                    currentClass.ClassName = value;
                    break;
                case 3:
                    currentClass.AppName = value;
                    break;
                case 90:
                    currentClass.ClassProxyCapabilities = (DXFClass.Caps)Enum.Parse(typeof(DXFClass.Caps), value);
                    break;
                case 280:
                    if (int.Parse(value) != 0)
                        currentClass.WasProxy = true;
                    else
                        currentClass.WasProxy = false;
                    break;
                case 281:
                    if (int.Parse(value) != 0)
                        currentClass.IsEntity = true;
                    else
                        currentClass.IsEntity = false;
                    break;
            }
        }

        #endregion
    }
}

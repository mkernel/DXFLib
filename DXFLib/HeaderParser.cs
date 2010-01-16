using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DXFLib
{
    class HeaderParser: ISectionParser
    {
        private Dictionary<string, PropertyInfo> fields = new Dictionary<string, PropertyInfo>();
        #region ISectionParser Member

        PropertyInfo currentVar = null;
        public void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            if (fields.Count == 0)
            {
                Type header = doc.Header.GetType();
                foreach (PropertyInfo info in header.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (info.CanWrite && info.CanRead)
                    {
                        object[] attrs = info.GetCustomAttributes(true);
                        foreach (object attr in attrs)
                        {
                            HeaderAttribute casted = attr as HeaderAttribute;
                            if (casted != null)
                            {
                                fields[casted.Name] = info;
                            }
                        }
                    }
                }
            }

            if (groupcode == 9)
            {
                string name = value.Trim();
                if (fields.ContainsKey(name))
                {
                    currentVar = fields[name];
                }
                else
                {
                    currentVar = null;
                }
            }
            else if(currentVar!=null)
            {
                //at first we need to differentiate the types: nullable vs string and nullable vs rest
                if (currentVar.PropertyType.Equals(typeof(string)))
                {
                    currentVar.SetValue(doc.Header, value, null);
                }
                else if (currentVar.PropertyType.IsGenericType && currentVar.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    Type boxedType = currentVar.PropertyType.GetGenericArguments()[0];
                    if(boxedType.Equals(typeof(int)))
                    {
                        int? parsed;
                        if (value.ToLower().Contains('a') ||
                            value.ToLower().Contains('b') ||
                            value.ToLower().Contains('c') ||
                            value.ToLower().Contains('d') ||
                            value.ToLower().Contains('e') ||
                            value.ToLower().Contains('f'))
                        {
                            parsed = int.Parse(value, System.Globalization.NumberStyles.HexNumber);
                        }
                        else
                            parsed = int.Parse(value, System.Globalization.NumberStyles.Any);
                        currentVar.SetValue(doc.Header, parsed, null);
                    }
                    else if(boxedType.Equals(typeof(double)))
                    {
                        double? parsed = double.Parse(value);
                        currentVar.SetValue(doc.Header, parsed, null);
                    }
                    else if (boxedType.Equals(typeof(bool)))
                    {
                        int? parsed = int.Parse(value);
                        if (parsed != 0)
                            currentVar.SetValue(doc.Header, (bool?)true, null);
                        else
                            currentVar.SetValue(doc.Header, (bool?)false, null);
                    }
                    else if (boxedType.IsEnum)
                    {
                        object parsed = Enum.Parse(boxedType, value);
                        currentVar.SetValue(doc.Header, parsed, null);
                    }
                }
                else if (currentVar.PropertyType.Equals(typeof(DXFPoint)))
                {
                    DXFPoint p = (DXFPoint)currentVar.GetValue(doc.Header, null);
                    if (p == null)
                    {
                        p = new DXFPoint();
                        currentVar.SetValue(doc.Header, p, null);
                    }
                    switch (groupcode)
                    {
                        case 10:
                            p.X = double.Parse(value);
                            break;
                        case 20:
                            p.Y = double.Parse(value);
                            break;
                        case 30:
                            p.Z = double.Parse(value);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #endregion
    }
}

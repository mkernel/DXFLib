using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DXFLib
{
    class TableParser: ISectionParser
    {
        private Dictionary<string, ISectionParser> tablehandlers = new Dictionary<string, ISectionParser>();
        #region ISectionParser Member

        private ISectionParser currentParser = null;
        private bool waitingtableheader = false;
        private bool ignoretable = false;
        private bool firstrecordfound = false;
        public void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            if (tablehandlers.Count == 0)
            {
                foreach (PropertyInfo info in doc.Tables.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    object[] attrs = info.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        TableAttribute casted = attr as TableAttribute;
                        if (casted != null)
                        {
                            tablehandlers[casted.TableName] = (ISectionParser)Activator.CreateInstance(casted.TableParser);
                        }
                    }
                }
            }
            if (currentParser == null)
            {
                if (groupcode == 0 && value.Trim() == "TABLE")
                {
                    waitingtableheader = true;
                }
                else if (waitingtableheader && groupcode == 2 && !ignoretable)
                {
                    if (tablehandlers.ContainsKey(value.Trim()))
                    {
                        currentParser = tablehandlers[value.Trim()];
                        waitingtableheader = false;
                        ignoretable = false;
                        firstrecordfound = false;
                    }
                    else
                    {
                        //TODO: generate warning 
                        ignoretable = true;
                    }
                }
                else if (waitingtableheader && groupcode == 0 && value.Trim() == "ENDTAB")
                {
                    waitingtableheader = false;
                    ignoretable = false;
                }
            }
            else
            {
                if (groupcode == 0 && value.Trim() == "ENDTAB")
                {
                    currentParser = null;
                }
                else
                {
                    if (groupcode == 0)
                    {
                        firstrecordfound = true;
                    }
                    if (firstrecordfound)
                        currentParser.ParseGroupCode(doc, groupcode, value);
                }
            }
        }

        #endregion
    }

    public class DXFRecord
    {
        public string Handle { get; set; }
        public string DimStyleHandle { get; set; }
        List<string> classhierarchy = new List<string>();
        public List<string> Classhierarchy { get { return classhierarchy; } }

        public int Flags { get; set; }

    }

    abstract class DXFRecordParser : ISectionParser
    {
        protected abstract DXFRecord currentRecord { get; }

        protected abstract void createRecord(DXFDocument doc);
        #region ISectionParser Member

        public virtual void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            switch (groupcode)
            {
                case 0:
                    createRecord(doc);
                    break;
                case 5:
                    currentRecord.Handle = value;
                    break;
                case 70:
                    currentRecord.Flags = int.Parse(value);
                    break;
                case 105:
                    currentRecord.DimStyleHandle = value;
                    break;
                case 100:
                    currentRecord.Classhierarchy.Add(value);
                    break;
            }
        }

        #endregion
    }


}

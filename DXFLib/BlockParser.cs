using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    class BlockParser:ISectionParser
    {
        #region ISectionParser Member

        private DXFBlock current = null;
        private bool parsingBlock = false;
        private EntityParser parser = new EntityParser();
        private DXFDocument container;
        public static List<string> groups = new List<string>();
        public void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            if (groupcode == 0)
            {
                if (current == null)
                    groups.Add(value + " OUTSIDE");
                else
                    groups.Add(value);
            }
            if (current == null)
            {
                if (groupcode == 0 && value == "BLOCK")
                {
                    current = new DXFBlock();
                    container = new DXFDocument();
                    parsingBlock = true;
                }
            }
            else
            {
                if (parsingBlock)
                {
                    if (groupcode == 0 && value == "ENDBLK")
                    {
                        current.Children.AddRange(container.Entities);
                        doc.Blocks.Add(current);
                        current = null;
                        container = null;
                    }
                    else if (groupcode == 0)
                    {
                        parsingBlock = false;
                        parser.ParseGroupCode(container, groupcode, value);
                    }
                    else
                        current.ParseGroupCode(groupcode, value);
                }
                else
                {
                    if (groupcode == 0 && value == "ENDBLK")
                    {
                        current.Children.AddRange(container.Entities);
                        doc.Blocks.Add(current);
                        current = null;
                        container = null;
                    }
                    else
                    {
                        parser.ParseGroupCode(container, groupcode, value);
                    }
                }
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry.Variables
{

    [XmlRoot(ElementName = "VariableTable")]
    public class VariableTable : Variable
    {

        public class VariableTableRow
        {

            [XmlArrayItem(ElementName = "VariableScalar", Type = typeof(VariableScalar))]
            [XmlArrayItem(ElementName = "VariableList", Type = typeof(VariableList))]
            [XmlArrayItem(ElementName = "VariableTable", Type = typeof(VariableTable))]
            public List<Variable> Values { get; set; } = new List<Variable>();

        }

        public List<VariableTableRow> Rows { get; set; } = new List<VariableTableRow>();

        public int Width
        {
            get
            {
                return Rows != null && Rows.Count > 0 ? Rows[0].Values.Count : 0;
            }
        }

        public int Height
        {
            get
            {
                return Rows != null ? Rows.Count : 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 1; y <= Height; y++)
            {
                List<string> temp = new List<string>();
                for (int x = 1; x <= Width; x++)
                {
                    temp.Add(Peek(x, y).ToString());
                }
                sb.AppendLine(String.Join(",", temp));
            }
            return sb.ToString();
        }

        public override int CompareTo(object o)
        {
            if ((o is Variable) == false)
            {
                throw new InvalidOperationException();
            }
            if (o is VariableScalar)
            {
                return 1;
            }
            if (o is VariableList)
            {
                return 1;
            }
            if (o is VariableDictionary)
            {
                return 1;
            }
            if (o is VariableTable)
            {
                VariableTable vt = (VariableTable)o;                
                if (Height < vt.Height)
                {
                    return -1;
                }
                if (Height > vt.Height)
                {
                    return 1;
                }
                if (Width < vt.Width)
                {
                    return -1;
                }
                if (Width > vt.Width)
                {
                    return 1;
                }
                int res;
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        res = Peek(x, y).CompareTo(vt.Peek(x, y));
                        if (res != 0)
                        {
                            return res;
                        }
                    }
                }
                return 0;
            }
            return -1;
        }

        public override Variable Duplicate()
        {
            VariableTable v = new VariableTable();
            v.Resize(Width, Height);
            for (int y = 1; y <= Height; y++)
            {
                for (int x = 1; x <= Width; x++)
                {
                    v.Set(x, y, Peek(x, y).Duplicate(), LastChanger);
                }
            }
            v.LastChanger = LastChanger;
            v.LastChanged = LastChanged;
            return v;
        }

        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth == 0 || newHeight == 0)
            {
                Rows.Clear();
                return;
            }
            if (newWidth == -1)
            {
                newWidth = Width;
            }
            if (newHeight == -1)
            {
                newHeight = Height;
            }
            int oldWidth = Width;
            if (Height < newHeight)
            {
                while (Height < newHeight)
                {
                    VariableTableRow vtr = new VariableTableRow();
                    vtr.Values.AddRange(new Variable[newWidth]);
                    Rows.Add(vtr);
                }
            }
            else if (Height > newHeight)
            {
                int num = Height - newHeight;
                Rows.RemoveRange(Height - num, num);
            }
            if (newWidth != oldWidth)
            {
                for (int i = 0; i < Height; i++)
                {
                    if (Rows[i].Values.Count > newWidth)
                    {
                        int num = Rows[i].Values.Count - newWidth;
                        Rows[i].Values.RemoveRange(Rows[i].Values.Count - num, num);
                    }
                    else if (Rows[i].Values.Count < newWidth)
                    {
                        Rows[i].Values.AddRange(new Variable[newWidth - Rows[i].Values.Count]);
                    }
                }
            }
        }

        public void Set(int x, int y, string value, string changer)
        {
            InternalSet(x, y, new VariableScalar() { Value = value }, changer);
        }

        public void Set(int x, int y, Variable value, string changer)
        {
            Variable nv = value.Duplicate();
            InternalSet(x, y, nv, changer);
        }

        private void InternalSet(int x, int y, Variable value, string changer)
        {
            x--;
            y--;
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return;
            }
            Rows[y].Values[x] = value;
            LastChanger = changer;
            LastChanged = DateTime.Now;
        }

        public Variable Peek(int x, int y)
        {
            x--;
            y--;
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return new VariableScalar();
            }
            Variable v = Rows[y].Values[x];
            return v != null ? v : new VariableScalar();
        }

        public void Append(VariableTable vt, string changer)
        {
            if (vt.Height == 0)
            {
                return;
            }
            int mx = Math.Max(Width, vt.Width);
            int my = Height;
            Resize(mx, Height + vt.Height);
            for (int y = 0; y < vt.Height; y++)
            {
                for (int x = 0; x < vt.Width; x++)
                {
                    Rows[my].Values[x] = vt.Rows[y].Values[x];
                }
                my++;
            }
            LastChanger = changer;
            LastChanged = DateTime.Now;
        }

        public int SeekRow(string value)
        {
            return SeekRow(new VariableScalar() { Value = value });
        }

        public int SeekRow(Variable value)
        {
            if (Height == 0)
            {
                return 0;
            }
            for (int y = 0; y < Height; y++)
            {
                if (Rows[y].Values[0].CompareTo(value) == 0)
                {
                    return y + 1;
                }
            }
            return 0;
        }

        public int SeekColumn(string value)
        {
            return SeekColumn(new VariableScalar() { Value = value });
        }

        public int SeekColumn(Variable value)
        {
            if (Height == 0)
            {
                return 0;
            }
            for (int x = 0; x < Width; x++)
            {
                if (Rows[0].Values[x].CompareTo(value) == 0)
                {
                    return x + 1;
                }
            }
            return 0;
        }

        public void InsertRow(int index)
        {
            Resize(Width > 0 ? Width : 1, Height + 1);
            for (int y = Height - 1; y > index; y--)
            {
                Rows[y] = Rows[y - 1];
            }
            if (index >= Height)
            {
                index = Height - 1;
            }
            VariableScalar[] vs = new VariableScalar[Width];
            Rows[index] = new VariableTableRow();
            Rows[index].Values = new List<Variable>();
            Rows[index].Values.AddRange(vs);
        }

        public void RemoveRow(int index)
        {
            for (int y = index; y < Height - 1; y++)
            {
                Rows[y] = Rows[y + 1];
            }
            Resize(Width, Height - 1);
        }

        public void InsertColumn(int index)
        {
            Resize(Width + 1, Height > 0 ? Height : 1);
            for (int y = 0; y < Height; y++)
            {
                for (int x = Width - 1; x > index; x--)
                {
                    Rows[y].Values[x] = Rows[y].Values[x - 1];
                }
                if (index >= Width)
                {
                    index = Width - 1;
                }
                Rows[y].Values[index] = new VariableScalar();
            }
        }

        public void RemoveColumn(int index)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = index; x < Width - 1; x++)
                {
                    Rows[y].Values[x] = Rows[y].Values[x + 1];
                }
            }
            Resize(Width - 1, Height);
        }

    }

}

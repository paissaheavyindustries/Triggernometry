using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        public void Resize(int newWidth, int newHeight, string changer = "")
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
                    var emptyRow = new VariableTableRow();
                    for (int i = 0; i < newWidth; i++)
                    {
                        emptyRow.Values.Add(new VariableScalar());
                    }
                    Rows.Add(emptyRow);
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
                        int num = newWidth - Rows[i].Values.Count;
                        for (int j = 0; j < num; j++)
                        {
                            Rows[i].Values.Add(new VariableScalar());
                        }
                    }
                }
            }
            LastChanged = DateTime.Now;
            LastChanger = changer;
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
        
        private int ProcessColIndex(int rawIndex)
        {   // rawIndex: starts from 1; could be negative
            return (rawIndex < 0) ? (rawIndex + Width) : (rawIndex - 1);
        }
        
        private int ProcessRowIndex(int rawIndex)
        {   // rawIndex: starts from 1; could be negative
            return (rawIndex < 0) ? (rawIndex + Height) : (rawIndex - 1);
        }

        private void InternalSet(int x, int y, Variable value, string changer)
        {
            x = ProcessColIndex(x);
            y = ProcessRowIndex(y);
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
            x = ProcessColIndex(x);
            y = ProcessRowIndex(y);
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return new VariableScalar();
            }
            Variable v = Rows[y].Values[x];
            return v != null ? v : new VariableScalar();
        }

        public void AppendVertical(VariableTable vt, string changer)
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

        public void AppendHorizontal(VariableTable vt, string changer)
        {
            if (vt.Width == 0)
            {
                return;
            }
            int newWidth = Width + vt.Width;
            int maxHeight = Math.Max(Height, vt.Height);
            Resize(newWidth, maxHeight);

            for (int y = 0; y < vt.Height; y++)
            {
                for (int x = 0; x < vt.Width; x++)
                {
                    Rows[y].Values[Width - vt.Width + x] = vt.Rows[y].Values[x];
                }
            }
            LastChanger = changer;
            LastChanged = DateTime.Now;
        }

        public int SeekRow(Variable value)
        {
            return SeekRow(value.ToString());
        }

        public int SeekRow(string value)
        {
            if (Height == 0)
            {
                return 0;
            }
            for (int y = 0; y < Height; y++)
            {
                if (Rows[y].Values[0].ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return y + 1;
                }
            }
            return 0;
        }

        public int SeekColumn(Variable value)
        {
            return SeekColumn(value.ToString());
        }

        public int SeekColumn(string value)
        {
            if (Height == 0)
            {
                return 0;
            }
            for (int x = 0; x < Width; x++)
            {
                if (Rows[0].Values[x].ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return x + 1;
                }
            }
            return 0;
        }

        public int VLookup(Variable targetStr, int rowIndex, List<int> colIndices)
        {
            return VLookup(targetStr.ToString(), rowIndex, colIndices);
        }

        public int VLookup(string targetStr, int colIndex, List<int> rowIndices)
        {
            if (colIndex < 0 || colIndex >= Width)
            {
                return 0;
            }

            foreach (int rowIndex in rowIndices)
            {
                if (Rows[rowIndex].Values[colIndex].ToString().Equals(targetStr, StringComparison.OrdinalIgnoreCase))
                {
                    return rowIndex + 1;
                }
            }
            return 0;
        }

        public int HLookup(Variable targetStr, int rowIndex, List<int> colIndices)
        {
            return HLookup(targetStr.ToString(), rowIndex, colIndices);
        }

        public int HLookup(string targetStr, int rowIndex, List<int> colIndices)
        {
            if (rowIndex < 0 || rowIndex >= Height)
            {
                return 0;
            }

            foreach (int colIndex in colIndices)
            {
                if (Rows[rowIndex].Values[colIndex].ToString().Equals(targetStr, StringComparison.OrdinalIgnoreCase))
                {
                    return colIndex + 1;
                }
            }
            return 0;
        }

        public string ToCSVString(string colJoiner = ",")
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 1; y <= Height; y++)
            {
                List<string> temp = new List<string>();
                for (int x = 1; x <= Width; x++)
                {
                    string tempStr = Peek(x, y).ToString();
                    if (tempStr.Contains(',') || tempStr.Contains('"') || tempStr.Contains('\n') || tempStr.Contains('\r'))
                    {
                        tempStr = "\"" + tempStr.Replace("\"", "\"\"") + "\"";
                    }
                    temp.Add(tempStr);
                }
                sb.AppendLine(String.Join(colJoiner, temp));
            }
            return sb.ToString().TrimEnd('\r', '\n');
        }

        public override string ToString()
        {
            return String.Join("|", Rows.Select(row => string.Join(",", row.Values)));
        }

        public double Sum(List<int> colIndices, List<int> rowIndices)
        {
            double sum = 0;
            foreach (int x in colIndices)
            {
                foreach (int y in rowIndices)
                {
                    if (double.TryParse(Rows[y].Values[x].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                        sum += value;
                }
            }
            return sum;
        }

        public string VJoin(string joiner1, string joiner2, List<int> colSlices, List<int> rowSlices)
        {
            List<string> cols = new List<string>();

            foreach (int colIndex in colSlices)
            {
                List<string> rows = new List<string>();

                foreach (int rowIndex in rowSlices)
                {
                    rows.Add(Rows[rowIndex].Values[colIndex].ToString());
                }

                cols.Add(String.Join(joiner1, rows));
            }

            return String.Join(joiner2, cols);
        }

        public string HJoin(string joiner1, string joiner2, List<int> colSlices, List<int> rowSlices)
        {
            List<string> rows = new List<string>();

            foreach (int rowIndex in rowSlices)
            {
                List<string> cols = new List<string>();

                foreach (int colIndex in colSlices)
                {
                    cols.Add(Rows[rowIndex].Values[colIndex].ToString());
                }

                rows.Add(String.Join(joiner1, cols));
            }

            return String.Join(joiner2, rows);
        }

        public void SetRow(int index, string[] newValues = null, string changer = "")
        {   // index starts from 0
            newValues = newValues ?? new string[0];
            int mx = Math.Max(Math.Max(newValues.Length, Width), 1);
            int my = Math.Max(index + 1, Height);
            if (mx != Width || my != Height)
            {
                Resize(mx, my);
            }

            for (int x = 0; x < mx; x++)
            {
                Set(x + 1, index + 1, ((x < newValues.Length) ? newValues[x] : ""), changer);
            }
            if (changer != "")
            {
                LastChanger = changer;
                LastChanged = DateTime.Now;
            }
        }

        public void SetColumn(int index, string[] newValues = null, string changer = "")
        {
            // index starts from 0
            newValues = newValues ?? new string[0];

            int mx = Math.Max(index + 1, Width);
            int my = Math.Max(Math.Max(newValues.Length, Height), 1);
            if (mx != Width || my != Height)
            {
                Resize(mx, my);
            }

            for (int y = 0; y < my; y++)
            {
                Set(index + 1, y + 1, ((y < newValues.Length) ? newValues[y] : ""), changer);
            }
            if (changer != "")
            {
                LastChanger = changer;
                LastChanged = DateTime.Now;
            }
        }

        public void InsertRow(int index, string[] newValues = null, string changer = "")
        {   // index starts from 0
            newValues = newValues ?? new string[0];
            if (index >= Height)
            {   
                SetRow(index, newValues, changer);
            }
            else
            {
                int mx = Math.Max(Math.Max(newValues.Length, Width), 1);
                Resize(mx, Height + 1);
                for (int y = Height - 1; y > index; y--)
                {
                    Rows[y] = Rows[y - 1];
                }
                VariableScalar[] vs = new VariableScalar[Width];
                for (int x = 0; x < Width; x++)
                {
                    vs[x] = (x < newValues.Length) ? new VariableScalar { Value = newValues[x] } 
                                                   : new VariableScalar();
                }

                Rows[index] = new VariableTableRow();
                Rows[index].Values = new List<Variable>();
                Rows[index].Values.AddRange(vs);
            }
            if (changer != "")
            {
                LastChanger = changer;
                LastChanged = DateTime.Now;
            }
        }

        public void InsertColumn(int index, string[] newValues = null, string changer = "")
        {   // index starts from 0
            newValues = newValues ?? new string[0];
            if (index >= Width)
            {
                SetColumn(index, newValues, changer);
            }
            else 
            {
                int my = Math.Max(Math.Max(newValues.Length, Height), 1);
                Resize(Width + 1, my);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = Width - 1; x > index; x--)
                    {
                        Rows[y].Values[x] = Rows[y].Values[x - 1];
                    }
                    Rows[y].Values[index] = (y < newValues.Length) ? new VariableScalar { Value = newValues[y] }
                                                                   : new VariableScalar();
                }
            }
            if (changer != "")
            {
                LastChanger = changer;
                LastChanged = DateTime.Now;
            }
        }

        public void RemoveRow(int index, string changer = "")
        {   // index starts from 0
            if (index < 0 || index >= Height) { return; }
            for (int y = index; y < Height - 1; y++)
            {
                Rows[y] = Rows[y + 1];
            }
            Resize(Width, Height - 1);
            if (changer != "")
            {
                LastChanger = changer;
                LastChanged = DateTime.Now;
            }
        }

        public void RemoveColumn(int index, string changer = "")
        {   // index starts from 0
            if (index < 0 || index >= Width) { return; }
            for (int y = 0; y < Height; y++)
            {
                for (int x = index; x < Width - 1; x++)
                {
                    Rows[y].Values[x] = Rows[y].Values[x + 1];
                }
            }
            Resize(Width - 1, Height);
            if (changer != "")
            {
                LastChanger = changer;
                LastChanged = DateTime.Now;
            }
        }

        public int Count(string str, List<int> colIndices, List<int> rowIndices)
        {
            int count = 0;
            foreach (int y in rowIndices)
            { 
                count += colIndices.Count(x => Rows[y].Values[x].ToString() == str);
            }
            return count;
        }

        public static VariableTable Build(string expression, char colSeparator, char rowSeparator, string changer)
        {   // in actions
            string[] rowStrings = expression.Split(rowSeparator);
            List<string[]> cellStrings = new List<string[]>();
            int width = 0;
            int height = rowStrings.Length;
            foreach (string row in rowStrings)
            {
                string[] cells = row.Split(colSeparator);
                cellStrings.Add(cells);
                width = Math.Max(width, cells.Length);
            }
            VariableTable vt = ActualBuild(cellStrings, width, height);
            vt.LastChanger = changer;
            vt.LastChanged = DateTime.Now;
            return vt;
        }

        public static VariableTable BuildTemp(string expression)
        {   // in expressions: ${?t: 1, 2 | 3, 4 | 5, 6 [xxx][xxx]}
            string[] rowStrings = Context.SplitArguments(expression, separator: "|");
            List<string[]> cellStrings = new List<string[]>();
            int width = 0;
            int height = rowStrings.Length;
            foreach (string row in rowStrings)
            {
                string[] cells = Context.SplitArguments(row);
                cellStrings.Add(cells);
                width = Math.Max(width, cells.Length);
            }
            return ActualBuild(cellStrings, width, height);
        }

        private static VariableTable ActualBuild(List<string[]> cellStrings, int width, int height)
        {
            VariableTable vt = new VariableTable();
            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            {
                vt.Rows.Add(new VariableTableRow());
                for (int colIndex = 0; colIndex < width; colIndex++)
                {
                    vt.Rows[rowIndex].Values.Add(
                        (colIndex < cellStrings[rowIndex].Length)
                        ? new VariableScalar { Value = cellStrings[rowIndex][colIndex] }
                        : new VariableScalar());
                }
            }
            return vt;
        }

    }

}

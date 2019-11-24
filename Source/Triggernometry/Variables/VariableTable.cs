using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry.Variables
{

    public class VariableTable : Variable
    {

        public Variable[][] Values = null;

        public int Width
        {
            get
            {
                return Values != null && Values.Length > 0 ? Values[0].Length : 0;
            }
        }

        public int Height
        {
            get
            {
                return Values != null ? Values.Length : 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                List<string> temp = new List<string>();
                for (int x = 0; x < Width; x++)
                {
                    Peek(x, y).ToString();
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
            for (int y=0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
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
                Values = null;
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
            if (Height != newHeight)
            {
                int oldHeight = Height;
                Array.Resize<Variable[]>(ref Values, newHeight);
                while (oldHeight < newHeight)
                {
                    Values[oldHeight] = new Variable[newWidth];
                    oldHeight++;
                }
            }
            if (newWidth != oldWidth)
            {
                for (int i = 0; i < Height; i++)
                {
                    if (Values[i].Length != newWidth)
                    {
                        Array.Resize<Variable>(ref Values[i], newWidth);
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
            Values[y][x] = value;
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
            Variable v = Values[y][x];
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
                    Values[my][x] = vt.Values[y][x];
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
                if (Values[y][0].CompareTo(value) == 0)
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
                if (Values[0][x].CompareTo(value) == 0)
                {
                    return x + 1;
                }
            }
            return 0;
        }

    }

}

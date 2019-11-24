using System;

namespace Triggernometry.Variables
{

    public abstract class Variable : IComparable
    {

        public string LastChanger { get; set; } = "N/A";

        public DateTime LastChanged { get; set; } = DateTime.Now;

        public abstract int CompareTo(object o);

        public abstract Variable Duplicate();

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBOT.Arena.Base
{
    public class CurrentMaximum
    {
        public int Current { get; set; }
        public int Maximum { get; set; }

        public CurrentMaximum() { }

        public CurrentMaximum(int value)
        {
            this.Current = value;
            this.Maximum = value;
        }

        public CurrentMaximum(int currentValue, int maxValue)
        {
            this.Current = currentValue;
            this.Maximum = maxValue;
        }

        public override string ToString()
            => $"{this.Current}/{this.Maximum}";
    }
}

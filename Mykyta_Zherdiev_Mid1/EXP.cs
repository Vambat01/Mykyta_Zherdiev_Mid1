using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mykyta_Zherdiev_Mid1
{
    class EXP
    {
        
        public string name { get; set; }
        //name of experiment
        public string mL { get; set; }
          //  name of ML method
        public int size { get; set; }
            // size of dataset
        public int num { get; set; }
             //number of test subjects
        public int indicator { get; set; }
        //indicator for mobile

        public EXP(string name, string mL, int size, int num, int indicator)
        {
            this.name = name;
            this.mL = mL;
            this.size = size;
            this.num = num;
            this.indicator = indicator;
        }
        public EXP(string str)
        {
            if (str == null)
                throw new ArgumentException("str == null");
            string[] ss = str.Split(' ');
            if (ss.Length != 5)
                throw new ArgumentException("ss.Length != 5");

            name = ss[0];
            mL = ss[1];
            size = int.Parse(ss[2]);
            num = int.Parse(ss[3]);
            indicator = int.Parse(ss[4]);
        }

        public override string ToString()
        {
            return String.Format("{0,-7} {1,12} {2,19} {3,19} {4,19}", name, mL, size, num, indicator);
        }
    }
}

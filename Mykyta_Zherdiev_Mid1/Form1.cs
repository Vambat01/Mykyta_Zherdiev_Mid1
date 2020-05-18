using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mykyta_Zherdiev_Mid1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string dashLine =
                    "-------------------------------------------------------------------------------------------------\r\n";
        string note =
                    "| Name of EX   |     Ml method    | Size of dataBase | number of sub    | indicator for mobile  |\r\n" +
                    "|--------------|------------------|------------------|------------------|-----------------------|";
        string fileOrigin = @"MachineLearning.txt";
        string fileRes = @"Result.txt";
        int indic = 0, newe = 0, n;
        EXP[] EXPS = new EXP[100];
        EXP[] NewE = new EXP[100];

        private void button1_Click(object sender, EventArgs e)
        {
            Read(fileOrigin, EXPS, out n);
            Print(fileRes, "Initial object collection: \r\n" + dashLine + note, EXPS, n);
            Print(fileRes, dashLine + $"Most test subjects were involved {EXPS[FindExperimentWithMostTS(EXPS, n, indic)]}" + dashLine, null, 0);
            CreateCollection(EXPS, n, NewE, ref newe, EXPS[0]);
            Print(fileRes, "Newcollection result: \r\n" + dashLine + note, NewE, newe);
            textBox1.Text = "Clicked!";//it was create just to see that some calculations happend after click :)
        }
        private void Read(string filename, EXP[] EXPS, out int n)        {
            n = 0;
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != string.Empty)
                    {
                        EXPS[n] = new EXP(line);
                        n++;
                    }
                }
            }
        }
        private void Print(string filename, string note, EXP[] EXPS, int n)
        {
            using (StreamWriter writer = File.AppendText(filename))
            {

                writer.WriteLine(note);
                for (int r = 0; r < n; r++)
                {
                    writer.WriteLine(EXPS[r].ToString());
                }
            }
        }
        private int FindExperimentWithMostTS(EXP[] EXPS, int n, int indic)
        {
            int pos = -1;
            for (int i = 0; i < n; i++)
                if (EXPS[i].indicator == indic)
                    if (pos == -1 || EXPS[pos].num < EXPS[i].num)
                        pos = i;
            return pos;
        }

        
        private void CreateCollection(EXP[] EXPS, int n, EXP[] NewE, ref int newe, EXP F)
        {
            newe = 0;
            for (int i = 0; i < n; i++)
            {
                if (F.size > EXPS[i].size)
                {
                    NewE[newe] = EXPS[i];
                    newe++;
                }
            }

        }
    }
}

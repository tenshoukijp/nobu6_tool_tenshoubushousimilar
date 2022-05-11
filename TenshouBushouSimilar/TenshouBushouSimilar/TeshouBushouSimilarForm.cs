using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TenshouBushouSimilar
{

    internal class TenshouBushouSimilarForm : Form
    {
        BushouBiographyAnalyzer bba = new BushouBiographyAnalyzer();

        Label lbFullName;
        TextBox tbFullName;

        Label lbBorn;
        TextBox tbBorn;

        Label lbDeath;
        TextBox tbDeath;

        Label lbBiography;
        TextBox tbBiography;

        Label lbResult;
        TextBox tbResult;

        const int PaddingMargin = 30;

        public TenshouBushouSimilarForm()
        {
            this.Width = 480;
            this.Height = 620;

            lbFullName = new Label
            {
                Text = "姓名",

                Left = PaddingMargin,
                Top = PaddingMargin,
                Width = 50,
                Height = 20
            };

            tbFullName = new TextBox
            {
                Text = "",

                Left = lbFullName.Right + 10,
                Top = PaddingMargin,

                Width = 100,
                Height = 20
            };

            lbBorn = new Label
            {
                Text = "誕生年",

                Left = tbFullName.Right + 10,
                Top = PaddingMargin,

                Width = 50
            };

            tbBorn = new TextBox
            {
                Text = "",

                Left = lbBorn.Right + 10,
                Top = PaddingMargin,

                Width = 50,
                Height = 20,

                ImeMode = ImeMode.Alpha
        };

            lbDeath = new Label
            {
                Text = "死亡年",

                Left = tbBorn.Right + 10,
                Top = PaddingMargin,

                Width = 50,
                Height = 20
            };

            tbDeath = new TextBox
            {
                Text = "",

                Left = lbDeath.Right + 10,
                Top = PaddingMargin,

                Width = 50,
                Height = 20,

                ImeMode = ImeMode.Alpha
            };

            lbBiography = new Label
            {
                Text = "列伝",

                Left = PaddingMargin,
                Top = lbFullName.Bottom + 30,

                Width = 50,
                Height = 20
            };

            tbBiography = new TextBox
            {
                Text = "",
                Multiline = true,
                Left = PaddingMargin,
                Top = lbBiography.Bottom,

                Width = 400,
                Height = 200
            };

            tbFullName.TextChanged += tb_BushouFullNameCanged;
            tbBorn.TextChanged += tb_BornChanged;
            tbDeath.TextChanged += tb_DeathCanged;
            tbBiography.TextChanged += tb_BiographyChanged;

            lbResult = new Label
            {
                Text = "結果",

                Left = PaddingMargin,
                Top = tbBiography.Bottom + 30,

                Width = 50,
                Height = 20
            };

            tbResult = new TextBox()
            {
                Text = "",
                Multiline = true,
                Left = PaddingMargin,
                Top = lbResult.Bottom,

                Width = 400,
                Height = 200
            };

            List<Control> controls = new List<Control> { lbFullName, tbFullName, lbBorn, tbBorn, lbDeath, tbDeath, lbBiography, tbBiography, lbResult, tbResult };
            foreach (var c in controls)
            {
                this.Controls.Add(c);
            }
        }


        public TenshouBushouSimilarForm(String strFullName, String bornADYear, String deathADYear, String strBiography) : this()
        {
            this.tbFullName.Text = strFullName;
            this.tbBorn.Text = bornADYear.ToString();
            this.tbDeath.Text = deathADYear.ToString();
            this.tbBiography.Text = strBiography;

            Console.WriteLine(tbResult.Text);
        }


        private List<double> bushouFullNamePoint = new List<double>();
        private void tb_BushouFullNameCanged(object sender, EventArgs e)
        {
            bushouFullNamePoint.Clear();

            var list = bba.GetPointByBushouNamePointList(tbFullName.Text);

            foreach(var l in list)
            {
                bushouFullNamePoint.Add(l);
            }

            CalculateAllPoint();
        }

        private List<double> bushouBornPoint = new List<double>();
        private void tb_BornChanged(object sender, EventArgs e)
        {
            bushouBornPoint.Clear();

            int iBornYear = -1;
            var bret = int.TryParse(tbBorn.Text, out iBornYear);
            // 0は認めない
            if (iBornYear == 0) { bret = false; }

            if (bret) {
                var list = bba.GetPointByBushouBornPoint(iBornYear);
                foreach (var l in list)
                {
                    bushouBornPoint.Add(l);
                }
            }

            CalculateAllPoint();
        }

        private List<double> bushouDeathPoint = new List<double>();
        private void tb_DeathCanged(object sender, EventArgs e)
        {
            bushouDeathPoint.Clear();

            int iDeathYear = -1;
            var dret = int.TryParse(tbDeath.Text, out iDeathYear);
            // 0は認めない
            if (iDeathYear == 0) { dret = false; }

            if (dret) { 
                var list = bba.GetPointByBushouDeathPoint(iDeathYear);

                foreach (var l in list)
                {
                    bushouDeathPoint.Add(l);
                }
            }

            CalculateAllPoint();
        }


        private List<double> bushouBiographyPoint = new List<double>();
        private void tb_BiographyChanged(object sender, EventArgs e)
        {
            bushouBiographyPoint.Clear();

            var list = bba.GetPointByBushouBiographyPoint(tbBiography.Text);

            foreach (var l in list)
            {
                bushouBiographyPoint.Add(l);
            }

            CalculateAllPoint();
        }

        // 得点計算
        private string CalculateAllPoint()
        {
            List<double> list = new List<double>();
            // 得点初期化
            for (int i = 0; i < bba.BushouBiographyList.Count; i++)
            {
                list.Add(0);
            }

            for (int i = 0; i < bba.BushouBiographyList.Count; i++)
            {
                // 名前による評価点
                if (bushouFullNamePoint.Count > 0)
                {
                    list[i] += bushouFullNamePoint[i];
                }

                // 生まれによる評価点
                if (bushouBornPoint.Count > 0)
                {
                    list[i] += bushouBornPoint[i];
                }

                if (bushouDeathPoint.Count > 0)
                {
                    list[i] += bushouDeathPoint[i];
                }


                // 列伝による評価点
                if (bushouBiographyPoint.Count > 0)
                {
                    list[i] += bushouBiographyPoint[i];
                }
            }

            List<KeyValuePair<int, double>> pairlist = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < list.Count; i++)
            {
                pairlist.Add(new KeyValuePair<int, double>(i, list[i]));
            }

            pairlist.Sort(
                (KeyValuePair<int, double> a, KeyValuePair<int, double> b) =>
                {
                    // まずは得点が高いもの
                    if (a.Value > b.Value) return -1;
                    if (a.Value < b.Value) return 1;
                    // 特典が同じ場合は、番号が若い者。若い番号には有名な武将が集まっている
                    if (a.Value == b.Value)
                    {
                        if (a.Key < b.Key) return -1;
                        if (a.Key > b.Key) return 1;
                    }
                    return 0;
                });


            int iusedcnt = 0;
            string format = "";
            foreach(var p in pairlist) 
            {
                int index = p.Key;
                double point = p.Value;
                if (point > 0)
                {
                    iusedcnt++;
                    format += String.Format("{0:0000}:{1:14}:{2:f4}\r\n", index, bba.BushouBiographyList[index].代表名, point);

                }
                if (iusedcnt > 10)
                {
                    break;
                }
            }
            tbResult.Text = format;
            return format;
        }
    }

    class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            TenshouBushouSimilarForm f = new TenshouBushouSimilarForm();
            if (args.Length == 4)
            {
                f = new TenshouBushouSimilarForm(args[0], args[1], args[2], args[3]);
            }
            else
            {
                f = new TenshouBushouSimilarForm();
                Application.Run(f);

            }
        }
    }
}

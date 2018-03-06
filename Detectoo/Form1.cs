using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detectoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList p_vals = new ArrayList();
        ArrayList l_vals = new ArrayList();
        double logMax = double.MinValue;
        double logMin = double.MaxValue;
        private void btnGo_Click(object sender, EventArgs e)
        {
            double[] log = new double[reoGridControl1.RowCount];
            double[] par = new double[reoGridControl1.RowCount];
            ArrayList parAve = new ArrayList();
            ArrayList logAve = new ArrayList();
            ArrayList parNum = new ArrayList();
            int rows = 0;
            for (int r = 0; r < reoGridControl1.RowCount - 1; r++)
            {
                rows = r;
                if (reoGridControl1.GetCellData(r + 1, cmbLog1.SelectedIndex) == null || reoGridControl1.GetCellData(r + 1, cmbLog2.SelectedIndex) == null)
                    break;
                log[r] = (double)reoGridControl1.GetCellData(r + 1, cmbLog1.SelectedIndex);
                if (reoGridControl1.GetCellData(r + 1, cmbLog2.SelectedIndex).ToString() == "")
                    par[r] = .05;
                else
                    par[r] = (double)reoGridControl1.GetCellData(r + 1, cmbLog2.SelectedIndex);
                if(parAve.Contains(par[r]))
                {
                    double l = double.Parse(logAve[parAve.IndexOf(par[r])].ToString());
                    int c = int.Parse(parNum[parAve.IndexOf(par[r])].ToString());
                    logAve[parAve.IndexOf(par[r])] = l + log[r];
                    parNum[parAve.IndexOf(par[r])] = c + 1;
                }
                else
                {
                    parAve.Add(par[r]);
                    logAve.Add(log[r]);
                    parNum.Add(1);
                }
            }
            double[] parAv = new double[parAve.Count];
            double[] logAv = new double[parAve.Count];
            for(int i=0;i<logAve.Count;i++)
            {
                double l = double.Parse(logAve[i].ToString());
                double p = double.Parse(parAve[i].ToString());
                double c = double.Parse(parNum[i].ToString());
                l = l / c;
                parAv[i] = p;
                logAv[i] = l;
            }
            Gridat.StatisticParam stp1 = new Gridat.StatisticParam((double[])logAv.Clone());
            Gridat.StatisticParam stp2 = new Gridat.StatisticParam((double[])parAv.Clone());
            double slope = 0;
            double x_a = 0;
            double y_a = 0;
            for (int i = 0; i < logAv.Length; i ++)
                if (par[i]>.05 )
                {
                    slope = slope + (logAv[i] - stp1.Average) * (parAv[i] - stp2.Average);
                    x_a = x_a + (logAv[i] - stp1.Average) * (logAv[i] - stp1.Average);
                    y_a = y_a + (parAv[i] - stp2.Average) * (parAv[i] - stp2.Average);
                }
            slope = slope / Math.Pow(x_a*y_a,.5);
                //transform
                if (slope < 0)
                    for (int i = 0; i < log.Length; i++)
                    {
                        log[i] = log.Max() - log[i]+log.Min();
                    }
                logMax = double.MinValue;
            logMin = double.MaxValue;
            p_vals = new ArrayList();
            l_vals = new ArrayList();
            for (int r = 0; r < rows; r++)
            {
                if (par[r] == 0) break;
                if (!p_vals.Contains(par[r]))
                {
                    p_vals.Add(par[r]);
                    l_vals.Add(new ArrayList());
                }
                ArrayList arr = (ArrayList)l_vals[p_vals.IndexOf(par[r])];
                arr.Add(log[r]);
                if (log[r] < logMin) logMin = log[r];
                if (log[r] > logMax) logMax = log[r];
            }


            if (chkCumul.Checked)
            {
                for (int i = 0; i < p_vals.Count - 1; i++)
                {
                    double pi = (double)p_vals[i];
                    ArrayList ari = (ArrayList)l_vals[i];
                    for (int j = i + 1; j < p_vals.Count; j++)
                    {
                        double pj = (double)p_vals[j];
                        ArrayList arj = (ArrayList)l_vals[j];

                        if (pi > pj)
                        {
                            double swap = (double)p_vals[i];
                            p_vals[i] = (double)p_vals[j];
                            p_vals[j] = swap;
                            pi = (double)p_vals[i];
                            //p_vals[i] = pj;
                            //p_vals[j] = pi;
                            ArrayList swapR = new ArrayList();
                            l_vals[i] = arj.Clone();
                            l_vals[j] = ari.Clone();
                            ari = (ArrayList)l_vals[i];
                        }
                    }
                }
                for(int i=0;i<l_vals.Count-1;i++)
                {
                    ArrayList ar1 = (ArrayList)l_vals[i];
                    ArrayList ar2 = (ArrayList)l_vals[i+1];
                    ar2.AddRange(ar1);
                }
            }
            
            double t = (logMax - logMin) / 20;
            logMin = logMin - t;
            logMax = logMax + t;
            tabControl1.SelectedIndex = 1;
           
        }

        private void reoGridControl1_DoubleClick(object sender, EventArgs e)
        {
            reoGridControl1.Paste();
            cmbLog1.Items.Clear();
            cmbLog2.Items.Clear();
            for(int i=0;i<reoGridControl1.ColCount;i++)
            {
                if (reoGridControl1.GetCellData(0, i) == null) break;
                cmbLog1.Items.Add(reoGridControl1.GetCellData(0, i).ToString());
                cmbLog2.Items.Add(reoGridControl1.GetCellData(0, i).ToString());
            }
            cmbLog1.SelectedIndex = 1;
            cmbLog2.SelectedIndex = 21;
        }

        private void pnlAx_Resize(object sender, EventArgs e)
        {
            //pnlCh.Top = 12;
            pnlCh.Left = 40;
            pnlCh.Width = pnlAx.Width - 40;
            pnlCh.Height  = pnlAx.Height - 40;
            
        }

        private void pnlCh_Paint(object sender, PaintEventArgs e)
        {
            DrawArea(e.Graphics,float.Parse(pnlCh.Tag.ToString()));
        }
        private void DrawArea(Graphics g, float scale)
        {
            //Bitmap bmp = new Bitmap(pnlCh.Width, pnlCh.Height);
            //Graphics g = Graphics.FromImage(bmp);
            //PointF pPad = new PointF(0, 0);
            //if (pnlAx.Tag != null)
            //{
            //    pPad = (PointF)pnlAx.Tag;                
            //}
            int ht = (int)((float)pnlCh.Height * scale);
            int wh = (int)((float)pnlCh.Width * scale);
            g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, pnlCh.Width, pnlCh.Height), Color.MintCream, Color.LemonChiffon, 65f), 0, 0, wh - 1, ht - 1);
            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(new Pen(Color.LightGray, 1), 0, i * ht / 11, pnlCh.Width, i * ht / 11);
                g.DrawLine(new Pen(Color.Black, 1), 0, i * ht / 11, 4, i * ht / 11);
                g.DrawLine(new Pen(Color.Black, 1), pnlCh.Width - 5, i * ht / 11, pnlCh.Width, i * ht / 11);
                for (int j = 1; j < 5; j++)
                {
                    g.DrawLine(new Pen(Color.Black, 1), 0, (i * ht + j * ht / 5) / 11, 3, (i * ht + j * ht / 5) / 11);
                    g.DrawLine(new Pen(Color.Black, 1), pnlCh.Width - 3, (i * ht + j * ht / 5) / 11, pnlCh.Width, (i * ht + j * ht / 5) / 11);
                }
            }

            int dec = -(int)Math.Round(Math.Log10(logMax - logMin), 0);
            dec++;
            if (dec < 0) dec = 0;

            for (double d = logMin; d < logMax; d += (logMax - logMin) / 10)
            {
                g.DrawLine(new Pen(Color.LightGray, 1), (float)(wh * (d - logMin) / (logMax - logMin)), 0, (float)(wh * (d - logMin) / (logMax - logMin)), pnlCh.Height);
                g.DrawLine(new Pen(Color.Black, 1), (float)(wh * (d - logMin) / (logMax - logMin)), 0, (float)(wh * (d - logMin) / (logMax - logMin)), 4);
                g.DrawLine(new Pen(Color.Black, 1), (float)(wh * (d - logMin) / (logMax - logMin)), pnlCh.Height - 5, (float)(wh * (d - logMin) / (logMax - logMin)), pnlCh.Height);
                for (int j = 1; j < 5; j++)
                {
                    g.DrawLine(new Pen(Color.Black, 1), (float)(wh * (d - logMin + j * (logMax - logMin) / 50) / (logMax - logMin)), 0, (float)(wh * (d - logMin + j * (logMax - logMin) / 50) / (logMax - logMin)), 2);
                    g.DrawLine(new Pen(Color.Black, 1), (float)(wh * (d - logMin + j * (logMax - logMin) / 50) / (logMax - logMin)), pnlCh.Height - 3, (float)(wh * (d - logMin + j * (logMax - logMin) / 50) / (logMax - logMin)), pnlCh.Height);
                }
            }

            double[] par = new double[p_vals.Count];
            for (int i = 0; i < p_vals.Count; i++)
                par[i] = (double)p_vals[i];

            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.ZoomOutAll(zedGraphControl1.GraphPane);
            double[] probCur9 = new double[l_vals.Count];
            double[] probCurY9 = new double[l_vals.Count];
            double[] probCur7 = new double[l_vals.Count];
            double[] probCurY7 = new double[l_vals.Count];
            double[] probCur5 = new double[l_vals.Count];
            double[] probCurY5 = new double[l_vals.Count];
            string stmod = "";
            for (int y = 0; y < l_vals.Count; y++)
            {
                ArrayList arr = (ArrayList)l_vals[y];
                double[] log = new double[arr.Count];

                for (int i = 0; i < arr.Count; i++)
                    log[i] = (double)arr[i];


                ArrayList pt = new ArrayList();
                double[] zedPar = new double[log.Length];
                double[] zedLog = new double[log.Length];
                 
                Gridat.StatisticParam stp = new Gridat.StatisticParam(log);
                float pcv = (float)((stp.Average- logMin) * wh / (logMax - logMin));
                double mod = 0;
                int cmod = 0;
                for (int x = 0; x < log.Length; x ++)//= log.Length / 1000 + 1)
                {
                    float py = (float)(par[y] * ht / 110);
                    float px = (float)((log[x] - logMin) * wh / (logMax - logMin));
                    double ind = (log.Max() - log.Min()) / 24;
                    int c = 0;
                    for (int d = 0; d < log.Length; d++)
                        if (log[d] > log[x] - ind && log[d] < log[x] + ind) c++;
                    if(c>cmod)
                    {
                        cmod = c;
                        mod = log[x];
                    }
                    
                    c = 200 * c / log.Length;// reoGridControl1.RowCount;

                       
                   
                    //g.DrawLine(new Pen(Color.FromArgb(255, 0, 0, 0)), px , py , px , py + c / 10); 
                    //g.FillEllipse(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), px , py, c/10, c/10 );
                    //g.FillRectangle(new SolidBrush(Color.FromArgb(75, 0, 0, 0)), px , py - c * 2, 1, c * 2);
                    //g.DrawLine(new Pen(Color.FromArgb(255, y*225/par.Length , 0, 255-y*225/par.Length )), px-1, py - c /5, px, py - c /5);
                    //g.DrawLine(new Pen(Color.FromArgb(175, y * 225 / par.Length, 0, 255 - y * 225 / par.Length)), px - 10, py, px + 10, py);

                    int cp = 0;
                    for (cp = 0; cp < pt.Count; cp++)
                    {
                        PointF p = (PointF)pt[cp];
                        if (p.X < px)
                        {
                            pt.Insert(cp, new PointF(px, py + c / 5));

                            break;
                        }
                    }

                    if (cp == pt.Count) pt.Add(new PointF(px, py + c / 5));

                }

                stmod = stmod + mod.ToString() + "\t" + par[y].ToString() + "\r\n"; 
                for (int x = 0; x < log.Length; x++)//= log.Length / 1000 + 1)
                {
                    
                    if(Math.Round(GEV(log[x],stp.StdDev,mod),2) == .9)
                    {
                        float py = (float)(par[y] * ht / 110);
                        float px = (float)((log[x] - logMin) * wh / (logMax - logMin));
                        g.FillEllipse(new SolidBrush(Color.Red), px-2, py-2, 4, 4);
                        probCur9[y] = (double)px * (logMax - logMin) / wh + logMin; 
                        probCurY9[y] = (double)py;
                    }
                    if (Math.Round(GEV(log[x], stp.StdDev, mod), 2) == .7)
                    {
                        float py = (float)(par[y] * ht / 110);
                        float px = (float)((log[x] - logMin) * wh / (logMax - logMin));
                        g.FillEllipse(new SolidBrush(Color.Red), px - 2, py - 2, 4, 4);
                        probCur7[y] = (double)px * (logMax - logMin) / wh + logMin;
                        probCurY7[y] = (double)py;
                    }
                    if (Math.Round(GEV(log[x], stp.StdDev, mod), 2) == .5)
                    {
                        float py = (float)(par[y] * ht / 110);
                        float px = (float)((log[x] - logMin) * wh / (logMax - logMin));
                        g.FillEllipse(new SolidBrush(Color.Red), px - 2, py - 2, 4, 4);
                        probCur5[y] = (double)px * (logMax - logMin) / wh + logMin;
                        probCurY5[y] = (double)py;
                    }
                }

                Clipboard.SetText(stmod);
                for (int i = 0; i < pt.Count - 1; i++)
                {
                    PointF p1 = (PointF)pt[i];
                    PointF p2 = (PointF)pt[i + 1];
                    g.DrawLine(new Pen(Color.FromArgb(175, y * 225 / par.Length, 0, 255 - y * 225 / par.Length)), p1, p2);
                   
                    if (i == 0)
                    {
                        g.DrawString(par[y].ToString(), new Font(this.Font.Name, 7f), new SolidBrush(Color.FromArgb(175, y * 225 / par.Length, 0, 255 - y * 225 / par.Length)), p2);
                        zedPar[0] = p1.Y;
                        zedLog[0] = p1.X * (logMax - logMin) / wh + logMin;
                    }
                    zedPar[i + 1] = p2.Y;
                    zedLog[i + 1] = p2.X * (logMax - logMin) / wh + logMin;

                }
                

                Random rnd = new Random();
                Color col = Color.FromArgb(255,rnd.Next(200),rnd.Next(200),rnd.Next(200));
                
                //zedGraphControl1.GraphPane.YAxis.IsVisible = false;
                zedGraphControl1.GraphPane.AddCurve("", zedLog, zedPar, col, ZedGraph.SymbolType.None).Line.IsAntiAlias = true; 
                zedGraphControl1.GraphPane.Title.Text = "";
                zedGraphControl1.GraphPane.XAxis.Title.Text = cmbLog1.Text + "(G/C3)";
                zedGraphControl1.GraphPane.XAxis.Title.FontSpec.Size = 10;
                zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Size = 8;
                zedGraphControl1.GraphPane.YAxis.Title.Text = "Ash Content(%)";
                zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Size = 10;
                zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Size = 8;
                zedGraphControl1.AxisChange();


                ZedGraph.TextObj myText = new ZedGraph.TextObj(par[y].ToString(), zedLog[0]+.06, zedPar[0]+2);
                myText.Location.CoordinateFrame = ZedGraph.CoordType.AxisXYScale;
                myText.Location.AlignH = ZedGraph.AlignH.Right;
                myText.Location.AlignV = ZedGraph.AlignV.Center;
                myText.FontSpec.IsItalic = true;
                myText.FontSpec.IsBold = false;
                myText.FontSpec.FontColor = col;
                myText.FontSpec.Size = 8f;                
                myText.FontSpec.Fill.IsVisible = false;
                myText.FontSpec.Border.IsVisible = false;
                zedGraphControl1.GraphPane.GraphObjList.Add(myText);
                zedGraphControl1.Refresh();
            }
                        
            for (int i =probCurY9.Length-2 ; i >=0 ;i-- )
                if (probCurY9[i] == 0)
                {
                    probCur9[i] = probCur9[i+1];
                    probCurY9[i] = probCurY9[i+1];
                }
            zedGraphControl1.GraphPane.AddCurve("", probCur9, probCurY9, Color.Blue, ZedGraph.SymbolType.None).Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = probCurY7.Length - 2; i >= 0; i--)
                if (probCurY7[i] == 0)
                {
                    probCur7[i] = probCur7[i + 1];
                    probCurY7[i] = probCurY7[i + 1];
                }
            zedGraphControl1.GraphPane.AddCurve("", probCur7, probCurY7, Color.Blue, ZedGraph.SymbolType.None).Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = probCurY5.Length - 2; i >= 0; i--)
                if (probCurY5[i] == 0)
                {
                    probCur5[i] = probCur5[i + 1];
                    probCurY5[i] = probCurY5[i + 1];
                }

            zedGraphControl1.GraphPane.AddCurve("", probCur5, probCurY5, Color.Blue, ZedGraph.SymbolType.None).Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

            ZedGraph.TextObj cuText = new ZedGraph.TextObj("CDF=.9", probCur9[probCur9.Length - 1], probCurY9[probCurY9.Length - 1]+5);
            cuText.FontSpec.FontColor = Color.Blue;
            cuText.FontSpec.Size = 8f;
            cuText.FontSpec.Fill.IsVisible = false;
            cuText.FontSpec.Border.IsVisible = false;
            zedGraphControl1.GraphPane.GraphObjList.Add(cuText);

            cuText = new ZedGraph.TextObj("CDF=.7", probCur7[probCur7.Length - 1], probCurY7[probCurY7.Length - 1] +5);
            cuText.FontSpec.FontColor = Color.Blue;
            cuText.FontSpec.Size = 8f;
            cuText.FontSpec.Fill.IsVisible = false;
            cuText.FontSpec.Border.IsVisible = false;
            zedGraphControl1.GraphPane.GraphObjList.Add(cuText);

            cuText = new ZedGraph.TextObj("CDF=.5", probCur5[probCur5.Length - 1], probCurY5[probCurY5.Length - 1] + 5);
            cuText.FontSpec.FontColor = Color.Blue;
            cuText.FontSpec.Size = 8f;
            cuText.FontSpec.Fill.IsVisible = false;
            cuText.FontSpec.Border.IsVisible = false;
            zedGraphControl1.GraphPane.GraphObjList.Add(cuText); 
            
            zedGraphControl1.Refresh();

            g.DrawRectangle(new Pen(Color.Black), 0, 0, pnlCh.Width - 1, pnlCh.Height - 1);
            //bmp.Save(Application.StartupPath + "\\charts\\" + cmbLog1.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //g.Dispose();
            //bmp.Dispose();
            //MessageBox.Show("Ready");
            //pnlCh.BackgroundImage = Image.FromFile(Application.StartupPath + "\\charts\\" + cmbLog1.Text + ".jpg");
        }

        private void reoGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void pnlAx_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float scale = float.Parse(pnlCh.Tag.ToString());
            int ht = (int)((float)pnlCh.Height * scale);
            int wh = (int)((float)pnlCh.Width * scale);
            for (int i = 0; i < 11; i++)
            {
               // g.DrawLine(new Pen(Color.Black, 1), 36, i * ht / 11 + pnlCh.Top, pnlAx.Width, i * ht / 11 + pnlCh.Top);
                g.DrawString((i*10).ToString(),this.Font,new SolidBrush(Color.Black), 18, i * ht / 11 + pnlCh.Top-g.MeasureString((i*10).ToString(),this.Font).Height/2);
                if(i==4) g.DrawString(cmbLog2.Text, new Font(this.Font.Name,9,FontStyle.Bold), new SolidBrush(Color.Black), 1, 3*i * ht / 22 + pnlCh.Top - g.MeasureString((i * 10).ToString(), this.Font).Height / 2);
            }

            int dec = -(int)Math.Round(Math.Log10(logMax - logMin),0);
            dec++;
            dec++;
            if (dec < 0) dec = 0;

            for (double d = logMin; d < logMax; d+=(logMax-logMin)/10)
            {
                //g.DrawLine(new Pen(Color.Black, 1),(float)(pnlCh.Left + wh * (d - logMin) / (logMax - logMin)),0, (float)(pnlCh.Left + wh * (d - logMin) / (logMax - logMin)), ht + 10);
                g.DrawString((Math.Round(d, dec)).ToString(), this.Font, new SolidBrush(Color.Black), (float)(pnlCh.Left + wh * (d - logMin) / (logMax - logMin)) - g.MeasureString((Math.Round(d, dec)).ToString(), this.Font).Width / 2, pnlCh.Height + 10);// + g.MeasureString((d).ToString(), this.Font).Height);
            }
            g.DrawString(cmbLog1.Text, new Font(this.Font.Name, 9, FontStyle.Bold), new SolidBrush(Color.Black), (float)(pnlCh.Left + wh / 2) - g.MeasureString(cmbLog1.Text, this.Font).Width / 2, pnlAx.Height - g.MeasureString(cmbLog1.Text, this.Font).Height-5);
        }

        private void pnlCh_MouseMove(object sender, MouseEventArgs e)
        {

            int dec = -(int)Math.Round(Math.Log10(logMax - logMin), 0);
            dec++; dec++;
            if (dec < 0) dec = 0;
            double xx = (logMax - logMin)*e.X / pnlCh.Width;
            
            double yy = e.Y * 110 / (double)pnlCh.Height;
            lblCoor.Text =cmbLog1.Text + ": " + Math.Round(logMin + xx, dec) + " vs " + cmbLog2.Text + ": " + Math.Round(yy + 1, 2).ToString();
        }

        private void pnlCh_DoubleClick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.pnlAx.Bounds.Width, this.pnlAx.Bounds.Height);
            this.pnlAx.DrawToBitmap(bmp, new Rectangle(this.pnlAx.Bounds.Left, this.pnlAx.Bounds.Top , this.Bounds.Width, this.Bounds.Height));
            bmp.Save(Application.StartupPath + "\\charts\\" + cmbLog1.Text +".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Screenshot has Created.");
            bmp.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
            Clipboard.SetText(System.IO.File.ReadAllText("data.txt"));
            reoGridControl1.GetCell(0, 0);
            reoGridControl1_DoubleClick(null, null);

        }

        private void pnlCh_Click(object sender, EventArgs e)
        {
            
                float s = float.Parse(pnlCh.Tag.ToString());
                //s += .25f;
                pnlCh.Tag = s;
                pnlCh.Refresh();
                pnlAx.Refresh();
            
        }

        private void pnlCh_MouseDown(object sender, MouseEventArgs e)
        {
            pnlAx.Tag = new PointF(e.X, e.Y);
        }

        private void pnlCh_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlAx.Tag != null)
            {
                PointF pt = (PointF)pnlAx.Tag;
                if (e.X == pt.X && e.Y == pt.Y)
                    pnlAx.Tag = null;
                else
                    pnlAx.Tag = new PointF(e.X - pt.X, e.Y - pt.Y);
                pnlCh.Refresh();
            }
        }
        private double GEV(double x, double std, double mod)
        {
            double z = Math.Pow(6 * std * std / 9.8696, .5);
            double tx = Math.Exp(-(x - mod) / z);
            return Math.Exp(-tx);
        }
    }
}

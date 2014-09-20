using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using ESPA;
using Graph = System.Windows.Forms.DataVisualization.Charting;

namespace Sotrm_Surge_UX
{
    public partial class Form1 : Form
    {
        Dictionary<DateTime, double> obs = new Dictionary<DateTime, double>();
        static string pathseperator = "\\";
        IList<areaCls> allData = new List<areaCls>();
        private void completeTask()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["areaLoc"].Value = txtareaLoc.Text;
            config.AppSettings.Settings["ObsLoc"].Value = txtobsLoc.Text;
            config.AppSettings.Settings["DataFolder"].Value = txtDataFolder.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }
        public Form1()
        {
            InitializeComponent();


            txtareaLoc.Text = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["areaLoc"]);
            txtobsLoc.Text = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["ObsLoc"]);
            txtDataFolder.Text = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["DataFolder"]);
            lbllog.Text = "";

            load_data();
            completeTask();

        }
        private void load_data() {
            string file = txtareaLoc.Text;
            try
            {
                string text = File.ReadAllText(file);
                var fileName = string.Format(file);
                var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0;", fileName);
                var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                var ds = new DataSet();
                adapter.Fill(ds, "area");
                DataTable data = ds.Tables["area"];
                //dataGridView1.DataSource = data;
                //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                var enn = ds.Tables["area"].AsEnumerable();
                allData = enn.Where(x => x.Field<object>(0).ToString() != "FID").Select(x => new areaCls
                {
                    FID = x.Field<Double?>(0),
                    //NGEOCODE = x.Field<Double?>(3),
                    DIVNAME = x.Field<String>(3),
                    DISTNAME = x.Field<String>(4),
                    THANAME = x.Field<String>(5),
                    UNINAME = x.Field<String>(6),
                    NGEOCODE = x.Field<Double?>(7),
                    /*Pol_height = x.Field<Double?>(17),
                    Pol_nam = x.Field<String>(18),
                    LinkID = x.Field<Double?>(33),
                    netCDF_IDs = x.Field<String>(179),
                    DDIEM_dist = x.Field<Double?>(180),
                    DDIEM_than = x.Field<Double?>(181),*/
                    area_cal = x.Field<Double?>(14),
                    DDIEM_unio = x.Field<Double?>(13)
                    //obs_point = x.Field<String>(184)
                }).ToList();
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=Excel 12.0;", string.Format(txtobsLoc.Text));
                adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                ds = new DataSet();
                adapter.Fill(ds, "obs");
                data = ds.Tables["obs"];
                enn = ds.Tables["obs"].AsEnumerable();
                foreach (areaCls cls in allData)
                {
                    areaCls tmp = enn.Where(x => x.Field<object>(14).ToString() == cls.NGEOCODE.ToString() &&
                        x.Field<object>(10).ToString() == cls.UNINAME).Select(x => new areaCls
                        {
                            FID = x.Field<Double?>(0),
                            //NGEOCODE = x.Field<Double?>(3),
                            /*DIVNAME = x.Field<String>(3),
                            DISTNAME = x.Field<String>(4),
                            THANAME = x.Field<String>(5),
                            UNINAME = x.Field<String>(6),
                            NGEOCODE = x.Field<Double?>(7),*/
                            /*Pol_height = x.Field<Double?>(17),
                            Pol_nam = x.Field<String>(18),
                            LinkID = x.Field<Double?>(33),
                            netCDF_IDs = x.Field<String>(179),
                            DDIEM_dist = x.Field<Double?>(180),
                            DDIEM_than = x.Field<Double?>(181),*/
                            /* area_cal = x.Field<Double?>(14),
                             DDIEM_unio = x.Field<Double?>(13)*/
                            obs_point = x.Field<String>(184)
                        }).FirstOrDefault();
                    if (tmp != null)
                        cls.obs_point = tmp.obs_point;
                    else
                        lbllog.Text += " not found " + cls.UNINAME;
                }
                //label1.Text = allData[0].FID.ToString();
                //lbllog.Text = "Data Loaded";
                cmbThana.Items.Clear();
                cmbUnion.Items.Clear();
                cmbUnionID.Items.Clear();
                cmbDist.Items.Clear();
                cmbDist.Items.Add("All");
                IList<String> dists = (from dbo in allData orderby dbo.DISTNAME ascending select dbo.DISTNAME).Distinct().ToList();
                foreach (String dist in dists)
                    cmbDist.Items.Add(dist);
                IList<String> thanas = (from dbo in allData orderby dbo.THANAME ascending select dbo.THANAME).Distinct().ToList();
                foreach (String dist in thanas)
                    cmbThana.Items.Add(dist);
                foreach (areaCls tmp in allData)
                {
                    cmbUnion.Items.Add(tmp.UNINAME);
                    cmbUnionID.Items.Add(int.Parse(tmp.NGEOCODE.ToString()).ToString());
                }
                foreach (string s in Directory.GetDirectories(txtDataFolder.Text))
                {
                    cmbScenerio.Items.Add(Path.GetFileName(Path.GetDirectoryName(s + pathseperator)));
                    cmbScenerio.SelectedIndex = cmbScenerio.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                lbllog.Text = ex.Message;
            }
        }
        private void generate_graph_click(object sender, EventArgs e)
        {
            completeTask();
            if (cmbUnion.SelectedIndex != -1)
            {
                areaCls row = allData.Where(x => x.UNINAME == cmbUnion.SelectedItem.ToString()).FirstOrDefault();
                if (row != null)
                {
                    try
                    {
                        string WINDSPEED_AILA = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["aila"]);
                        string WINDSPEED_MAHASEN = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["mahasen"]);
                        string WINDSPEED_SIDR = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["sidr"]);
                        Dictionary<double, Double> chart_data = new Dictionary<double, Double>();
                        Dictionary<string, Double> chart_tmp_data = new Dictionary<string, Double>();
                        foreach (string storms in Directory.GetDirectories(txtDataFolder.Text + pathseperator + cmbScenerio.SelectedItem.ToString() + pathseperator))
                        {
                            string obs_file = storms + pathseperator + row.obs_point + ".csv";
                            var reader = new StreamReader(File.OpenRead(obs_file));

                            int i = 0;
                            while (!reader.EndOfStream)
                            {

                                string line = reader.ReadLine();
                                i++;
                                if (i == 1) continue;

                                string[] values = line.Split(',');
                                if (obs_file.Contains("aila"))
                                {
                                    chart_tmp_data.Add("aila", Double.Parse(values[1]));
                                }
                                else if (obs_file.Contains("sidr"))
                                {
                                    chart_tmp_data.Add("sidr", Double.Parse(values[1]));
                                }
                                else
                                {
                                    chart_tmp_data.Add("mahasen", Double.Parse(values[1]));
                                }

                            }
                        }
                        chart_data.Add(double.Parse(WINDSPEED_MAHASEN), chart_tmp_data["mahasen"]);
                        chart_data.Add(double.Parse(WINDSPEED_AILA), chart_tmp_data["aila"]);
                        chart_data.Add(double.Parse(WINDSPEED_SIDR), chart_tmp_data["sidr"]);
                        gen_chart(chart_data);
                    }
                    catch (Exception ex)
                    {
                        lbllog.Text = ex.Message;
                    }

                }
            }
        }
        private void gen_chart(Dictionary<double, Double> lineChartData)
        {
            Graph.Chart chart = chart1;
            if (lineChartData.Keys.Count > 1)
            {
                var list = lineChartData.Keys.ToList();
                list.Sort();
                int MaxX = Convert.ToInt32(lineChartData.Keys.Max());
                // Create new Graph
                //chart1 = Graph.Chart();
                
                if (chart1.ChartAreas.Count != 0)
                    chart1.ChartAreas.RemoveAt(0);
                // Add a chartarea called "draw", add axes to it and color the area black
                chart.ChartAreas.Add("draw");
                chart.ChartAreas["draw"].AxisX.Minimum = Convert.ToInt32(lineChartData.Keys.Min());
                chart.ChartAreas["draw"].AxisX.Maximum = MaxX+20;
                chart.ChartAreas["draw"].AxisX.Interval = 30;
                chart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray;
                chart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                chart.ChartAreas["draw"].AxisX.Title = "Wind Speed";
                

                chart.ChartAreas["draw"].AxisY.Title = "Excess Water level";
                chart.ChartAreas["draw"].AxisY.Minimum = 0;
                chart.ChartAreas["draw"].AxisY.Maximum = Convert.ToInt32(lineChartData.Values.Max()+2);
                chart.ChartAreas["draw"].AxisY.Interval = .5;
                chart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray;
                chart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                //chart.ChartAreas["draw"].BackColor = Color.Black;
                // Create a new function series
                if(chart.Series.Count!=0)
                    if (chart.Series[0].Name != "MyFunc")
                        chart1.Series.RemoveAt(0);
                
                if (chart1.Series.FirstOrDefault(x => x.Name == "MyFunc") != null) chart1.Series.Remove(chart.Series["MyFunc"]);
                if (chart1.Series.FirstOrDefault(x => x.Name == "MyOriginalFunc") != null) chart1.Series.Remove(chart.Series["MyOriginalFunc"]);
                chart.Series.Add("MyFunc");
                // Set the type to line
                chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
                // Color the line of the graph light green and give it a thickness of 3
                chart.Series["MyFunc"].Color = Color.Red;
                chart.Series["MyFunc"].BorderWidth = 5;
                chart.Series.Add("MyOriginalFunc");
                // Set the type to line
                chart.Series["MyOriginalFunc"].ChartType = Graph.SeriesChartType.Point;
                //This function cannot include zero, and we walk through it in steps of 0.1 to add coordinates to our series
                //for (double x = 0.1; x < MaxX; x += 0.1)
                //{
                //    chart.Series["MyFunc"].Points.AddXY(x, Math.Sin(x) / x);
                //}
                Tuple<double, double> getAB = new best_fit().getAB(lineChartData);
                lblEquation.Text = "f = " + getAB.Item1 + " + " + getAB.Item2 + "x.";
                foreach (var key in list)
                {
                    //chart.Series["MyFunc"].Points.AddXY(key + .46, lineChartData[key] * 100);
                    chart.Series["MyFunc"].Points.AddXY(key , (getAB.Item1 + getAB.Item2 * key) );
                    //chart.Series["MyFunc"].ToolTip = (Math.Round(key + .46, 2)).ToString() + "," + (Math.Round(lineChartData[key] * 100, 2).ToString());
                    chart.Series["MyFunc"].MarkerColor = Color.Green;
                    chart.Series["MyFunc"].MarkerSize = 5;
                    chart.Series["MyFunc"].MarkerStyle = Graph.MarkerStyle.Circle;

                    chart.Series["MyOriginalFunc"].Points.AddXY(key + .46, lineChartData[key] * 100);

                    //chart.Series["MyFunc"].ToolTip = (Math.Round(key + .46, 2)).ToString() + "," + (Math.Round(lineChartData[key] * 100, 2).ToString());
                    chart.Series["MyOriginalFunc"].MarkerColor = Color.Orange;
                    chart.Series["MyOriginalFunc"].MarkerSize = 10;
                    chart.Series["MyOriginalFunc"].MarkerStyle = Graph.MarkerStyle.Diamond;
                }
                chart.Series["MyFunc"].LegendText = cmbUnion.SelectedItem.ToString() ;
                // Create a new legend called "MyLegend".
                if (chart1.Legends.Count != 0)
                    chart1.Legends.RemoveAt(0);
                chart.Legends.Add("MyLegend");
                chart.Legends["MyLegend"].BorderColor = Color.Tomato; // I like tomato juice!
                label1.Text = "";
                chart.Series["MyOriginalFunc"].LegendText = "Original points";
                cmdExport.Visible = true;

            }
            else
            {
                label1.Text = "No Inundation";
                chart = chart1;
                if (chart1.ChartAreas.Count != 0)
                    chart1.ChartAreas.RemoveAt(0);
                // Add a chartarea called "draw", add axes to it and color the area black
                chart.ChartAreas.Add("draw");
                chart.ChartAreas["draw"].AxisX.Minimum = Convert.ToInt32(0);
                chart.ChartAreas["draw"].AxisX.Maximum = 5;
                chart.ChartAreas["draw"].AxisX.Interval = 1;
                chart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray;
                chart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;

                chart.ChartAreas["draw"].AxisY.Minimum = 0;
                chart.ChartAreas["draw"].AxisY.Maximum = 100;
                chart.ChartAreas["draw"].AxisY.Interval = 10;
                chart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray;
                chart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                //chart.ChartAreas["draw"].BackColor = Color.Black;
                // Create a new function series
                if (chart.Series[0].Name != "MyFunc")
                {
                    chart1.Series.RemoveAt(0);
                }
                if (chart1.Series.FirstOrDefault(x => x.Name == "MyFunc") != null) chart1.Series.Remove(chart.Series["MyFunc"]);
                if (chart1.Series.FirstOrDefault(x => x.Name == "MyOriginalFunc") != null) chart1.Series.Remove(chart.Series["MyOriginalFunc"]);
                chart.Series.Add("MyFunc");
                // Set the type to line
                chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["MyFunc"].LegendText = "";
                if (chart1.Legends.Count != 0)
                    chart1.Legends.RemoveAt(0);
                chart.Legends.Add("MyLegend");
                chart.Legends["MyLegend"].BorderColor = Color.Tomato; // I like tomato juice!
            }
        }
        private void cmbDistChanged(object sender, EventArgs e)
        {
            cmbThana.Items.Clear();
            cmbUnion.Items.Clear();
            cmbUnionID.Items.Clear();
            IList<areaCls> rows = new List<areaCls>();
            rows = (cmbDist.SelectedItem.ToString() != "All") ? allData.Where(x => x.DISTNAME == cmbDist.SelectedItem.ToString()).
                GroupBy(x => x.THANAME).Select(group => group.First()).ToList() : allData;

            foreach (areaCls row in rows)
            {
                cmbThana.Items.Add(row.THANAME);
                cmbUnion.Items.Add(row.UNINAME);
                cmbUnionID.Items.Add(Convert.ToInt32(row.NGEOCODE).ToString());
            }
        }
        private void cmbUnion_changed(object sender, EventArgs e)
        {
            //cmbUnionID.SelectedText = "";
            areaCls row = allData.Where(x => x.UNINAME == cmbUnion.SelectedItem.ToString()).FirstOrDefault();
            cmbUnionID.SelectedIndex = cmbUnionID.Items.IndexOf(Convert.ToInt32(row.NGEOCODE).ToString());
            //cmbDist.SelectedIndex = cmbDist.Items.IndexOf(Convert.ToInt32(row.NGEOCODE).ToString());
        }
        private void cmbUnionID_changed(object sender, EventArgs e)
        {
            //cmbUnionID.SelectedText = "";
            areaCls row = allData.Where(x => x.NGEOCODE == Convert.ToInt32(cmbUnionID.SelectedItem)).FirstOrDefault();
            cmbUnion.SelectedIndex = cmbUnion.Items.IndexOf(row.UNINAME);
        }
        private void cmbThanaChanged(object sender, EventArgs e)
        {
            cmbUnion.Items.Clear();
            cmbUnionID.Items.Clear();
            IList<areaCls> rows = new List<areaCls>();
            rows = (cmbThana.SelectedItem.ToString() != "") ? allData.Where(x => x.THANAME == cmbThana.SelectedItem.ToString())
                .GroupBy(x => x.UNINAME).Select(group => group.First()).ToList() :
                new List<areaCls>(rows.Concat(allData));

            foreach (areaCls row in rows)
            {
                cmbUnion.Items.Add(row.UNINAME);
                cmbUnionID.Items.Add(Convert.ToInt32(row.NGEOCODE).ToString());
            }
        }

        private void brnLoadClick(object sender, EventArgs e)
        {
            lbllog.Text = "";
            load_data();
        }


    }
}

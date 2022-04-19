using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Net;
using System.Reflection;

namespace GeocodingTools
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form2的所有者是Form1
            Form1 f1 = (Form1)this.Owner;

            List<string> nList = f1.GetNameList();
            List<string> adList = f1.GetAdList();
            //添加行，保证数据添加时有空位
            for (int i = 1; i <= adList.Count; i++)
            {
                dataGridView1.Rows.Add();
            }
            GridViewTable_row(nList, 0);
            GridViewTable_row(adList, 1);
            if (f1.city_checkBox.Checked ==true)
            {
                List<string> cList = f1.GetCityList();
                GridViewTable_row(cList, 2);
            }
            if (f1.area_checkBox.Checked == true)
            {
                List<string> aList = f1.GetAreaList();
                GridViewTable_row(aList, 3);
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表头居中
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//单元格居中

            // DataGridView取消选中第一行第一列方法
            dataGridView1.Rows[0].Cells[0].Selected = false;
            dataGridView1.Rows[0].Selected = false;
        }


        #region 数据添加
        /// <summary>
        /// 将数据绑定到datagridview
        /// </summary>
        /// <param name="list">列表数据</param>
        /// <param name="colIndex">列</param>
        private void GridViewTable_row(List<string> list,int colIndex)
        {
            // 设置单元格文本太长，可以换行显示
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //添加数据行
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[colIndex].Value = list[i];
            }

        }
        #endregion

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
             e.RowBounds.Location.Y,
                   dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   dataGridView1.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        #region 地理编码

        private void GetPosition(string key)
        {
            Form1 f1 = (Form1)this.Owner;
            try
            {
                string js = "";
                string[] jss = new string[3];
                int num = dataGridView1.Rows.Count;
                int suNum = 0;
                int errorNum = 0;
                InitProgressBar(progressBar1,0,num-1);

                for (int i = 0; i < num; i++)
                {
                    if (dataGridView1[1,i].Value != null)
                    {
                        if (f1.city_checkBox.Checked == true&&f1.area_checkBox.Checked ==true)
                        {
                            js = Geocode.GeoEncoding(dataGridView1[1, i].Value.ToString(), dataGridView1[2, i].Value.ToString(), dataGridView1[3, i].Value.ToString(), key);
                            jss = js.Split(',');
                            //dataGridView1[2, i].Value = jss[0];
                            //dataGridView1[3, i].Value = jss[1];
                            dataGridView1[4, i].Value = jss[2];
                            dataGridView1[5, i].Value = jss[3];
                        }
                        else if (f1.city_checkBox.Checked == true&&f1.area_checkBox.Checked == false)
                        {
                            js = Geocode.GeoEncoding(dataGridView1[1, i].Value.ToString(), dataGridView1[2, i].Value.ToString(), key);
                            jss = js.Split(',');
                            //dataGridView1[2, i].Value = jss[0];
                            dataGridView1[3, i].Value = jss[1];
                            dataGridView1[4, i].Value = jss[2];
                            dataGridView1[5, i].Value = jss[3];
                        }
                        else if (f1.city_checkBox.Checked == false && f1.area_checkBox.Checked == true&& dataGridView1[3, i].Value != null)
                        {
                            js = Geocode.GeoareaEncoding(dataGridView1[1, i].Value.ToString(), dataGridView1[3, i].Value.ToString(), key);
                            jss = js.Split(',');
                            dataGridView1[2, i].Value = jss[0];
                            //dataGridView1[3, i].Value = jss[1];
                            dataGridView1[4, i].Value = jss[2];
                            dataGridView1[5, i].Value = jss[3];
                        }
                        else 
                        {
                            js = Geocode.GeoEncoding(dataGridView1[1, i].Value.ToString(), key);
                            jss = js.Split(',');
                            dataGridView1[2, i].Value = jss[0];
                            dataGridView1[3, i].Value = jss[1];
                            dataGridView1[4, i].Value = jss[2];
                            dataGridView1[5, i].Value = jss[3];
                        }
                        StartProgressBar(progressBar1, i, label1);
                        suNum += 1;
                    }
                    else
                    {
                        dataGridView1[2, i].Value = "NULL";
                        dataGridView1[3, i].Value = "NULL";
                        dataGridView1[4, i].Value = "NULL";
                        dataGridView1[5, i].Value = "NULL";
                        StartProgressBar(progressBar1, i, label1);
                        errorNum += 1;
                    }
                }
                string word = "共" + num + "条数据，其中成功地理编码：" + suNum + "条数据，失败"+ errorNum +"条数据！";
                MessageBox.Show(word,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("请正确加载数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 进度条
        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="progressBar">进度条组件</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        private void InitProgressBar(ProgressBar progressBar, int minValue, int maxValue)
        {
            if (progressBar == null || minValue < 0 || maxValue < 0 || minValue >= maxValue) return;

            progressBar.Minimum = minValue;
            progressBar.Maximum = maxValue;

        }

        /// <summary>
        /// 启动进度条
        /// </summary>
        /// <param name="progressBar">进度条组件</param>
        /// <param name="value">当前进度值</param>
        /// <param name="label">进度显示标签</param>
        private void StartProgressBar(ProgressBar progressBar, int value, Label label)
        {
            if (progressBar == null || label == null) return;
            Application.DoEvents();

            progressBar.Value = value;

            int tmp = value * 100 / progressBar.Maximum;

            label.Text = tmp + "%";
            label.Refresh();

            progressBar.Refresh();
        }
        #endregion

        private void bt_Geoconding_Click(object sender, EventArgs e)
        {
            if (Net.IsConnectedInternet() == true)
            {
                string key = Form1.form1.GetKey();
                this.GetPosition(key);
            }
            else
            {
                MessageBox.Show("请先连接网络！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region 在导出Excel前，先将DataGridView转换为DataTable
        //将DataGridView转换为DataTable
        public DataTable GetDgvToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            //列强制转换
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[i].Name.ToString());
                dt.Columns.Add(dc);
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = Convert.ToString(dgv.Rows[i].Cells[j].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)//导出Excel
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel 工作簿|*.xlsx" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    ExportExcel.WriteExcel_Table(FileName, GetDgvToDataTable(dataGridView1));
                }
            }
        }

        private void bt_Geoconding_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                
            }
        }
    }
}

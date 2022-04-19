using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeocodingTools
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        public Form1()
        {
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            InitializeComponent();
            form1 = this;
            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);

        }

        #region 编序号
        /// <summary>
        /// 自动编序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion

        public DataTableCollection tableCollection;
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataForDataGridView();
            nameList.Items.Clear();
            columList.Items.Clear();
            cityList.Items.Clear();
            areaList.Items.Clear();

            int num = dataGridView1.Columns.Count;
            for (int i = 0; i < num; i++)
            {
                nameList.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
                nameList.SelectedIndex = 0;
                columList.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
                columList.SelectedIndex = 0;
                cityList.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
                cityList.SelectedIndex = 0;
                areaList.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
                areaList.SelectedIndex = 0;
            }
        }

        public void key_button_Click(object sender, EventArgs e)
        {
            this.GetKey();
        }

        public string GetKey()
        {
            string key = key_textbox.Text;
            return key;
        }


        private void btnBrowser_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 导入Excel文件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 工作簿|*.xlsx|Excel 97-2003 工作簿|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textFilename.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                            {
                                cboSheet.Items.Add(table.TableName);
                            }
                            if (tableCollection.Count > 0)
                            {
                                cboSheet.SelectedIndex = 0;//表单默认选择第一个
                            }
                        }
                    }
                }
            }
        }

        private void BindDataForDataGridView()
        {
            var dt = tableCollection[cboSheet.SelectedItem.ToString()];
            BindDataGridViewFillShow(dt, dataGridView1, Color.Green);
            dataGridView1.DataSource = dt;

            // DataGridView取消选中第一行第一列方法(绑定数据源后)
            dataGridView1.Rows[0].Cells[0].Selected = false;
            dataGridView1.Rows[0].Selected = false;
        }


        /// <summary>
        /// 铺满显示，绑定DataGridView数据源后
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="dgv">DataGridView</param>
        /// <param name="headerFontColor">表头字体颜色设置</param>
        public static void BindDataGridViewFillShow(DataTable dt, DataGridView dgv, Color headerFontColor)
        {
            dgv.ClearSelection();
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 列宽平均分平铺显示
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//居中显示
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;// 设置单元格文本太长，可以换行显示
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders; // 行高自适应调整
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 设置为整行被选中

            // 给表头内容换颜色
            dgv.EnableHeadersVisualStyles = false; //使用当前的主题的样式
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表头居中
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;// 设置表头文本太长，可以换行显示
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = headerFontColor;

            dgv.DataSource = null;
            dgv.DataSource = dt;
        }


        /// <summary>
        /// LINQ语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">数据集</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        public static List<T> GetColumnValues<T>(DataTable dt, int colIndex)
        {
            return (from r in dt.AsEnumerable() select r.Field<T>(colIndex)).ToList<T>();
        }


        public List<string> GetNameList()
        {
            var dt = tableCollection[cboSheet.SelectedItem.ToString()];
            int selIndex = nameList.SelectedIndex;//获得名称列选择的index
            List<string> nList = new List<string>();
            nList = GetColumnValues<string>(dt, selIndex);
            return nList;
        }
        public List<string> GetAdList()
        {
            var dt = tableCollection[cboSheet.SelectedItem.ToString()];
            int selIndex = columList.SelectedIndex;//获得详细地址列选择的index
            List<string> adList = new List<string>();
            adList = GetColumnValues<string>(dt, selIndex);
            return adList;
        }

        public List<string> GetCityList()
        {
            var dt = tableCollection[cboSheet.SelectedItem.ToString()];
            int selIndex = cityList.SelectedIndex;//获得城市列选择的index
            List<string> cList = new List<string>();
            cList = GetColumnValues<string>(dt, selIndex);
            return cList;
        }

        public List<string> GetAreaList()
        {
            var dt = tableCollection[cboSheet.SelectedItem.ToString()];
            int selIndex = areaList.SelectedIndex;//获得区域列选择的index
            List<string> aList = new List<string>();
            aList = GetColumnValues<string>(dt, selIndex);
            return aList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (columList.SelectedIndex >= 0)//下表>=0才开始转换
            {
                Form2 f2 = new Form2();
                f2.Owner = this;
                int selIndex = columList.SelectedIndex;//获得详细地址列选择的index
                int selNameIndex = nameList.SelectedIndex;
                //MessageBox.Show(dataGridView1.Columns[selIndex].ValueType.ToString());
                try
                {
                    if (dataGridView1.Columns[selIndex].ValueType == typeof(string) && dataGridView1.Columns[selNameIndex].ValueType == typeof(string))
                    {
                        f2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("名称列以及详细地址列的选择，必须为文本类型数据","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开Excel表！");
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void city_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (city_checkBox.Checked ==true)
            {
                cityList.Enabled = true;
            }
            else
            {
                cityList.Enabled = false;
            }
        }

        private void area_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (area_checkBox.Checked == true)
            {
                areaList.Enabled = true;
            }
            else
            {
                areaList.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.GetKey();
        }
    }
}

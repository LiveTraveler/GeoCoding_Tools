
namespace GeocodingTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.textFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.columList = new System.Windows.Forms.ComboBox();
            this.trans_button = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.city_checkBox = new System.Windows.Forms.CheckBox();
            this.cityList = new System.Windows.Forms.ComboBox();
            this.area_checkBox = new System.Windows.Forms.CheckBox();
            this.areaList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameList = new System.Windows.Forms.ComboBox();
            this.key_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.key_textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(910, 446);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.Location = new System.Drawing.Point(847, 4);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(74, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "浏览...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Excel文件路径：";
            // 
            // cboSheet
            // 
            this.cboSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(47, 483);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(107, 20);
            this.cboSheet.TabIndex = 3;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // textFilename
            // 
            this.textFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFilename.Location = new System.Drawing.Point(479, 5);
            this.textFilename.Name = "textFilename";
            this.textFilename.Size = new System.Drawing.Size(361, 21);
            this.textFilename.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "表单：";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "详细地址列：";
            // 
            // columList
            // 
            this.columList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.columList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columList.FormattingEnabled = true;
            this.columList.Location = new System.Drawing.Point(388, 483);
            this.columList.Name = "columList";
            this.columList.Size = new System.Drawing.Size(113, 20);
            this.columList.TabIndex = 3;
            // 
            // trans_button
            // 
            this.trans_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trans_button.Location = new System.Drawing.Point(847, 482);
            this.trans_button.Name = "trans_button";
            this.trans_button.Size = new System.Drawing.Size(75, 23);
            this.trans_button.TabIndex = 5;
            this.trans_button.Text = "开始转换";
            this.trans_button.UseVisualStyleBackColor = true;
            this.trans_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "批量地理编码小工具";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // city_checkBox
            // 
            this.city_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.city_checkBox.AutoSize = true;
            this.city_checkBox.Checked = true;
            this.city_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.city_checkBox.Location = new System.Drawing.Point(508, 485);
            this.city_checkBox.Name = "city_checkBox";
            this.city_checkBox.Size = new System.Drawing.Size(72, 16);
            this.city_checkBox.TabIndex = 6;
            this.city_checkBox.Text = "城市列：";
            this.city_checkBox.UseVisualStyleBackColor = true;
            this.city_checkBox.CheckedChanged += new System.EventHandler(this.city_checkBox_CheckedChanged);
            // 
            // cityList
            // 
            this.cityList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityList.FormattingEnabled = true;
            this.cityList.Location = new System.Drawing.Point(572, 483);
            this.cityList.Name = "cityList";
            this.cityList.Size = new System.Drawing.Size(121, 20);
            this.cityList.TabIndex = 7;
            // 
            // area_checkBox
            // 
            this.area_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.area_checkBox.AutoSize = true;
            this.area_checkBox.Checked = true;
            this.area_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.area_checkBox.Location = new System.Drawing.Point(706, 485);
            this.area_checkBox.Name = "area_checkBox";
            this.area_checkBox.Size = new System.Drawing.Size(72, 16);
            this.area_checkBox.TabIndex = 6;
            this.area_checkBox.Text = "区域列：";
            this.area_checkBox.UseVisualStyleBackColor = true;
            this.area_checkBox.CheckedChanged += new System.EventHandler(this.area_checkBox_CheckedChanged);
            // 
            // areaList
            // 
            this.areaList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaList.FormattingEnabled = true;
            this.areaList.Location = new System.Drawing.Point(770, 483);
            this.areaList.Name = "areaList";
            this.areaList.Size = new System.Drawing.Size(73, 20);
            this.areaList.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "名称列：";
            // 
            // nameList
            // 
            this.nameList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameList.FormattingEnabled = true;
            this.nameList.Location = new System.Drawing.Point(205, 483);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(104, 20);
            this.nameList.TabIndex = 3;
            // 
            // key_button
            // 
            this.key_button.Location = new System.Drawing.Point(281, 4);
            this.key_button.Name = "key_button";
            this.key_button.Size = new System.Drawing.Size(74, 23);
            this.key_button.TabIndex = 1;
            this.key_button.Text = "更换密钥";
            this.key_button.UseVisualStyleBackColor = true;
            this.key_button.Click += new System.EventHandler(this.key_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "高德Key：";
            // 
            // key_textbox
            // 
            this.key_textbox.Location = new System.Drawing.Point(65, 5);
            this.key_textbox.Name = "key_textbox";
            this.key_textbox.Size = new System.Drawing.Size(212, 21);
            this.key_textbox.TabIndex = 4;
            this.key_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.areaList);
            this.Controls.Add(this.area_checkBox);
            this.Controls.Add(this.cityList);
            this.Controls.Add(this.city_checkBox);
            this.Controls.Add(this.trans_button);
            this.Controls.Add(this.key_textbox);
            this.Controls.Add(this.textFilename);
            this.Controls.Add(this.nameList);
            this.Controls.Add(this.columList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.key_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 550);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量地理编码小工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.TextBox textFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox columList;
        private System.Windows.Forms.Button trans_button;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        public  System.Windows.Forms.CheckBox city_checkBox;
        private System.Windows.Forms.ComboBox cityList;
        public  System.Windows.Forms.CheckBox area_checkBox;
        private System.Windows.Forms.ComboBox areaList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox nameList;
        private System.Windows.Forms.Button key_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox key_textbox;
    }
}


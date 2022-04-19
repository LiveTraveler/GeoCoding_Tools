using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeocodingTools
{
    public class ExportExcel
    {
        /// <summary>
        /// 按普通报表 导出
        /// </summary>
        public static void WriteExcel_Table(string FileName, DataTable data)
        {
            // 指定EPPlus使用非商业证书
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // 加载这个 Excel 文件
            ExcelPackage package = new ExcelPackage();
            // 添加一个 sheet 表
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("数据");

            int rowIndex = 1;   // 起始行为 1
            int colIndex = 1;   // 起始列为 1
            List<string> colmunName = new List<string>() { "名称","地址","城市","区","经度","纬度"};
            for (int i = 0; i < data.Columns.Count; i++)
            {
                // 设置列名
                worksheet.Cells[rowIndex, colIndex + i].Value = colmunName[i];
                // 字体
                worksheet.Cells[rowIndex, colIndex + i].Style.Font.Name = "宋体";
                // 字体加粗
                worksheet.Cells[rowIndex, colIndex + i].Style.Font.Bold = true;
                // 字体大小
                worksheet.Cells[rowIndex, colIndex + i].Style.Font.Size = 12;


                // 隐藏列
                // worksheet.Column(colIndex + i).Hidden = true;
            }
            // 跳过第一列列名，写入数据
            rowIndex++;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    worksheet.Cells[rowIndex + i, colIndex + j].Value = data.Rows[i][j];
                }
                worksheet.Row(rowIndex + i).CustomHeight = true; //自动调整行高
                // 隐藏行
                // worksheet.Row(rowIndex + i).Hidden = true;
            }


            // 垂直居中
            worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            // 水平居中
            worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            // 自动调整列宽，也可以指定最小宽度和最大宽度
            worksheet.Columns.AutoFit();
            // 单元格是否自动换行
            worksheet.Cells.Style.WrapText = false;
            // 单元格自动适应大小
            worksheet.Cells.Style.ShrinkToFit = true;
            // 冻结首行（行号，列号）
            worksheet.View.FreezePanes(2, 1);

            //新建一个 Excel 文件
            FileStream fileStream = new FileStream(FileName, FileMode.Create);
            package.SaveAs(fileStream);

            fileStream.Close();
            fileStream.Dispose();
            worksheet.Dispose();
            package.Dispose();

            MessageBox.Show("Excel文件已保存","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            GC.Collect();
        }
    }
}
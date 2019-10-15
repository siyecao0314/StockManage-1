using System;
using System.Collections.Generic;
using System.Windows.Forms;
using nsStockManage;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using nsDBConnection;

//工装出库类
namespace nsMainWindow
{
    class ToolsOut
    {
        /*****************************************    按工装方式出库界面     *************************************/
        public void textBox_outByTools_borrower_Enter()
        {
            if (Program.mw.textBox_outByTools_borrower.Text == "员工编号 ")
            {
                Program.mw.textBox_outByTools_borrower.Text = "";
                Program.mw.textBox_outByTools_borrower.ForeColor = Color.Black;
                Program.mw.textBox_outByTools_borrower.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_outByTools_borrower_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_outByTools_borrower.Text))
            {
                Program.mw.textBox_outByTools_borrower.Text = "员工编号 ";
                Program.mw.textBox_outByTools_borrower.ForeColor = Color.Gray;
                Program.mw.textBox_outByTools_borrower.TextAlign = HorizontalAlignment.Right;
            }
        }
        public void textBox_outByTools_operator_Enter()
        {
            if (Program.mw.textBox_outByTools_operator.Text == "员工编号 ")
            {
                Program.mw.textBox_outByTools_operator.Text = "";
                Program.mw.textBox_outByTools_operator.ForeColor = Color.Black;
                Program.mw.textBox_outByTools_operator.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_outByTools_operator_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_outByTools_operator.Text))
            {
                Program.mw.textBox_outByTools_operator.Text = "员工编号 ";
                Program.mw.textBox_outByTools_operator.ForeColor = Color.Gray;
                Program.mw.textBox_outByTools_operator.TextAlign = HorizontalAlignment.Right;
            }
        }
        public void outByToolsCleanAll()
        {
            Program.mw.textBox_outByTools_code.Text = "";
            Program.mw.textBox_outByTools_toolName.Text = "";
            Program.mw.comboBox_outByTools_functionState.Text = "正常";
            Program.mw.textBox_outByTools_remarks.Text = "";
            Program.mw.textBox_outByTools_materialNumber.Text = "";
            Program.mw.textBox_outByTools_area.Text = "";
            Program.mw.textBox_outByTools_layer.Text = "";
            Program.mw.textBox_outByTools_shelf.Text = "";
            Program.mw.textBox_outByTools_borrower.Text = "员工编号 ";
            Program.mw.textBox_outByTools_borrower.ForeColor = Color.Gray;
            Program.mw.textBox_outByTools_borrower.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_outByTools_operator.Text = "员工编号 ";
            Program.mw.textBox_outByTools_operator.ForeColor = Color.Gray;
            Program.mw.textBox_outByTools_operator.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_repairtoolsIn_operator.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_outByTools_borrowerName.Text = "";
            Program.mw.textBox_outByTools_borrowerContact.Text = "";
            Program.mw.textBox_outByTools_borrowLine.Text = "";
            Program.mw.textBox_outByTools_borrowStation.Text = "";
            Program.mw.textBox_outByTools_operatorName.Text = "";
            Program.mw.textBox_outByTools_operatorContact.Text = "";
            Program.mw.textBox_outByTools_usage.Text = "";
        }

        /****************************************     按机型方式出库界面     *************************************/

    }
}

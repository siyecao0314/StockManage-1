using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using nsDBConnection;
using nsMainWindow;

//工装入库类
namespace nsStockManage
{
    class ToolsIn
    {
        DBConnection connection = new DBConnection();
        DataSet ds = null;
        String sql = null;
      //  DateTime dateNow = DateTime.Now;

        /*****************************************    新购工装入库界面     *************************************/


        //新购工装入库界面文本框默认值函数
        public void comboBox_newToolsIn_lifetype_SelectedIndexChanged()  //额定寿命类型选取
        {
            if (Program.mw.comboBox_newToolsIn_lifetype.Text == "时间")
            {
                Program.mw.textBox_newToolsIn_lifespan.Text = "天 ";
                Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Gray;
                Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
            }
            if (Program.mw.comboBox_newToolsIn_lifetype.Text == "次数")
            {
                Program.mw.textBox_newToolsIn_lifespan.Text = "次 ";
                Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Gray;
                Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
            }
        }

        public void textBox_newToolsIn_lifespan_Enter()                 //新购工装入库界面 额定寿命 文本框默认值
        {
            if ((Program.mw.textBox_newToolsIn_lifespan.Text == "天 ") || (Program.mw.textBox_newToolsIn_lifespan.Text == "次 "))
            {
                Program.mw.textBox_newToolsIn_lifespan.Text = "";
                Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Black;
                Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_newToosIn_lifespan_Leave()
        {
            if ((String.IsNullOrEmpty(Program.mw.textBox_newToolsIn_lifespan.Text)) && (Program.mw.comboBox_newToolsIn_lifetype.Text == "时间"))
            {
                Program.mw.textBox_newToolsIn_lifespan.Text = "天 ";
                Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Gray;
                Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
            }
            if ((String.IsNullOrEmpty(Program.mw.textBox_newToolsIn_lifespan.Text)) && (Program.mw.comboBox_newToolsIn_lifetype.Text == "次数"))
            {
                Program.mw.textBox_newToolsIn_lifespan.Text = "次 ";
                Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Gray;
                Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
            }
        }
        public void textBox_newToosIn_price_Enter()                 //新购工装入库界面 单价 文本框默认值
        {
            if (Program.mw.textBox_newToolsIn_price.Text == "元 ")
            {
                Program.mw.textBox_newToolsIn_price.Text = "";
                Program.mw.textBox_newToolsIn_price.ForeColor = Color.Black;
                Program.mw.textBox_newToolsIn_price.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_newToosIn_price_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_newToolsIn_price.Text))
            {
                Program.mw.textBox_newToolsIn_price.Text = "元 ";
                Program.mw.textBox_newToolsIn_price.ForeColor = Color.Gray;
                Program.mw.textBox_newToolsIn_price.TextAlign = HorizontalAlignment.Right;
            }
        }
        public void textBox_newToolsIn_price_KeyPress(KeyPressEventArgs e)       //限制价格编辑框只能输入数字和小数点
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)    //非数字和小数点不做处理
                e.Handled = true;

            if ((int)e.KeyChar == 46)                                     //小数点的处理
            {
                if (Program.mw.textBox_newToolsIn_lifespan.Text.Length <= 0)
                    e.Handled = true;                                     //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(Program.mw.textBox_newToolsIn_lifespan.Text, out oldf);
                    b2 = float.TryParse(Program.mw.textBox_newToolsIn_lifespan.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        public void textBox_newToosIn_operator_Enter()              //新购工装入库界面 操作人 文本框默认值
        {
            if (Program.mw.textBox_newToolsIn_operator.Text == "员工编号 ")
            {
                Program.mw.textBox_newToolsIn_operator.Text = "";
                Program.mw.textBox_newToolsIn_operator.ForeColor = Color.Black;
                Program.mw.textBox_newToolsIn_operator.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_newToosIn_operator_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_newToolsIn_operator.Text))
            {
                Program.mw.textBox_newToolsIn_operator.Text = "员工编号 ";
                Program.mw.textBox_newToolsIn_operator.ForeColor = Color.Gray;
                Program.mw.textBox_newToolsIn_operator.TextAlign = HorizontalAlignment.Right;
            }
        }

        //是否批量入库状态变化函数
        public void checkBox_batch_CheckedChanged()
        {
            if (Program.mw.checkBox_newToolsIn_batch.Checked == false)     //非批量入库
            {
                Program.mw.textBox_newToolsIn_endCode.BackColor = System.Drawing.Color.LightGray;     //结尾编码变灰
                Program.mw.textBox_newToolsIn_endCode.ReadOnly = true;                                //结尾编码只读
            }
            if (Program.mw.checkBox_newToolsIn_batch.Checked == true)     //批量入库
            {
                Program.mw.textBox_newToolsIn_endCode.BackColor = Color.White;                        //结尾编码变白 
                Program.mw.textBox_newToolsIn_endCode.ReadOnly = false;                              //结尾编码可编辑
            }
        }

        //编码文本框回车函数
        public void textBox_newToolsIn_code_KeyPress(char e)
        {
            if (e == (char)Keys.Enter)
            {
                if (Program.mw.checkBox_newToolsIn_batch.Checked == true)                //焦点跳转
                {
                    Program.mw.textBox_newToolsIn_endCode.Focus();
                }
                else
                {
                    Program.mw.textBox_newToolsIn_operator.Focus();
                }
                return;
            }
        }
        //编码文本框失去焦点函数
        public void textBox_newToolsIn_code_Leave()
        {
            String code = Program.mw.textBox_newToolsIn_code.Text;
            String[] temp = null;
            String category;
            String materialNumber;
            String number;

            if (CommonFunction.checkCodeLegality(code))                //判断编码合法性
            {
                temp = code.Split('-');
                category = temp[0];
                materialNumber = temp[1];
                number = temp[2];

                Program.mw.textBox_newToolsIn_materialNumber.Text = materialNumber;

                sql = "select * from tools where materialNumber='" + materialNumber + "' order by idTools DESC limit 1";  //自动填充已知信息
                ds = connection.Select(sql);
                if (ds.Tables[0].Rows[0] != null)
                {
                    Program.mw.textBox_newToolsIn_manufacturer.Text = ds.Tables[0].Rows[0][17].ToString();
                    Program.mw.comboBox_newToolsIn_lifetype.Text = ds.Tables[0].Rows[0][19].ToString();
                    Program.mw.textBox_newToolsIn_lifespan.Text = ds.Tables[0].Rows[0][20].ToString();
                    Program.mw.textBox_newToolsIn_price.Text = ds.Tables[0].Rows[0][18].ToString();

                    Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Black;
                    Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Left;
                    Program.mw.textBox_newToolsIn_price.ForeColor = Color.Black;
                    Program.mw.textBox_newToolsIn_price.TextAlign = HorizontalAlignment.Left;
                }
            }
            else
            {
                MessageBox.Show("编码不合法！");
                Program.mw.textBox_newToolsIn_code.Text = "";
                Program.mw.textBox_newToolsIn_toolName.Text = "";
            }
            return;
        }

        //结尾编码回车函数
        public void textBox_newToolsIn_codeEnd_KeyPress(char e)
        {
            if (e == (char)Keys.Enter)
            {
                Program.mw.textBox_newToolsIn_operator.Focus();
                return;
            }
        }
        //结尾编码失去焦点函数
        public void textBox_newToolsIn_codeEnd_Leave()
        {
            String endCode = Program.mw.textBox_newToolsIn_endCode.Text;
            String startCode = Program.mw.textBox_newToolsIn_code.Text;
            if (CommonFunction.checkEndCodeLegality(startCode,endCode))
            {
                return;
            }
            else
            {
                MessageBox.Show("结尾编号不合法！");
                Program.mw.textBox_newToolsIn_endCode.Focus();
                return;
            }
        }

        ///////////////////////    新购工装入库确认按钮函数
        public bool newToolsIn_enter()
        {
            String toolName = Program.mw.textBox_newToolsIn_toolName.Text;
            String remarks = Program.mw.textBox_newToolsIn_remarks.Text;
            String functionState = Program.mw.comboBox_newToolsIn_functionState.Text;
            String code = Program.mw.textBox_newToolsIn_code.Text;
            String endCode = Program.mw.textBox_newToolsIn_endCode.Text;
            String materialNumber = Program.mw.textBox_newToolsIn_materialNumber.Text;
            String manufacturer = Program.mw.textBox_newToolsIn_manufacturer.Text;
            String purchaseDate = Program.mw.dateTimePicker_newToolsIn_purchaseDate.Text;
            String lifetype = Program.mw.comboBox_newToolsIn_lifetype.Text;
            String lifespan = Program.mw.textBox_newToolsIn_lifespan.Text;
            String price = Program.mw.textBox_newToolsIn_price.Text;
            String operator1 = Program.mw.textBox_newToolsIn_operator.Text;
            String name = Program.mw.textBox_newToolsIn_name.Text;                    //*未添加至数据库
            String contact = Program.mw.textBox_newToolsIn_contact.Text;                 //*未添加至数据库
            String area = Program.mw.textBox_newToolsIn_area.Text;
            String shelf = Program.mw.textBox_newToolsIn_shelf.Text;
            String layer = Program.mw.textBox_newToolsIn_layer.Text;

            String[] temp = code.Split('-');
            String category = temp[0];
            String materialNumber1 = temp[1];
            String number = temp[2];

            //校验各项数据
            if (!CommonFunction.checkCodeLegality(code))
            {
                MessageBox.Show("编码不合法！");
                return false;
            }
            if (Program.mw.checkBox_newToolsIn_batch.Checked)
            {
                String startNumber = code.Substring(code.Length - 4, 4);
                String endNumber = endCode.Substring(endCode.Length - 4, 4);
                if (!CommonFunction.checkEndCodeLegality(code, endCode))
                {
                    MessageBox.Show("结尾编码不合法！");
                    return false;
                }
                if(int.Parse(endNumber) - int.Parse(startNumber) > 1000)
                {
                    MessageBox.Show("批量入库不允许超过1000件/次！");
                    return false;
                }
            }

            if (!Program.mw.checkBox_newToolsIn_batch.Checked)              //非批量入库
            {
                try
                {
                    sql = @"insert into tools 
                       (toolName,code,category,materialNumber,number,area,shelf,layer,storageState,operator,name,functionState,manufacturer,price,lifeType,lifeSpan,lifeLeft,purchaseDate,remarks) 
                        values (
                                 '" + toolName + "'," +
                                "'" + code + "'," +
                                "'" + category + "'," +
                                "'" + materialNumber + "'," +
                                "'" + number + "'," +
                                "'" + area + "'," +
                                "'" + shelf + "'," +
                                "'" + layer + "'," +
                                "'" + "未上架" + "'," +
                                "'" + operator1 + "'," +
                                "'" + name + "'," +
                                "'" + functionState + "'," +
                                "'" + manufacturer + "'," +
                                "'" + price + "'," +
                                "'" + lifetype + "'," +
                                "'" + lifespan + "'," +
                                "'" + lifespan + "'," +
                                "'" + purchaseDate + "'," +
                                "'" + remarks + "')";

                    connection.Insert(sql);

                    sql = @"insert into records 
                                   (toolName,code,category,materialNumber,number,area,shelf,layer,functionState,lifetype,lifespan,lifeleft,operationType,operationDate,operationTime,operator,name,userName,remarks) 
                            values (
                                     '" + toolName + "'," +
                                    "'" + code + "'," +
                                    "'" + category + "'," +
                                    "'" + materialNumber + "'," +
                                    "'" + number + "'," +
                                    "'" + area + "'," +
                                    "'" + shelf + "'," +
                                    "'" + layer + "'," +
                                    "'" + functionState + "'," +
                                    "'" + lifetype + "'," +
                                    "'" + lifespan + "'," +
                                    "'" + lifespan + "'," +
                                    "'" + "新购入库" + "'," +
                                    "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," +
                                    "'" + DateTime.Now.ToString("hh:mm:ss") + "'," +
                                    "'" + operator1 + "'," +
                                    "'" + name + "'," +
                                    "'" + MainWindow.TerminalNumber + "'," +
                                    "'" + remarks + "')";

                    connection.Insert(sql);

                    fillListView_newToolsIn(Program.mw.listView_newToolsIn);
                    connection.Close();
                    return true;
                }
                catch
                {
                    MessageBox.Show("数据保存失败！");
                    return false;
                }
            }
            else                    //批量入库
            {
                String startNumber = code.Substring(code.Length - 5);         //把序号的年份字母去除
                String endNumber = endCode.Substring(code.Length - 5);
                try
                {
                    sql = @"insert into tools 
                       (toolName,code,category,materialNumber,number,area,shelf,layer,storageState,operator,name,functionState,manufacturer,price,lifeType,lifeSpan,lifeLeft,purchaseDate,remarks) 
                        values (
                                 '" + toolName + "'," +
                                "'" + code + "'," +
                                "'" + category + "'," +
                                "'" + materialNumber + "'," +
                                "'" + number + "'," +
                                "'" + area + "'," +
                                "'" + shelf + "'," +
                                "'" + layer + "'," +
                                "'" + "未上架" + "'," +
                                "'" + operator1 + "'," +
                                "'" + name + "'," +
                                "'" + functionState + "'," +
                                "'" + manufacturer + "'," +
                                "'" + price + "'," +
                                "'" + lifetype + "'," +
                                "'" + lifespan + "'," +
                                "'" + lifespan + "'," +
                                "'" + purchaseDate + "'," +
                                "'" + remarks + "')";

                    for (int i = 1; i <= (int.Parse(endNumber) - int.Parse(startNumber) + 1); i++)              //插入其余条
                    {
                        connection.Insert(sql);
                        code = code.Remove(code.Length - 5) + (int.Parse(startNumber) + i).ToString().PadLeft(5, '0'); //SQL字符串需手动更新一下
                        number = code.Substring(code.Length - 6) ;
                        sql = @"insert into tools 
                                       (toolName,code,category,materialNumber,number,area,shelf,layer,storageState,operator,name,functionState,manufacturer,price,lifeType,lifeSpan,lifeLeft,purchaseDate,remarks) 
                                values (
                                         '" + toolName + "'," +
                                        "'" + code + "'," +
                                        "'" + category + "'," +
                                        "'" + materialNumber + "'," +
                                        "'" + number + "'," +
                                        "'" + area + "'," +
                                        "'" + shelf + "'," +
                                        "'" + layer + "'," +
                                        "'" + "未上架" + "'," +
                                        "'" + operator1 + "'," +
                                        "'" + name + "'," +
                                        "'" + functionState + "'," +
                                        "'" + manufacturer + "'," +
                                        "'" + price + "'," +
                                        "'" + lifetype + "'," +
                                        "'" + lifespan + "'," +
                                        "'" + lifespan + "'," +
                                        "'" + purchaseDate + "'," +
                                        "'" + remarks + "')";
                    }

                    sql = @"insert into records 
                                   (toolName,code,category,materialNumber,number,area,shelf,layer,functionState,lifetype,lifespan,lifeleft,operationType,operationDate,operationTime,operator,name,userName,remarks) 
                            values (
                                 '" + toolName + "'," +
                                "'" + Program.mw.textBox_newToolsIn_code.Text + "'," +
                                "'" + category + "'," +
                                "'" + materialNumber + "'," +
                                "'" + number + "'," +
                                "'" + area + "'," +
                                "'" + shelf + "'," +
                                "'" + layer + "'," +
                                "'" + functionState + "'," +
                                "'" + lifetype + "'," +
                                "'" + lifespan + "'," +
                                "'" + lifespan + "'," +
                                "'" + "新购入库" + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," +
                                "'" + DateTime.Now.ToString("hh:mm:ss") + "'," +
                                "'" + operator1 + "'," +
                                "'" + name + "'," +
                                "'" + MainWindow.TerminalNumber + "'," +
                                "'" + remarks + "（批量入库，从" + Program.mw.textBox_newToolsIn_code.Text + "到" + endCode +"）"+ "')";

                    connection.Insert(sql);

                    fillListView_newToolsIn(Program.mw.listView_newToolsIn);
                    return true;
                }
                catch
                {
                    MessageBox.Show("数据保存失败！");
                    connection.Close();
                    return false;
                }

            }

        }

        //清除功能
        public void newToolsInCleanAll()
        {
            Program.mw.textBox_newToolsIn_materialNumber.Text = "";
            Program.mw.textBox_newToolsIn_manufacturer.Text = "";
            Program.mw.dateTimePicker_newToolsIn_purchaseDate.ResetText();
            Program.mw.textBox_newToolsIn_lifespan.Text = "";
            Program.mw.textBox_newToolsIn_price.Text = "";
            Program.mw.textBox_newToolsIn_operator.Text = "";
            Program.mw.textBox_newToolsIn_name.Text = "";
            Program.mw.textBox_newToolsIn_contact.Text = "";
            Program.mw.textBox_newToolsIn_area.Text = "";
            Program.mw.textBox_newToolsIn_shelf.Text = "";
            Program.mw.textBox_newToolsIn_layer.Text = "";
            Program.mw.textBox_newToolsIn_toolName.Text = "";
            Program.mw.textBox_newToolsIn_code.Text = "";
            Program.mw.textBox_newToolsIn_remarks.Text = "";
            Program.mw.textBox_newToolsIn_endCode.Text = "";
            Program.mw.comboBox_newToolsIn_functionState.Text = "正常";
            Program.mw.comboBox_newToolsIn_lifetype.Text = "时间";
            Program.mw.textBox_newToolsIn_lifespan.Text = "天 ";
            Program.mw.textBox_newToolsIn_lifespan.ForeColor = Color.Gray;
            Program.mw.textBox_newToolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_newToolsIn_price.Text = "元 ";
            Program.mw.textBox_newToolsIn_price.ForeColor = Color.Gray;
            Program.mw.textBox_newToolsIn_price.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_newToolsIn_operator.Text = "员工编号 ";
            Program.mw.textBox_newToolsIn_operator.ForeColor = Color.Gray;
            Program.mw.textBox_newToolsIn_operator.TextAlign = HorizontalAlignment.Right;
        }
        
        ///////////////////////    绘制数据表格
        public void drawListView_newToolsIn(ListView listview)
        {
            listview.Clear();
            int listViewWidth = Screen.PrimaryScreen.Bounds.Width - listview.Location.X * 2 - Program.mw.toolStrip1.Width;
            int listViewHeight = Screen.PrimaryScreen.Bounds.Height - listview.Location.Y - Program.mw.statusStrip1.Height - Program.mw.menuStrip1.Height - 85;
            int listViewColumnWidth = listViewWidth / 12;
            listview.Size = new System.Drawing.Size(listViewWidth, listViewHeight);
            listview.Font = new System.Drawing.Font("微软雅黑", 8F);
            listview.GridLines = true;
            listview.View = View.Details;
            listview.HeaderStyle = ColumnHeaderStyle.Clickable;//表头样式
            listview.FullRowSelect = true;//表示在控件上，是否可以选择一整行
            listview.Columns.Add("", 0, HorizontalAlignment.Center); //添加（列宽度、列的对齐方式）
            listview.Columns.Add("序号", listViewColumnWidth, HorizontalAlignment.Center); //添加（列宽度、列的对齐方式）
            listview.Columns.Add("工装名称", listViewColumnWidth, HorizontalAlignment.Center); //添加（列宽度、列的对齐方式）
            listview.Columns.Add("工装编码", listViewColumnWidth, HorizontalAlignment.Center); //添加
            listview.Columns.Add("物料号", listViewColumnWidth, HorizontalAlignment.Center); //添加
            listview.Columns.Add("厂家", listViewColumnWidth, HorizontalAlignment.Center); //添加（列宽度、列的对齐方式）
            listview.Columns.Add("单价", listViewColumnWidth, HorizontalAlignment.Center); //添加
            listview.Columns.Add("额定寿命", listViewColumnWidth, HorizontalAlignment.Center); //添加
            listview.Columns.Add("购入日期", listViewColumnWidth, HorizontalAlignment.Center); //添加（列宽度、列的对齐方式）
            listview.Columns.Add("操作人", listViewColumnWidth, HorizontalAlignment.Center); //添加
            listview.Columns.Add("姓名", listViewColumnWidth, HorizontalAlignment.Center); //添加
            listview.Columns.Add("备注", listViewWidth - 11 * listViewColumnWidth, HorizontalAlignment.Center);
            /*  displaySheet.Location = new System.Drawing.Point(90, 40);
            displaySheet.Size= new System.Drawing.Size(100,100);
            this.Controls.Add(displaySheet);*/
            //this.listView1.BeginUpdate();  //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
        }

        ///////////////////////    填充数据
        public void fillListView_newToolsIn(ListView listview)
        {
            listview.Items.Clear();
            sql = "select * from tools order by idTools DESC limit 20";
            ds = connection.Select(sql);
            int i = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.SubItems.Add(row[0].ToString());            //序号
                lvi.SubItems.Add(row[1].ToString());            //名称
                lvi.SubItems.Add(row[2].ToString());            //编码
                lvi.SubItems.Add(row[4].ToString());            //物料号
                lvi.SubItems.Add(row[18].ToString());           //厂家
                lvi.SubItems.Add(row[19].ToString());           //单价
                lvi.SubItems.Add(row[21].ToString());           //寿命
                lvi.SubItems.Add(row[25].ToString());           //购入日期
                lvi.SubItems.Add(row[13].ToString());           //操作人
                lvi.SubItems.Add(row[14].ToString());           //姓名
                lvi.SubItems.Add(row[28].ToString());           //备注
                listview.Items.Add(lvi);
                i++;
            }
            listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);   // 填充完数据之后，列宽设置为自适应
            listview.Columns[0].Width = 0;
            connection.Close();
        }

        /********************************************************领用归还界面******************************************************/

        //清除功能
        public void toolsReturnCleanALL()
        {
            Program.mw.textBox_toolsReturn_materialNumber.Text = "";
            Program.mw.dateTimePicker_toolsReturn_returnTime.ResetText();
            Program.mw.textBox_toolsReturn_returnLine.Text = "";
            Program.mw.textBox_toolsReturn_operator.Text = "";
            Program.mw.textBox_toolsReturn_name.Text = "";
            Program.mw.textBox_toolsReturn_contact.Text = "";
            Program.mw.textBox_toolsReturn_return.Text = "";
            Program.mw.textBox_toolsReturn_area.Text = "";
            Program.mw.textBox_toolsReturn_shelf.Text = "";
            Program.mw.textBox_toolsReturn_layer.Text = "";
            Program.mw.textBox_toolsReturn_toolName.Text = "";
            Program.mw.textBox_toolsReturn_code.Text = "";
            Program.mw.textBox_toolsReturn_remarks.Text = "";
            Program.mw.textBox_toolsReturnOperator_name.Text = "";
            Program.mw.textBox_toolsReturnOperator_contact.Text = "";
            Program.mw.textBox_toolsReturn_operator.Text = "";
            Program.mw.comboBox_toolsReturn_functionState.Text = "正常";
            Program.mw.textBox_toolsReturn_operator.Text = "员工编号 ";
            Program.mw.textBox_toolsReturn_operator.ForeColor = Color.Gray;
            Program.mw.textBox_toolsReturn_operator.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_toolsReturn_return.Text = "员工编号 ";
            Program.mw.textBox_toolsReturn_return.ForeColor = Color.Gray;
            Program.mw.textBox_toolsReturn_return.TextAlign = HorizontalAlignment.Right;
        }

        //领用归还界面 归还人 文本框默认值函数
        public void textBox_toolsReturn_return_Enter()
        {
            if (Program.mw.textBox_toolsReturn_return.Text == "员工编号 ")
            {
                Program.mw.textBox_toolsReturn_return.Text = "";
                Program.mw.textBox_toolsReturn_return.ForeColor = Color.Black;
                Program.mw.textBox_toolsReturn_return.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_toolsReturn_return_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_toolsReturn_return.Text))
            {
                Program.mw.textBox_toolsReturn_return.Text = "员工编号 ";
                Program.mw.textBox_toolsReturn_return.ForeColor = Color.Gray;
                Program.mw.textBox_toolsReturn_return.TextAlign = HorizontalAlignment.Right;
            }
        }
        //领用归还界面 操作人 文本框默认值函数
        public void textBox_toolsReturn_operator_Enter()
        {
            if (Program.mw.textBox_toolsReturn_operator.Text == "员工编号 ")
            {
                Program.mw.textBox_toolsReturn_operator.Text = "";
                Program.mw.textBox_toolsReturn_operator.ForeColor = Color.Black;
                Program.mw.textBox_toolsReturn_operator.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_toolsReturn_operator_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_toolsReturn_operator.Text))
            {
                Program.mw.textBox_toolsReturn_operator.Text = "员工编号 ";
                Program.mw.textBox_toolsReturn_operator.ForeColor = Color.Gray;
                Program.mw.textBox_toolsReturn_operator.TextAlign = HorizontalAlignment.Right;
            }
        }

        /********************************************************维修入库界面******************************************************/

        //清除功能
        public void toolsRepairCleanALL()
        {
            Program.mw.textBox_repairtoolsIn_code.Text = "";
            Program.mw.textBox_repairtoolsIn_toolName.Text = "";
            Program.mw.comboBox_repairtoolsIn_functionState.Text = "正常";
            Program.mw.textBox_repairtoolsIn_remarks.Text = "";
            
            Program.mw.textBox_repairtoolsIn_manufacturer.Text = "";
            Program.mw.dateTimePicker_repairtoolsIn_repairDate.ResetText();
            Program.mw.comboBox_repairtoolsIn_lifetype.Text = "时间";
            Program.mw.textBox_repairtoolsIn_area.Text = "";
            Program.mw.textBox_repairtoolsIn_layer.Text = "";
            Program.mw.textBox_repairtoolsIn_shelf.Text = "";
            Program.mw.textBox_repairtoolsIn_materialNumber.Text = "";
            Program.mw.textBox_repairtoolsIn_lifespan.Text = "天 ";
            Program.mw.textBox_repairtoolsIn_lifespan.ForeColor = Color.Gray;
            Program.mw.textBox_repairtoolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
            Program.mw.textBox_repairtoolsIn_repairTimes.Text = "";
            Program.mw.textBox_repairtoolsIn_repairTimes.Text = "";
            Program.mw.textBox_repairtoolsIn_name.Text = "";
            Program.mw.textBox_repairtoolsIn_contact.Text = "";
            Program.mw.textBox_repairtoolsIn_operator.Text = "员工编号 ";
            Program.mw.textBox_repairtoolsIn_operator.ForeColor = Color.Gray;
            Program.mw.textBox_repairtoolsIn_operator.TextAlign = HorizontalAlignment.Right;
        }
        public void textBox_repairtoolsIn_operator_Leave()
        {
            if (String.IsNullOrEmpty(Program.mw.textBox_repairtoolsIn_operator.Text))
            {
                Program.mw.textBox_repairtoolsIn_operator.Text = "员工编号 ";
                Program.mw.textBox_repairtoolsIn_operator.ForeColor = Color.Gray;
                Program.mw.textBox_repairtoolsIn_operator.TextAlign = HorizontalAlignment.Right;
            }
        }
        public void textBox_repairtoolsIn_operator_Enter()
        {
            if (Program.mw.textBox_repairtoolsIn_operator.Text == "员工编号 ")
            {
                Program.mw.textBox_repairtoolsIn_operator.Text = "";
                Program.mw.textBox_repairtoolsIn_operator.ForeColor = Color.Black;
                Program.mw.textBox_repairtoolsIn_operator.TextAlign = HorizontalAlignment.Left;
            }
        }
        public void textBox_repairtoolsIn_lifespan_Enter()
        {
            if (Program.mw.comboBox_repairtoolsIn_lifetype.Text == "时间")
            {
                if (Program.mw.textBox_repairtoolsIn_lifespan.Text == "天 ")
                {
                    Program.mw.textBox_repairtoolsIn_lifespan.Text = "";
                    Program.mw.textBox_repairtoolsIn_lifespan.ForeColor = Color.Black;
                    Program.mw.textBox_repairtoolsIn_lifespan.TextAlign = HorizontalAlignment.Left;
                }
            }
            else
            {
                if (Program.mw.textBox_repairtoolsIn_lifespan.Text == "次 ")
                {
                    Program.mw.textBox_repairtoolsIn_lifespan.Text = "";
                    Program.mw.textBox_repairtoolsIn_lifespan.ForeColor = Color.Black;
                    Program.mw.textBox_repairtoolsIn_lifespan.TextAlign = HorizontalAlignment.Left;
                }
            } 
        }
        public void textBox_repairtoolsIn_lifespan_Leave()
        {
            if(Program.mw.comboBox_repairtoolsIn_lifetype.Text == "时间")
            {
                if (String.IsNullOrEmpty(Program.mw.textBox_repairtoolsIn_lifespan.Text))
                {
                    Program.mw.textBox_repairtoolsIn_lifespan.Text = "天 ";
                    Program.mw.textBox_repairtoolsIn_lifespan.ForeColor = Color.Gray;
                    Program.mw.textBox_repairtoolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(Program.mw.textBox_repairtoolsIn_lifespan.Text))
                {
                    Program.mw.textBox_repairtoolsIn_lifespan.Text = "次 ";
                    Program.mw.textBox_repairtoolsIn_lifespan.ForeColor = Color.Gray;
                    Program.mw.textBox_repairtoolsIn_lifespan.TextAlign = HorizontalAlignment.Right;
                }
            }
        }   
    }
}

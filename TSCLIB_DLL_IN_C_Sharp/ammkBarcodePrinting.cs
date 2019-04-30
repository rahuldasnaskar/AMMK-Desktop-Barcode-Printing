using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class barcodePrinting : Form
    {
        public barcodePrinting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] result = System.Text.Encoding.GetEncoding("utf-16").GetBytes("unicode test");

            //TSCLIB_DLL.about();
            TSCLIB_DLL.openport("TSC TA210");
            TSCLIB_DLL.sendcommand("SIZE 76 mm, 20 mm");
            TSCLIB_DLL.sendcommand("SPEED 4");
            TSCLIB_DLL.sendcommand("DENSITY 12");
		    TSCLIB_DLL.sendcommand("DIRECTION 1");
            TSCLIB_DLL.sendcommand("SET TEAR ON");
            TSCLIB_DLL.clearbuffer();
            TSCLIB_DLL.barcode("335", "30", "128", "100", "1", "0", "2", "2", "3410156300419176");
            TSCLIB_DLL.barcode("35", "30", "128", "100", "1", "0", "2", "2", "3410156300419176");
            //TSCLIB_DLL.printerfont("100", "250", "3", "0", "1", "1", "Print Font Test");
            //TSCLIB_DLL.windowsfont(100, 300, 24, 0, 0, 0, "ARIAL", "Windows Arial Font Test");
            //TSCLIB_DLL.windowsfontUnicode(100, 350, 24, 0, 0, 0, "ARIAL", result);
            TSCLIB_DLL.downloadpcx("UL.PCX", "UL.PCX");
            TSCLIB_DLL.sendcommand("PUTPCX 100,400,\"UL.PCX\"");
            TSCLIB_DLL.printlabel("4","4");
            TSCLIB_DLL.closeport();
            
        }

    }
}
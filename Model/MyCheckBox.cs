using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Model
{
    public class MyCheckBox : CheckBox
    {
        public MyCheckBox(string text, bool state, int y)
        {
            this.AutoSize = true;
            this.Text = text;
            this.Checked = state;
            this.Location = new Point(10, y);
        }
    }
}

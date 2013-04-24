using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Frame
{
    public partial class paintMax : Form
    {
        public paintMax(Image img)
        {
            InitializeComponent();

            pictureBox1.Image = img;
        }

    }
}

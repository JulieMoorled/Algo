using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form2 : Form
    {
        public Form2(Image selectedImage)
        {

            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox1.Image = Image.FromFile(@"C:\Users\Юлия\Desktop\algo\random\userpic.jpg");
            pictureBox2.Image = selectedImage;

            label1.Text = "Username";
            label1.Font = new Font("Century Gothic", 14.0F);

        }
    }
}

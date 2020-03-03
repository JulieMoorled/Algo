using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public void ReadAllFiles (string path)
        {
            string[] imageFileNames = Directory.GetFiles(path);
            Image[] images = new Image[imageFileNames.Length];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = Image.FromFile(imageFileNames[i]); 
            }
        }

        public void ImagesToDataGridView()
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            dataGridView1.Columns.Add(imageColumn);
            imageColumn.Name = "imageColumn";
            
        }

        public Form1()
        {

            InitializeComponent();

            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //dataGridView1.Columns.Add(imageColumn);
            //imageColumn.Name = "imageColumn";
            imageColumn.Width = 200;

            Image images [] = ReadAllFiles(@"C:\Users\Юлия\Desktop\algo\images", "*.jpg", SearchOption.AllDirectories);
            dataGridView1.RowCount = imageFileNames.Length;

            for (int i = 0; i < images.Length; i++)
            {
                //images[i] = Image.FromFile(imageFileNames[i]);
                dataGridView1.Rows[i].Height = 200;
                dataGridView1.Rows[i].Cells["imageColumn"].Value = images[i];
            }


            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewImageCell cell = (DataGridViewImageCell) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
            

            //Form2 form2 = new Form2(a);
            //form2.Parent = this.Parent;
            //form2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = "Username";
            label1.Font = new Font("Century Gothic", 14.0F);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"C:\Users\Юлия\Desktop\algo\random\userpic.jpg");

        }
    }
}

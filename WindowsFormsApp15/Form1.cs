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
        private Image[] ReadAllFiles (string path)
        {
            string[] imageFileNames = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            Image[] images = new Image[imageFileNames.Length];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = Image.FromFile(imageFileNames[i]); 
            }
            return images;
        }

        private DataGridView FillDataGridView(Image[] images)
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            dataGridView1.Columns.Add(imageColumn);
            imageColumn.Name = "imageColumn";
            imageColumn.Width = 200;
            dataGridView1.RowCount = images.Length;
            for (int i = 0; i < images.Length; i++)
            {
                dataGridView1.Rows[i].Height = 200;
                dataGridView1.Rows[i].Cells["imageColumn"].Value = images[i];
            }
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
                
                return dataGridView1;
        }

        public Form1()
        {

            InitializeComponent();

            Image[] images = ReadAllFiles(@"C:\Users\Юлия\Desktop\algo\images");
            FillDataGridView(images);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //DataGridViewImageCell cell = (DataGridViewImageCell) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

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

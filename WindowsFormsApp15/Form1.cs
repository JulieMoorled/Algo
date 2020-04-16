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
        private List<(string, Image)> imagesAndPaths = new List<(string, Image)>();

        private void ReadAllFiles (string path)
        {
            
            string[] imageFileNames = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            for (int i = 0; i < imageFileNames.Length; i++)
            {
               string[] filePath = (Path.GetFileName(imageFileNames[i])).Split('.');
               string fileName = filePath[0];
               Image image = Image.FromFile(imageFileNames[i]);
               (string, Image) tuple = (fileName, image);
               imagesAndPaths.Add(tuple);
            }
        }

        private void FillDataGridView(List<(string, Image)> imagesAndPaths)
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            dataGridView1.Columns.Add(imageColumn);
            imageColumn.Name = "imageColumn";
            imageColumn.Width = 200;

            dataGridView1.RowCount = imagesAndPaths.Count;
            for (int i = 0; i < imagesAndPaths.Count; i++)
            {
                dataGridView1.Rows[i].Height = 200;
                dataGridView1.Rows[i].Cells["imageColumn"].Value = imagesAndPaths[i].Item2;
            }
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
                
        }

        public Form1()
        {

            InitializeComponent();

            string path = (@"C:\Users\Юлия\Desktop\algo\images");
            
            ReadAllFiles(path);
            FillDataGridView(imagesAndPaths);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewImageCell cell = (DataGridViewImageCell) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
             Image selectedImage = imagesAndPaths[cell.RowIndex].Item2;
             string selectedImageName = imagesAndPaths[cell.RowIndex].Item1;
                    
            Form2 form2 = new Form2(selectedImage, selectedImageName);
            form2.Parent = this.Parent;
            form2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = "Username";
            label1.Font = new Font("Century Gothic", 14.0F);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"C:\Users\Юлия\Desktop\algo\random\userpic.png");

        }
    }
}

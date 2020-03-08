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
using System.Text.Json;

namespace WindowsFormsApp15
{

    public class Comment
    {
        private DateTime date;
        public class User
        {
            private string username; 
            private Image userpic;

            public User(string username, Image userpic)
            {
                this.username = username;
                this.userpic = userpic;
            }
        }
        private string text;

        public Comment(DateTime date, string text)
        {
            this.date = date;
            this.text = text;
        }
    }

    public class Comments
    {
        
        private List <Comment> comments = new List<Comment>();
        
        public void FromFile()
        {
            using (FileStream fs = new FileStream(@"C:\Users\Юлия\Desktop\algo\file.json", FileMode.OpenOrCreate))
            {
                Comments comment = await JsonSerializer.DeserializeAsync<Comments>(fs);
            }
        }

        public void ShowComment()
        {
            
        }

        public void AddComment()
        {
            Comments newComment = new Comments();
            // text = Form2.textBox1.Text;
            // date = DateTime.Now;
            comments.Add(newComment);
        }
        
        public void ToFile()
        {
            using (FileStream fs = new FileStream(@"C:\Users\Юлия\Desktop\algo\file.json", FileMode.OpenOrCreate))
            {
                //Comments newComment = new Comments();
                //{
                // date;
                // username;
                // userpic;
                // text;    
                //}
                await JsonSerializer.SerializeAsync<Comment>(fs, newComment);
            }
        }
        
    }
    

    public partial class Form2 : Form
    {
        public Form2(Image selectedImage, string selectedImageName)
        {

            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox1.Image = Image.FromFile(@"C:\Users\Юлия\Desktop\algo\random\userpic.png");
            pictureBox2.Image = selectedImage;
            
            label1.Text = "Username";
            label1.Font = new Font("Century Gothic", 14.0F);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

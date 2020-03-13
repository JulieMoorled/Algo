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
    public partial class Form2 : Form
      {
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

        public class Comment
        {
            private DateTime date;
            private string text;
            private User user;

            public Comment(string text, User user)
            {
                this.date = DateTime.Now;
                this.text = text;
                this.user = user;
            }
        }
        

        public class CommentsManager
        {
            
            private List <Comment> comments = new List<Comment>();
            
            public void FromFile()
            {
                using (FileStream fs = new FileStream(@"C:\Users\Юлия\Desktop\algo\file.json", FileMode.OpenOrCreate))
                {
                    CommentsManager comment = await JsonSerializer.DeserializeAsync<CommentsManager>(fs);
                }
            }

            public void ShowComment(int n, string text)
            {
                // ListView listView = new ListView();
                // listView.Location = new Point(1, 1);
                // this.Controls.Add(listView);
                n = comments.Count + 1;
                listView1.Items.Add(text, n);
            }

            public void AddComment()
            {
                string text = textBox1.Text;
                User user = new User(label1.Text, pictureBox1.Image);
                Comment newComment = new Comment(text, user);
                comments.Add(newComment);
                textBox1.Clear();
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            
        }
        
    }
}

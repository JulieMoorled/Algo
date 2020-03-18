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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp15
{
    
    public class User
        {
            string _username;
            Image _userpic;
            
            public string username { get; set; }
            public Image userpic { get; set; }

            public User(string username, Image userpic)
            {
                this.username = username;
                this.userpic = userpic;
            }
        }

        public class Comment
        {
            DateTime _date;
            string _text;
            User _user;
            
            public DateTime date { get; set; }
            public string text { get; set; }
            public User user { get; set; }

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
            string serialized;
            
            public void AddComment()
            {
                string text = textBox1;
                User user = new User(label1.Text, pictureBox1.Image);
                Comment newComment = new Comment(text, user);
                comments.Add(newComment);
                textBox1.Clear();
            }
            
            public void ToFile()
            {
                Comment comment = new Comment(text, user);
                serialized = JsonConvert.SerializeObject(comment);
                File.WriteAllText(@"C:\Users\Юлия\Desktop\algo\random\userpic.png", serialized, Encoding.GetEncoding(1251));
            }
            
            public void FromFile()
            {
                serialized = File.ReadAllText(@"C:\Users\Юлия\Desktop\algo\file.json", Encoding.GetEncoding(1251));
                dynamic json = JObject.Parse(serialized);
                date = json.Comments[0].Date;
                text = json.Comments[0].Text;
                user = json.Comments[0].User;
                    //что-то нужно сделать с юзером (
                    //и поменять индексы кста
            }

            public void ShowComment(int n, string text)
            {
                n = comments.Count;
                listView1.Items.Add(text, n);
            }

        }
    
    public partial class Form2 : Form 
      {
        
          public string getTextBox()
          {
            return textBox1.Text;
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

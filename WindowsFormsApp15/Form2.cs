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
            
            public List <Comment> comment { get; set; }

            public CommentsManager(List <Comment> comment)
            {
                this.comment = comment;
            }
            
            string serialized;
            
            public void ToFile()
            {
                serialized = JsonConvert.SerializeObject(comment);
                File.WriteAllText(@"C:\Users\Юлия\Desktop\algo\random\userpic.png", serialized, Encoding.GetEncoding(1251));
            }
            
            public void FromFile()
            {
                serialized = File.ReadAllText(@"C:\Users\Юлия\Desktop\algo\file.json", Encoding.GetEncoding(1251));
                dynamic json = JObject.Parse(serialized);
                for (int i = 0; i < comment.Count; i++)
                {
                    comment[i].date = json.Comments[i].Date;
                    comment[i].text = json.Comments[i].Text;
                    comment[i].user = json.Comments[i].User;
                }
                //что-то нужно сделать с юзером (
            }

        }
    
    public partial class Form2 : Form 
      {
          
          public List <Comment> comments = new List<Comment>();
        
          public void AddComment()
          {
              string text = textBox1.Text;
              User user = new User(label1.Text, pictureBox1.Image);
              Comment newComment = new Comment(text, user);
              comments.Add(newComment);
              textBox1.Clear();
          }
          
          public void ShowComment(string text, DateTime date)
          {
              int n = comments.Count;
              string newComment = text + date;
              listView1.Items.Add(text, n);
              //подумоц
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
            AddComment();
            // CommentsManager newComments = new CommentsManager(comments);
            // ShowComment();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
            CommentsManager newComments = new CommentsManager(comments);
            for (int i = 0; i < comments.Count; i++)
                
            {
                string commentText[] = comments.text[i];
                //DateTime commentDate[] = 
                ShowComment(commentText[i]);
            }
        }
      }
}

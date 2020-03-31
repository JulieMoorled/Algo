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

            public string username;
            public Image userpic;

            public User(string username, Image userpic)
            {
                this.username = username;
                this.userpic = userpic;
            }
        }

        public class Comment
        {

            public DateTime date;
            public string text;
            public User user;

            public Comment(string text, User user)
            {
                this.date = DateTime.Now;
                this.text = text;
                this.user = user;
            }
        }

        public class CommentsManager
        {

            public List<Comment> comments;

            public CommentsManager(List <Comment> comments)
            {
                this.comments = comments;
            }
            
            string serialized;
            
            public void ToFile()
            {
                serialized = JsonConvert.SerializeObject(comments);
                File.WriteAllText(@"C:\Users\Юлия\Desktop\algo\random\userpic.png", serialized, Encoding.GetEncoding(1251));
            }
            
            public void FromFile()
            {
                serialized = File.ReadAllText(@"C:\Users\Юлия\Desktop\algo\file.json", Encoding.GetEncoding(1251));
                dynamic json = JObject.Parse(serialized);
                for (int i = 0; i < comments.Count; i++)
                {
                    comments[i].date = json.Comments[i].Date;
                    comments[i].text = json.Comments[i].Text;
                    comments[i].user.username = json.Comments[i].User.Username;
                    comments[i].user.userpic = json.Comments[i].User.Userpic;
                }
            }
        }
    
        public class CommentsViewManager
        {
            public List<CommentView> commentViews;
            public Panel commentsPanel;

            public CommentsViewManager(List <Comment> comments)
            {
                commentsPanel.Location = new Point(446, 103);
                commentsPanel.Size = new System.Drawing.Size(160, 350);
                Form2.ActiveForm.Controls.Add(commentsPanel);
                
                for (int i = 0; i < comments.Count; i++)
                {
                    CommentView commentView = new CommentView(comments[i]);
                    commentViews.Add(commentView);
                }

            }
        }
        
        public class CommentView
        {
            public Panel commentPanel;
            public Label username;
            public PictureBox userpic;
            public Label text;

            public CommentView(Comment comment)
            {
                username.Text = comment.user.username;
                userpic.Image = comment.user.userpic;
                text.Text = comment.text;
                
                commentPanel.Location = new Point(5, 5);
                commentPanel.Size = new System.Drawing.Size(150, 40);
                this.commentsPanel.Controls.Add(commentPanel);
                
                username.Location = new Point(50, 2);
                username.Font = new Font("Century Gothic", 07.0F);
                commentPanel.Controls.Add(username);
                
                userpic.Location = new Point(5, 5);
                userpic.Size = new System.Drawing.Size(30, 30);
                userpic.SizeMode = PictureBoxSizeMode.StretchImage;
                commentPanel.Controls.Add(userpic);
                
                text.Location = new Point(50, 19);
                text.Font = new Font("Century Gothic", 09.0F);
                commentPanel.Controls.Add(text);
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
          
          public void ShowComment()
          {
              
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
            // for (int i = 0; i < comments.Count; i++)
            // {
            //     string[] commentText = comments[i].text;
            //     DateTime[] commentDate = comments[i].date;
            //     ShowComment(commentText[i], commentDate[i]);
            // }
        }
      }
}

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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp15
{
    
    public class User
        {

            public string username;
            public Image userpic;

            public User(string username, string userpicPath)
            {
                this.username = username;
                this.userpic = Image.FromFile(userpicPath);
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
            private string path;
            public string fileName;

            public CommentsManager(List <Comment> comments, string selectedImageName)
            {
                this.comments = comments;
                this.fileName = selectedImageName;
                path = @"C:\Users\Юлия\Desktop\algo\images\" + fileName + ".json";
                FromFile();
            }

            
            string serialized;
            
            private void ToFile()
            {
                serialized = JsonConvert.SerializeObject(comments);
                File.WriteAllText(path, serialized, Encoding.GetEncoding(1251));
            }
            
            private void FromFile()
            {
                serialized = File.ReadAllText(path, Encoding.GetEncoding(1251));
                dynamic json = JObject.Parse(serialized);
                for (int i = 0; i < json.Count; i++)
                {
                    comments[i].date = json.Comments[i].Date;
                    comments[i].text = json.Comments[i].Text;
                    comments[i].user.username = json.Comments[i].User.Username;
                    comments[i].user.userpic = json.Comments[i].User.Userpic;
                }
            }

            private void AddComment(Comment comment)
            {
                comments.Add(comment);
                ToFile();
            }
        }
    
        public class CommentView
        {
            public Panel commentPanel;
            public Label username;
            public PictureBox userpic;
            public Label text;

            public CommentView(Comment comment, List <Comment> comments)
            {
                username.Text = comment.user.username;
                userpic.Image = comment.user.userpic;
                text.Text = comment.text;
                
                int firstPoint = 0;

                 for (int i = 0; i < comments.Count; i++)
                 {
                     commentPanel.Location = new Point(5, firstPoint + 5);
                     firstPoint += 40;
                 }

                commentPanel.Size = new System.Drawing.Size(150, 40);
                
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
        
        public class CommentsViewManager
        {
            public List<CommentView> commentViews;
            public Panel commentsPanel;

            public CommentsViewManager(List <Comment> comments)
            {
                commentsPanel.Location = new Point(446, 103);
                commentsPanel.Size = new System.Drawing.Size(160, 350);
                commentsPanel.AutoScroll = true;
                Form2.ActiveForm.Controls.Add(commentsPanel);
                
                for (int i = 0; i < comments.Count; i++)
                {
                    CommentView commentView = new CommentView(comments[i], comments);
                    commentViews.Add(commentView);
                    commentsPanel.Controls.Add(commentView.commentPanel);
                }
            }
        }
        
        
    
    public partial class Form2 : Form 
      {
          
          public List <Comment> comments = new List<Comment>();
        
          public void AddComment()
          {
              string text = textBox1.Text;
              User user = new User(label1.Text, pictureBox1.ImageLocation);
              Comment comment = new Comment(text, user);
              comments.Add(comment);
              CommentsViewManager c = new CommentsViewManager(comments);
              textBox1.Clear();
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

            CommentsManager commentsFromBd = new CommentsManager(comments, selectedImageName);
            CommentsViewManager allComments = new CommentsViewManager(comments);
            
        }

          private void button1_Click(object sender, System.EventArgs e)
        {
            AddComment();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }
      }
}

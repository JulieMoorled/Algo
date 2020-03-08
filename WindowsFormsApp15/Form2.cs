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
    
    //pls

    //pls
    
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

        public Comment(DateTime date, string text, User user)
        {
            this.date = date;
            this.text = text;
            this.user = user;
        }
    }
    

    public class CommentManager 
    {
        
        private List <Comment> comments = new List<Comment>();
        
        public void FromFile()
        {
            using (FileStream fs = new FileStream(@"C:\Users\Юлия\Desktop\algo\file.json", FileMode.OpenOrCreate))
            {
                CommentManager comment = await JsonSerializer.DeserializeAsync<CommentManager>(fs);
            }
        }

        public void ShowComment()
        {
            
        }

        public void AddComment()
        {
            CommentManager newComment = new CommentManager();
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

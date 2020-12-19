using PictureFinder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureFinder
{
    public partial class PictureFinder : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();      
        public string ImagePath
        {
            get
            {
                return Settings.Default.ImagePath; 
            }
            set
            {
                Settings.Default.ImagePath = value;
            }
        }
        public PictureFinder()
        {
            InitializeComponent();

            openFileDialog.FileName = ImagePath;
            PictureBoxCheck();

            CheckDelete();
        }
        private void PictureBoxCheck()
        {
            if (ImagePath != "null")
            {
                
                Bitmap bitmap = new Bitmap(ImagePath);
                pbImage.Image = bitmap;
                
            }
            
        }
        private void CheckDelete()
        {
            if (pbImage.Image == null)
                btnDelete.Visible = false;
            else
                btnDelete.Visible = true;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                pbImage.Image = bitmap;
                ActiveForm.Size = pbImage.Image.Size;
            }
            
            CheckDelete();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
            CheckDelete();
        }

        private void PictureFinder_FormClosed(object sender, FormClosedEventArgs e)
        {  
            if (pbImage != null)
                ImagePath = openFileDialog.FileName;
            else
                ImagePath = "null";

            Settings.Default.Save();
        }
    }
}

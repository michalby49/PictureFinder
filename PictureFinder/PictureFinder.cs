using PictureFinder.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictureFinder
{
    public partial class PictureFinder : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        public Size DefaultSize
        {
            get
            {
                return Settings.Default.DefaultSize;
            }
        }
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

            CheckLastPicture();

            CheckDelete();
            
        }

        private void CheckLastPicture()
        {
            if(ImagePath != "")
            {
                openFileDialog.FileName = ImagePath;
                Bitmap bitmap = new Bitmap(ImagePath);
                pbImage.Image = bitmap;
                
            }

        }

        private void SetFormSize(Size size)
        {
            
            ActiveForm.Size = size;
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
                SetFormSize(pbImage.Image.Size);
            }
            
            CheckDelete();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
            SetFormSize(DefaultSize);
            CheckDelete();
        }

        private void PictureFinder_FormClosed(object sender, FormClosedEventArgs e)
        {  
            if (pbImage.Image != null)
                ImagePath = openFileDialog.FileName;
            else
                ImagePath = null;

            Settings.Default.Save();
        }

        private void PictureFinder_Activated(object sender, EventArgs e)
        {
            if (pbImage.Image != null)
            {
                SetFormSize(pbImage.Image.Size);
            }
            
        }
    }
}

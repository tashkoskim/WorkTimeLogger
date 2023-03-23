using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WorkTimeLogger.Constants;

namespace WorkTimeLogger
{
    public partial class Form1 : Form
    {
        private NotifyIcon _notifyIcon;
        private Image defaultImage_Coding = null;
        private Image defaultImage_Meeting = null;
        private Image hoverImage_Coding = null;
        private Image hoverImage_Meeting = null;
        public Form1()
        {
            InitializeComponent();

            DefineBtnBackgrounds();

            this.Size = new Size(400, 30);
            RepositionTheForm();

            HeaderGradientBackground();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                this.Size = new Size(400, 30);
                RepositionTheForm();
            }
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            this.Size = new Size(461, 187);
            RepositionTheForm();
        }

        private void RepositionTheForm()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prevent the form from being minimized
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            BringToFront();
            Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "Important notice", "Don't forget to log the time so you don't have headaches later!", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            BringToFront();
            Activate();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void HeaderGradientBackground()
        {
            // Create a new ColorBlend object
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new float[] { 0, 0.5f, 1 };
            colorBlend.Colors = new Color[] { Color.Navy, Color.DarkBlue, Color.RoyalBlue };

            // Create a new Brush object using the ColorBlend object
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), // Starting point of the gradient
                new Point(panelHeader.ClientSize.Width, panelHeader.ClientSize.Height), // Ending point of the gradient
                Color.Navy, // Starting color of the gradient
                Color.RoyalBlue); // Ending color of the gradient
            brush.InterpolationColors = colorBlend;

            // Set the BackColor property of the panel to the brush
            panelHeader.BackColor = Color.Transparent; // Set the panel's BackColor to transparent
            panelHeader.BackgroundImage = new Bitmap(panelHeader.ClientSize.Width, panelHeader.ClientSize.Height); // Create a new bitmap for the panel's background
            using (Graphics g = Graphics.FromImage(panelHeader.BackgroundImage))
            {
                g.FillRectangle(brush, 0, 0, panelHeader.ClientSize.Width, panelHeader.ClientSize.Height); // Fill the bitmap with the gradient brush
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GeneralConstants.logsFolder);
        }

        private void btn_Coding_MouseEnter(object sender, EventArgs e)
        {
            if (hoverImage_Coding != null)
            {
                defaultImage_Coding = btn_Coding.BackgroundImage;
                btn_Coding.BackgroundImage = hoverImage_Coding;
                toolTip1.SetToolTip(btn_Coding, "Coding");
            }
        }

        private void btn_Coding_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage_Coding != null)
            {
                btn_Coding.BackgroundImage = defaultImage_Coding;
            }
        }

        private void btn_Meeting_MouseEnter(object sender, EventArgs e)
        {
            if (hoverImage_Meeting != null)
            {
                defaultImage_Meeting = btn_Meeting.BackgroundImage;
                btn_Meeting.BackgroundImage = hoverImage_Meeting;
                toolTip1.SetToolTip(btn_Meeting, "Meeting");
            }
        }

        private void btn_Meeting_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage_Meeting != null)
            {
                btn_Meeting.BackgroundImage = defaultImage_Meeting;
            }
        }

        private void DefineBtnBackgrounds()
        {
            // Load default image
            defaultImage_Coding = Image.FromFile(GeneralConstants.bckgrImg_btnCoding1);

            // Load hover image (change file name)
            string hoverImageFilePath = Path.Combine(Path.GetDirectoryName(GeneralConstants.bckgrImg_btnCoding1), GeneralConstants.bckgrImg_btnCoding2);
            if (File.Exists(hoverImageFilePath))
            {
                hoverImage_Coding = Image.FromFile(hoverImageFilePath);
            }

            // Set default image
            //btn_Coding.BackgroundImage = defaultImage_Coding;

            //-------------------------------

            // Load default image
            defaultImage_Meeting = Image.FromFile(GeneralConstants.bckgrImg_btnMeeting1);

            // Load hover image (change file name)
            hoverImageFilePath = Path.Combine(Path.GetDirectoryName(GeneralConstants.bckgrImg_btnMeeting1), GeneralConstants.bckgrImg_btnMeeting2);
            if (File.Exists(hoverImageFilePath))
            {
                hoverImage_Meeting = Image.FromFile(hoverImageFilePath);
            }

            // Set default image
            //btn_Meeting.BackgroundImage = defaultImage_Coding;
        }

        
    }
}
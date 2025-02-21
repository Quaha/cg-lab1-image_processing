using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor {
    public partial class UserInterface : Form {
        Bitmap image;
        public UserInterface() {
            InitializeComponent();
        }

        private void Open_ToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK) {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void SpotFilters_Inversion_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.InvertFilter filter = new SpotFilters.InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void SpotFilters_GrayScale_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.GrayScaleFilter filter = new SpotFilters.GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void SpotFilters_Sepia_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.SepiaFilter filter = new SpotFilters.SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void SpotFilters_Brightness_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.BrightnessFilter filter = new SpotFilters.BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void SpotFilters_Shift_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.ShiftFilter filter = new SpotFilters.ShiftFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void MatrixFilters_Blur_ToolStripMenuItem_Click(object sender, EventArgs e) {
            MatrixFilters.BlurFilter filter = new MatrixFilters.BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void MatrixFilters_MotionBlur_ToolStripMenuItem_Click(object sender, EventArgs e) {
            MatrixFilters.MotionBlurFilter filter = new MatrixFilters.MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            Bitmap new_image = ((Filter)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true) {
                image = new_image;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!e.Cancelled) {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void Cancel_Click(object sender, EventArgs e) {
            backgroundWorker1.CancelAsync();
        }
    }
}

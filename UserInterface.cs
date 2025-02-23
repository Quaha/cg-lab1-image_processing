using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        private void File_Open_ToolStripMenuItem_Click(object sender, EventArgs e) {
            using (OpenFileDialog dialog = new OpenFileDialog()) {

                dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
                dialog.Title = "Open an image in the editor";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    image = new Bitmap(dialog.FileName);
                    pictureBox1.Image = image;
                    pictureBox1.Refresh();
                }
            }
        }

        private void File_SaveAs_ToolStripMenuItem_Click(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {

                if (image == null) {
                    MessageBox.Show(
                        "The image is missing!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
                dialog.Title = "Save the image as...";
                dialog.FileName = "image.png";
                dialog.DefaultExt = "png";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    ImageFormat format = ImageFormat.Png;
                    switch (dialog.FilterIndex) {
                        case 1:
                            format = ImageFormat.Png;
                            break;
                        case 2:
                            format = ImageFormat.Jpeg;
                            break;
                        case 3:
                            format = ImageFormat.Bmp;
                            break;
                    }

                    image.Save(dialog.FileName, format);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void SpotFilters_Inversion_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.InversionFilter filter = new SpotFilters.InversionFilter();
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

        private void SpotFilters_GrayWorld_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.GrayWorldFilter filter = new SpotFilters.GrayWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void SpotFilters_Autolevels_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.AutolevelsFilter filter = new SpotFilters.AutolevelsFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void SpotFilters_PerfectReflector_ToolStripMenuItem_Click(object sender, EventArgs e) {
            SpotFilters.PerfectReflectorFilter filter = new SpotFilters.PerfectReflectorFilter();
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

        private void MatrixFilters_Median_ToolStripMenuItem_Click(object sender, EventArgs e) {
            MatrixFilters.MedianFilter filter = new MatrixFilters.MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void MatrixFilters_Gaussian_ToolStripMenuItem_Click(object sender, EventArgs e) {
            MatrixFilters.GaussianFilter filter = new MatrixFilters.GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void AdvancedFilters_Embossing_ToolStripMenuItem_Click(object sender, EventArgs e) {
            AdvancedFilters.EmbossingFilter filter = new AdvancedFilters.EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void AdvancedFilters_Paper_ToolStripMenuItem_Click(object sender, EventArgs e) {
            AdvancedFilters.PaperFilter filter = new AdvancedFilters.PaperFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void AdvancedFilters_Sobel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            AdvancedFilters.SobelFilter filter = new AdvancedFilters.SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void AdvancedFilters_Scharr_ToolStripMenuItem_Click(object sender, EventArgs e) {
            AdvancedFilters.ScharrFilter filter = new AdvancedFilters.ScharrFilter();
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

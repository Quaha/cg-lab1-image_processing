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
using static PhotoEditor.UserInterface;

using PhotoEditor;
using SpotFilters;
using MatrixFilters;
using AdvancedFilters;
using System.Globalization;

namespace PhotoEditor {
    public partial class UserInterface : Form {

        Bitmap image;

        private static void showError(string message) {
            MessageBox.Show(
                message,
                "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public class FilterParametersForm : Form {

            protected Form form;

            protected List<FilterParameter> required_parameters;
            protected string filter_name;

            Dictionary<string, TextBox> text_boxes;

            protected Dictionary<string, object> result_parameters;

            public FilterParametersForm(List<FilterParameter> parameters, string filter_name) {
                this.required_parameters = parameters;
                this.filter_name = filter_name;
            }

            private void applyButton_Click(object sender, EventArgs e) {
                bool input_is_valid = true;

                result_parameters = new Dictionary<string, object>();

                foreach (FilterParameter param in required_parameters) {
                    TextBox current_text_box = text_boxes[param.param_name];
                    string input_text = current_text_box.Text;

                    if (string.IsNullOrEmpty(input_text)) {
                        showError($"{param.param_name} field can not be empty.");
                        input_is_valid = false;
                        break;
                    }

                    object value = null;

                    try {
                        if (param.param_type == typeof(int)) {
                            value = int.Parse(input_text);
                            if ((int)value < (int)param.min_value || (int)value > (int)param.max_value) {
                                showError($"{param.param_name} must be between {param.min_value} and {param.max_value}.");
                                input_is_valid = false;
                                break;
                            }
                        }
                        else if (param.param_type == typeof(float)) {
                            if (!float.TryParse(input_text, NumberStyles.Float, CultureInfo.InvariantCulture, out float parsedValue)) {
                                showError($"Invalid format for {param.param_name}. Expected a valid floating-point number.");
                                input_is_valid = false;
                                break;
                            }
                            value = parsedValue;
                            if (Convert.ToSingle(value) < Convert.ToSingle(param.min_value) ||
                                Convert.ToSingle(value) > Convert.ToSingle(param.max_value)) {
                                showError($"{param.param_name} must be between {param.min_value} and {param.max_value}.");
                                input_is_valid = false;
                                break;
                            }
                        }
                        else {
                            throw new Exception("Unprocessed parameter type!");
                        }
                    }
                    catch {
                        showError($"Invalid format for {param.param_name}. Expected a valid value.");
                        input_is_valid = false;
                        break;
                    }

                    if (input_is_valid) {
                        result_parameters[param.param_name] = value;
                    }
                }

                if (input_is_valid) {
                    form.Close();
                }
                else {
                    result_parameters = null;
                }
            }

            public void showParametersDialog() {
                Dictionary<string, object> result = new Dictionary<string, object>();

                form = new Form {
                    Text = filter_name + " Filter",
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    MaximizeBox = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    StartPosition = FormStartPosition.CenterParent,
                    ShowInTaskbar = false
                };

                TableLayoutPanel panel = new TableLayoutPanel {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    RowCount = required_parameters.Count + 1, // +1 for the "Apply" button
                    AutoSize = true
                };

                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // For labels
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // For text boxes
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // For hints

                form.Controls.Add(panel);

                text_boxes = new Dictionary<string, TextBox>();

                for (int i = 0; i < required_parameters.Count; i++) {
                    Label label = new Label {
                        Text = required_parameters[i].param_name + ":",
                        AutoSize = true,
                        Anchor = AnchorStyles.Right
                    };

                    TextBox text_box = new TextBox {
                        Text = required_parameters[i].default_value.ToString(),
                        Dock = DockStyle.Fill
                    };

                    Label range_label = new Label {
                        Text = $"[ {required_parameters[i].min_value} — {required_parameters[i].max_value} ]",
                        AutoSize = true,
                        Anchor = AnchorStyles.Left
                    };

                    panel.Controls.Add(label, 0, i); // Label to the first column
                    panel.Controls.Add(text_box, 1, i); // Text box to the second column
                    panel.Controls.Add(range_label, 2, i); // Range label to the third column

                    text_boxes[required_parameters[i].param_name] = text_box; // Bound: param_name -> text box
                }

                Button apply_button = new Button {
                    Text = "Apply",
                    Dock = DockStyle.Fill
                };

                panel.Controls.Add(apply_button, 1, panel.RowCount - 1);

                apply_button.Click += applyButton_Click; // Link button to the realization

                form.ShowDialog();
            }

            public Dictionary<string, object> getResultParameters() {
                return result_parameters;
            }
        }

        public UserInterface() {
            InitializeComponent();
        }

        private void File_Open_OpenImage_ToolStripMenuItem_Click(object sender, EventArgs e) {
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

        private void File_Save_SaveImageAs_ToolStripMenuItem_Click(object sender, EventArgs e) {
            using (SaveFileDialog dialog = new SaveFileDialog()) {

                if (image == null) {
                    showError("The image is missing!");
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

        private void applyFilter<T>() where T : Filter, new() {
            T filter_object = new T();

            List<FilterParameter> parameters = filter_object.getFilterParameters();
            string filterName = filter_object.getName();

            if (parameters.Count == 0) {
                progress_updater.RunWorkerAsync(filter_object);
            }
            else {
                FilterParametersForm form = new FilterParametersForm(parameters, filterName);
                form.showParametersDialog();
                Dictionary<string, object> resultParameters = form.getResultParameters();

                if (resultParameters == null) return;

                T filterWithParams = (T)Activator.CreateInstance(typeof(T), resultParameters);
                progress_updater.RunWorkerAsync(filterWithParams);
            }
        }

        private void SpotFilters_Inversion_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<InversionFilter>();
        }

        private void SpotFilters_GrayScale_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<GrayScaleFilter>();
        }

        private void SpotFilters_Sepia_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<SepiaFilter>();
        }

        private void SpotFilters_Brightness_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<BrightnessFilter>();
        }

        private void SpotFilters_Shift_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<ShiftFilter>();
        }

        private void SpotFilters_GrayWorld_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<GrayWorldFilter>();
        }

        private void SpotFilters_Autolevels_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<AutolevelsFilter>();
        }

        private void SpotFilters_PerfectReflector_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<PerfectReflectorFilter>();
        }

        private void MatrixFilters_Blur_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<BlurFilter>();
        }

        private void MatrixFilters_MotionBlur_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<MotionBlurFilter>();
        }

        private void MatrixFilters_Median_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<MedianFilter>();
        }

        private void MatrixFilters_Gaussian_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<GaussianFilter>();
        }

        private void MatrixFilters_Expansion_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<ExpansionFilter>();
        }

        private void MatrixFilters_Narrowing_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<NarrowingFilter>();
        }

        private void MatrixFilters_Sharpness_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<SharpnessFilter>();
        }

        private void AdvancedFilters_Embossing_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<EmbossingFilter>();
        }

        private void AdvancedFilters_Paper_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<PaperFilter>();
        }

        private void AdvancedFilters_Sobel_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<SobelFilter>();
        }

        private void AdvancedFilters_Scharr_ToolStripMenuItem_Click(object sender, EventArgs e) {
            applyFilter<ScharrFilter>();
        }

        private void progressUpdater_DoWork(object sender, DoWorkEventArgs e) {
            Bitmap new_image = ((Filter)e.Argument).processImage(image, progress_updater);
            if (progress_updater.CancellationPending != true) {
                image = new_image;
            }
        }

        private void progressUpdater_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            imageProcessingProgressBar.Value = e.ProgressPercentage;
        }

        private void progressUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!e.Cancelled) {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            imageProcessingProgressBar.Value = 0;
        }

        private void Cancel_Click(object sender, EventArgs e) {
            progress_updater.CancelAsync();
        }
    }
}

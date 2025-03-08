namespace PhotoEditor
{
    partial class UserInterface
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инверсияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autolevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfectReflectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матричныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expansionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narrowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scharrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_picture_box = new System.Windows.Forms.PictureBox();
            this.progress_updater = new System.ComponentModel.BackgroundWorker();
            this.imageProcessingProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.colorShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.открытьToolStripMenuItem.Text = "Open";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openImageToolStripMenuItem.Text = "Open image...";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.File_Open_OpenImage_ToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageAsToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveAsToolStripMenuItem.Text = "Save";
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.File_Save_SaveImageAs_ToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечныеToolStripMenuItem,
            this.матричныеToolStripMenuItem,
            this.advancedFiltersToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.фильтрыToolStripMenuItem.Text = "Filters";
            // 
            // точечныеToolStripMenuItem
            // 
            this.точечныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инверсияToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.shiftToolStripMenuItem,
            this.grayWorldToolStripMenuItem,
            this.autolevelsToolStripMenuItem,
            this.perfectReflectorToolStripMenuItem,
            this.colorShiftToolStripMenuItem});
            this.точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            this.точечныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.точечныеToolStripMenuItem.Text = "Spot Filters";
            // 
            // инверсияToolStripMenuItem
            // 
            this.инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            this.инверсияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.инверсияToolStripMenuItem.Text = "Inversion";
            this.инверсияToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_Inversion_ToolStripMenuItem_Click);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_GrayScale_ToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_Sepia_ToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_Brightness_ToolStripMenuItem_Click);
            // 
            // shiftToolStripMenuItem
            // 
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.shiftToolStripMenuItem.Text = "Shift";
            this.shiftToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_Shift_ToolStripMenuItem_Click);
            // 
            // grayWorldToolStripMenuItem
            // 
            this.grayWorldToolStripMenuItem.Name = "grayWorldToolStripMenuItem";
            this.grayWorldToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayWorldToolStripMenuItem.Text = "GrayWorld";
            this.grayWorldToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_GrayWorld_ToolStripMenuItem_Click);
            // 
            // autolevelsToolStripMenuItem
            // 
            this.autolevelsToolStripMenuItem.Name = "autolevelsToolStripMenuItem";
            this.autolevelsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autolevelsToolStripMenuItem.Text = "Autolevels";
            this.autolevelsToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_Autolevels_ToolStripMenuItem_Click);
            // 
            // perfectReflectorToolStripMenuItem
            // 
            this.perfectReflectorToolStripMenuItem.Name = "perfectReflectorToolStripMenuItem";
            this.perfectReflectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.perfectReflectorToolStripMenuItem.Text = "PerfectReflector";
            this.perfectReflectorToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_PerfectReflector_ToolStripMenuItem_Click);
            // 
            // матричныеToolStripMenuItem
            // 
            this.матричныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem,
            this.motionBlurToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.expansionToolStripMenuItem,
            this.narrowingToolStripMenuItem,
            this.sharpnessToolStripMenuItem});
            this.матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            this.матричныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.матричныеToolStripMenuItem.Text = "Matrix Filters";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_Blur_ToolStripMenuItem_Click);
            // 
            // motionBlurToolStripMenuItem
            // 
            this.motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            this.motionBlurToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.motionBlurToolStripMenuItem.Text = "MotionBlur";
            this.motionBlurToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_MotionBlur_ToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_Median_ToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_Gaussian_ToolStripMenuItem_Click);
            // 
            // expansionToolStripMenuItem
            // 
            this.expansionToolStripMenuItem.Name = "expansionToolStripMenuItem";
            this.expansionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.expansionToolStripMenuItem.Text = "Expansion";
            this.expansionToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_Expansion_ToolStripMenuItem_Click);
            // 
            // narrowingToolStripMenuItem
            // 
            this.narrowingToolStripMenuItem.Name = "narrowingToolStripMenuItem";
            this.narrowingToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.narrowingToolStripMenuItem.Text = "Narrowing";
            this.narrowingToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_Narrowing_ToolStripMenuItem_Click);
            // 
            // sharpnessToolStripMenuItem
            // 
            this.sharpnessToolStripMenuItem.Name = "sharpnessToolStripMenuItem";
            this.sharpnessToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.sharpnessToolStripMenuItem.Text = "Sharpness";
            this.sharpnessToolStripMenuItem.Click += new System.EventHandler(this.MatrixFilters_Sharpness_ToolStripMenuItem_Click);
            // 
            // advancedFiltersToolStripMenuItem
            // 
            this.advancedFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.embossingToolStripMenuItem,
            this.paperToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.scharrToolStripMenuItem});
            this.advancedFiltersToolStripMenuItem.Name = "advancedFiltersToolStripMenuItem";
            this.advancedFiltersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.advancedFiltersToolStripMenuItem.Text = "Advanced Filters";
            // 
            // embossingToolStripMenuItem
            // 
            this.embossingToolStripMenuItem.Name = "embossingToolStripMenuItem";
            this.embossingToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.embossingToolStripMenuItem.Text = "Embossing";
            this.embossingToolStripMenuItem.Click += new System.EventHandler(this.AdvancedFilters_Embossing_ToolStripMenuItem_Click);
            // 
            // paperToolStripMenuItem
            // 
            this.paperToolStripMenuItem.Name = "paperToolStripMenuItem";
            this.paperToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.paperToolStripMenuItem.Text = "Paper";
            this.paperToolStripMenuItem.Click += new System.EventHandler(this.AdvancedFilters_Paper_ToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.AdvancedFilters_Sobel_ToolStripMenuItem_Click);
            // 
            // scharrToolStripMenuItem
            // 
            this.scharrToolStripMenuItem.Name = "scharrToolStripMenuItem";
            this.scharrToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.scharrToolStripMenuItem.Text = "Scharr";
            this.scharrToolStripMenuItem.Click += new System.EventHandler(this.AdvancedFilters_Scharr_ToolStripMenuItem_Click);
            // 
            // main_picture_box
            // 
            this.main_picture_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_picture_box.Location = new System.Drawing.Point(0, 27);
            this.main_picture_box.Name = "main_picture_box";
            this.main_picture_box.Size = new System.Drawing.Size(1264, 615);
            this.main_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.main_picture_box.TabIndex = 1;
            this.main_picture_box.TabStop = false;
            // 
            // progress_updater
            // 
            this.progress_updater.WorkerReportsProgress = true;
            this.progress_updater.WorkerSupportsCancellation = true;
            this.progress_updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.progressUpdater_DoWork);
            this.progress_updater.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressUpdater_ProgressChanged);
            this.progress_updater.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.progressUpdater_RunWorkerCompleted);
            // 
            // imageProcessingProgressBar
            // 
            this.imageProcessingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageProcessingProgressBar.Location = new System.Drawing.Point(0, 648);
            this.imageProcessingProgressBar.Name = "imageProcessingProgressBar";
            this.imageProcessingProgressBar.Size = new System.Drawing.Size(1077, 33);
            this.imageProcessingProgressBar.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(1083, 648);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(181, 33);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // colorShiftToolStripMenuItem
            // 
            this.colorShiftToolStripMenuItem.Name = "colorShiftToolStripMenuItem";
            this.colorShiftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorShiftToolStripMenuItem.Text = "ColorShift";
            this.colorShiftToolStripMenuItem.Click += new System.EventHandler(this.SpotFilters_ColorShift_ToolStripMenuItem_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.imageProcessingProgressBar);
            this.Controls.Add(this.main_picture_box);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserInterface";
            this.Text = "PhotoEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точечныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инверсияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матричныеToolStripMenuItem;
        private System.Windows.Forms.PictureBox main_picture_box;
        private System.ComponentModel.BackgroundWorker progress_updater;
        private System.Windows.Forms.ProgressBar imageProcessingProgressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motionBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autolevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfectReflectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scharrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expansionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narrowingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorShiftToolStripMenuItem;
    }
}


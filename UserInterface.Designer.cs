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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autolevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfectReflectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTheLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTheRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_picture_box = new System.Windows.Forms.PictureBox();
            this.progress_updater = new System.ComponentModel.BackgroundWorker();
            this.imageProcessingProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(94)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.editToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openImageToolStripMenuItem.Text = "Open image...";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.File_Open_OpenImage_ToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageAsToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save";
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.File_Save_SaveImageAs_ToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spotToolStripMenuItem,
            this.matrixToolStripMenuItem,
            this.advancedFiltersToolStripMenuItem});
            this.filtersToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // spotToolStripMenuItem
            // 
            this.spotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inversionToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.grayWorldToolStripMenuItem,
            this.autolevelsToolStripMenuItem,
            this.perfectReflectorToolStripMenuItem,
            this.colorShiftToolStripMenuItem});
            this.spotToolStripMenuItem.Name = "spotToolStripMenuItem";
            this.spotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spotToolStripMenuItem.Text = "Spot Filters";
            // 
            // inversionToolStripMenuItem
            // 
            this.inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            this.inversionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inversionToolStripMenuItem.Text = "Inversion";
            this.inversionToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_Inversion_ToolStripMenuItem_Click);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_GrayScale_ToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_Sepia_ToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_Brightness_ToolStripMenuItem_Click);
            // 
            // grayWorldToolStripMenuItem
            // 
            this.grayWorldToolStripMenuItem.Name = "grayWorldToolStripMenuItem";
            this.grayWorldToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayWorldToolStripMenuItem.Text = "GrayWorld";
            this.grayWorldToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_GrayWorld_ToolStripMenuItem_Click);
            // 
            // autolevelsToolStripMenuItem
            // 
            this.autolevelsToolStripMenuItem.Name = "autolevelsToolStripMenuItem";
            this.autolevelsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autolevelsToolStripMenuItem.Text = "Autolevels";
            this.autolevelsToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_Autolevels_ToolStripMenuItem_Click);
            // 
            // perfectReflectorToolStripMenuItem
            // 
            this.perfectReflectorToolStripMenuItem.Name = "perfectReflectorToolStripMenuItem";
            this.perfectReflectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.perfectReflectorToolStripMenuItem.Text = "PerfectReflector";
            this.perfectReflectorToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_PerfectReflector_ToolStripMenuItem_Click);
            // 
            // colorShiftToolStripMenuItem
            // 
            this.colorShiftToolStripMenuItem.Name = "colorShiftToolStripMenuItem";
            this.colorShiftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorShiftToolStripMenuItem.Text = "ColorShift";
            this.colorShiftToolStripMenuItem.Click += new System.EventHandler(this.Filters_SpotFilters_ColorShift_ToolStripMenuItem_Click);
            // 
            // matrixToolStripMenuItem
            // 
            this.matrixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem,
            this.motionBlurToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.expansionToolStripMenuItem,
            this.narrowingToolStripMenuItem,
            this.sharpnessToolStripMenuItem});
            this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            this.matrixToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.matrixToolStripMenuItem.Text = "Matrix Filters";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_Blur_ToolStripMenuItem_Click);
            // 
            // motionBlurToolStripMenuItem
            // 
            this.motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            this.motionBlurToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.motionBlurToolStripMenuItem.Text = "MotionBlur";
            this.motionBlurToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_MotionBlur_ToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_Median_ToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_Gaussian_ToolStripMenuItem_Click);
            // 
            // expansionToolStripMenuItem
            // 
            this.expansionToolStripMenuItem.Name = "expansionToolStripMenuItem";
            this.expansionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expansionToolStripMenuItem.Text = "Expansion";
            this.expansionToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_Expansion_ToolStripMenuItem_Click);
            // 
            // narrowingToolStripMenuItem
            // 
            this.narrowingToolStripMenuItem.Name = "narrowingToolStripMenuItem";
            this.narrowingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.narrowingToolStripMenuItem.Text = "Narrowing";
            this.narrowingToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_Narrowing_ToolStripMenuItem_Click);
            // 
            // sharpnessToolStripMenuItem
            // 
            this.sharpnessToolStripMenuItem.Name = "sharpnessToolStripMenuItem";
            this.sharpnessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sharpnessToolStripMenuItem.Text = "Sharpness";
            this.sharpnessToolStripMenuItem.Click += new System.EventHandler(this.Filters_MatrixFilters_Sharpness_ToolStripMenuItem_Click);
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
            this.embossingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.embossingToolStripMenuItem.Text = "Embossing";
            this.embossingToolStripMenuItem.Click += new System.EventHandler(this.Filters_AdvancedFilters_Embossing_ToolStripMenuItem_Click);
            // 
            // paperToolStripMenuItem
            // 
            this.paperToolStripMenuItem.Name = "paperToolStripMenuItem";
            this.paperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.paperToolStripMenuItem.Text = "Paper";
            this.paperToolStripMenuItem.Click += new System.EventHandler(this.Filters_AdvancedFilters_Paper_ToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.Filters_AdvancedFilters_Sobel_ToolStripMenuItem_Click);
            // 
            // scharrToolStripMenuItem
            // 
            this.scharrToolStripMenuItem.Name = "scharrToolStripMenuItem";
            this.scharrToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scharrToolStripMenuItem.Text = "Scharr";
            this.scharrToolStripMenuItem.Click += new System.EventHandler(this.Filters_AdvancedFilters_Scharr_ToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reflectionToolStripMenuItem,
            this.turnToolStripMenuItem,
            this.shiftToolStripMenuItem1});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // reflectionToolStripMenuItem
            // 
            this.reflectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
            this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.reflectionToolStripMenuItem.Text = "Reflection";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.Edit_Reflection_Vertical_ToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.Edit_Reflection_Horizontal_ToolStripMenuItem_Click);
            // 
            // turnToolStripMenuItem
            // 
            this.turnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toTheLeftToolStripMenuItem,
            this.toTheRightToolStripMenuItem,
            this.toolStripMenuItem2});
            this.turnToolStripMenuItem.Name = "turnToolStripMenuItem";
            this.turnToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.turnToolStripMenuItem.Text = "Turn";
            // 
            // toTheLeftToolStripMenuItem
            // 
            this.toTheLeftToolStripMenuItem.Name = "toTheLeftToolStripMenuItem";
            this.toTheLeftToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.toTheLeftToolStripMenuItem.Text = "90° to the left";
            this.toTheLeftToolStripMenuItem.Click += new System.EventHandler(this.Edit_Rotate_90ToTheLeft_ToolStripMenuItem_Click);
            // 
            // toTheRightToolStripMenuItem
            // 
            this.toTheRightToolStripMenuItem.Name = "toTheRightToolStripMenuItem";
            this.toTheRightToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.toTheRightToolStripMenuItem.Text = "90° to the right";
            this.toTheRightToolStripMenuItem.Click += new System.EventHandler(this.Edit_Rotate_90ToTheRight_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem2.Text = "180°";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.Edit_Rotate_180_ToolStripMenuItem2_Click);
            // 
            // shiftToolStripMenuItem1
            // 
            this.shiftToolStripMenuItem1.Name = "shiftToolStripMenuItem1";
            this.shiftToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.shiftToolStripMenuItem1.Text = "Shift";
            this.shiftToolStripMenuItem1.Click += new System.EventHandler(this.Edit_Shift_ToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.Undo_ToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.Redo_ToolStripMenuItem_Click);
            // 
            // main_picture_box
            // 
            this.main_picture_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_picture_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.main_picture_box.Location = new System.Drawing.Point(12, 37);
            this.main_picture_box.Name = "main_picture_box";
            this.main_picture_box.Size = new System.Drawing.Size(1240, 606);
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
            this.imageProcessingProgressBar.Location = new System.Drawing.Point(12, 649);
            this.imageProcessingProgressBar.Name = "imageProcessingProgressBar";
            this.imageProcessingProgressBar.Size = new System.Drawing.Size(1065, 25);
            this.imageProcessingProgressBar.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(1083, 649);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(169, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(75)))), ((int)(((byte)(145)))));
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
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixToolStripMenuItem;
        private System.Windows.Forms.PictureBox main_picture_box;
        private System.ComponentModel.BackgroundWorker progress_updater;
        private System.Windows.Forms.ProgressBar imageProcessingProgressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTheLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTheRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem1;
    }
}


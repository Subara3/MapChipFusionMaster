namespace MapChipFusionMaster
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxImages = new System.Windows.Forms.ListBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.checkBoxhasDuplicates = new System.Windows.Forms.CheckBox();
            this.panelImagePreview = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelImageDpi = new System.Windows.Forms.Label();
            this.labelImageWidth = new System.Windows.Forms.Label();
            this.buttonPreviewOutput = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonPrevColor2 = new System.Windows.Forms.RadioButton();
            this.radioButtonPrevColor1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panelImagePreview.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxImages
            // 
            this.listBoxImages.AllowDrop = true;
            this.listBoxImages.FormattingEnabled = true;
            this.listBoxImages.ItemHeight = 12;
            this.listBoxImages.Location = new System.Drawing.Point(23, 35);
            this.listBoxImages.Name = "listBoxImages";
            this.listBoxImages.Size = new System.Drawing.Size(131, 388);
            this.listBoxImages.TabIndex = 1;
            this.listBoxImages.SelectedIndexChanged += new System.EventHandler(this.listBoxImages_SelectedIndexChanged);
            this.listBoxImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxImages_DragDrop);
            this.listBoxImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxImages_DragEnter);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(163, 35);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(75, 23);
            this.buttonAddItem.TabIndex = 2;
            this.buttonAddItem.Text = "追加";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(163, 102);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.Text = "↑";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(163, 131);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.Text = "↓";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Location = new System.Drawing.Point(163, 160);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteItem.TabIndex = 6;
            this.buttonDeleteItem.Text = "削除";
            this.buttonDeleteItem.UseVisualStyleBackColor = true;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(163, 189);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "すべてクリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonOutput
            // 
            this.buttonOutput.Location = new System.Drawing.Point(163, 383);
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.Size = new System.Drawing.Size(75, 40);
            this.buttonOutput.TabIndex = 10;
            this.buttonOutput.Text = "出力";
            this.buttonOutput.UseVisualStyleBackColor = true;
            this.buttonOutput.Click += new System.EventHandler(this.buttonOutput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "■画像のリスト";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(269, 5);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(366, 362);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPreview.TabIndex = 8;
            this.pictureBoxPreview.TabStop = false;
            // 
            // checkBoxhasDuplicates
            // 
            this.checkBoxhasDuplicates.AutoSize = true;
            this.checkBoxhasDuplicates.Location = new System.Drawing.Point(163, 64);
            this.checkBoxhasDuplicates.Name = "checkBoxhasDuplicates";
            this.checkBoxhasDuplicates.Size = new System.Drawing.Size(68, 16);
            this.checkBoxhasDuplicates.TabIndex = 3;
            this.checkBoxhasDuplicates.Text = "重複有り";
            this.checkBoxhasDuplicates.UseVisualStyleBackColor = true;
            this.checkBoxhasDuplicates.CheckedChanged += new System.EventHandler(this.checkBoxhasDuplicates_CheckedChanged);
            // 
            // panelImagePreview
            // 
            this.panelImagePreview.AutoScroll = true;
            this.panelImagePreview.BackColor = System.Drawing.Color.Black;
            this.panelImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImagePreview.Controls.Add(this.pictureBoxPreview);
            this.panelImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImagePreview.Location = new System.Drawing.Point(0, 0);
            this.panelImagePreview.Name = "panelImagePreview";
            this.panelImagePreview.Size = new System.Drawing.Size(833, 476);
            this.panelImagePreview.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelImageDpi);
            this.panel1.Controls.Add(this.labelImageWidth);
            this.panel1.Controls.Add(this.buttonPreviewOutput);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.listBoxImages);
            this.panel1.Controls.Add(this.buttonAddItem);
            this.panel1.Controls.Add(this.checkBoxhasDuplicates);
            this.panel1.Controls.Add(this.buttonUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonDown);
            this.panel1.Controls.Add(this.buttonOutput);
            this.panel1.Controls.Add(this.buttonDeleteItem);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 476);
            this.panel1.TabIndex = 0;
            // 
            // labelImageDpi
            // 
            this.labelImageDpi.AutoSize = true;
            this.labelImageDpi.Location = new System.Drawing.Point(22, 448);
            this.labelImageDpi.Name = "labelImageDpi";
            this.labelImageDpi.Size = new System.Drawing.Size(47, 12);
            this.labelImageDpi.TabIndex = 15;
            this.labelImageDpi.Text = "解像度：";
            // 
            // labelImageWidth
            // 
            this.labelImageWidth.AutoSize = true;
            this.labelImageWidth.Location = new System.Drawing.Point(23, 429);
            this.labelImageWidth.Name = "labelImageWidth";
            this.labelImageWidth.Size = new System.Drawing.Size(35, 12);
            this.labelImageWidth.TabIndex = 14;
            this.labelImageWidth.Text = "横幅：";
            // 
            // buttonPreviewOutput
            // 
            this.buttonPreviewOutput.Location = new System.Drawing.Point(163, 357);
            this.buttonPreviewOutput.Name = "buttonPreviewOutput";
            this.buttonPreviewOutput.Size = new System.Drawing.Size(75, 23);
            this.buttonPreviewOutput.TabIndex = 9;
            this.buttonPreviewOutput.Text = "プレビュー➡";
            this.buttonPreviewOutput.UseVisualStyleBackColor = true;
            this.buttonPreviewOutput.Click += new System.EventHandler(this.buttonPreviewOutput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPrevColor2);
            this.groupBox1.Controls.Add(this.radioButtonPrevColor1);
            this.groupBox1.Location = new System.Drawing.Point(163, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 67);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "プレビュー色";
            // 
            // radioButtonPrevColor2
            // 
            this.radioButtonPrevColor2.AutoSize = true;
            this.radioButtonPrevColor2.Location = new System.Drawing.Point(18, 41);
            this.radioButtonPrevColor2.Name = "radioButtonPrevColor2";
            this.radioButtonPrevColor2.Size = new System.Drawing.Size(35, 16);
            this.radioButtonPrevColor2.TabIndex = 1;
            this.radioButtonPrevColor2.Text = "灰";
            this.radioButtonPrevColor2.UseVisualStyleBackColor = true;
            this.radioButtonPrevColor2.CheckedChanged += new System.EventHandler(this.radioButtonPrevColor2_CheckedChanged);
            // 
            // radioButtonPrevColor1
            // 
            this.radioButtonPrevColor1.AutoSize = true;
            this.radioButtonPrevColor1.Checked = true;
            this.radioButtonPrevColor1.Location = new System.Drawing.Point(18, 18);
            this.radioButtonPrevColor1.Name = "radioButtonPrevColor1";
            this.radioButtonPrevColor1.Size = new System.Drawing.Size(35, 16);
            this.radioButtonPrevColor1.TabIndex = 0;
            this.radioButtonPrevColor1.TabStop = true;
            this.radioButtonPrevColor1.Text = "黒";
            this.radioButtonPrevColor1.UseVisualStyleBackColor = true;
            this.radioButtonPrevColor1.CheckedChanged += new System.EventHandler(this.radioButtonPrevColor1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelImagePreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MapChipFusionMaster";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panelImagePreview.ResumeLayout(false);
            this.panelImagePreview.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxImages;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonDeleteItem;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.CheckBox checkBoxhasDuplicates;
        private System.Windows.Forms.Panel panelImagePreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPrevColor2;
        private System.Windows.Forms.RadioButton radioButtonPrevColor1;
        private System.Windows.Forms.Button buttonPreviewOutput;
        private System.Windows.Forms.Label labelImageWidth;
        private System.Windows.Forms.Label labelImageDpi;
    }
}


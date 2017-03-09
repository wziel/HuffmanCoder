namespace HuffmanCoder.UI
{
    partial class HufffmanCoder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HufffmanCoder));
            this.decodeBTN = new System.Windows.Forms.Button();
            this.encodeBTN = new System.Windows.Forms.Button();
            this.modelWithoutMemoryRadio = new System.Windows.Forms.RadioButton();
            this.blockModelRadio = new System.Windows.Forms.RadioButton();
            this.markowModelRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // decodeBTN
            // 
            resources.ApplyResources(this.decodeBTN, "decodeBTN");
            this.decodeBTN.Name = "decodeBTN";
            this.decodeBTN.UseVisualStyleBackColor = true;
            this.decodeBTN.Click += new System.EventHandler(this.decodeBTN_Click);
            // 
            // encodeBTN
            // 
            resources.ApplyResources(this.encodeBTN, "encodeBTN");
            this.encodeBTN.Name = "encodeBTN";
            this.encodeBTN.UseVisualStyleBackColor = true;
            this.encodeBTN.Click += new System.EventHandler(this.encodeBTN_Click);
            // 
            // modelWithoutMemoryRadio
            // 
            resources.ApplyResources(this.modelWithoutMemoryRadio, "modelWithoutMemoryRadio");
            this.modelWithoutMemoryRadio.Name = "modelWithoutMemoryRadio";
            this.modelWithoutMemoryRadio.TabStop = true;
            this.modelWithoutMemoryRadio.UseVisualStyleBackColor = true;
            // 
            // blockModelRadio
            // 
            resources.ApplyResources(this.blockModelRadio, "blockModelRadio");
            this.blockModelRadio.Name = "blockModelRadio";
            this.blockModelRadio.TabStop = true;
            this.blockModelRadio.UseVisualStyleBackColor = true;
            // 
            // markowModelRadio
            // 
            resources.ApplyResources(this.markowModelRadio, "markowModelRadio");
            this.markowModelRadio.Name = "markowModelRadio";
            this.markowModelRadio.TabStop = true;
            this.markowModelRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.modelWithoutMemoryRadio);
            this.groupBox1.Controls.Add(this.markowModelRadio);
            this.groupBox1.Controls.Add(this.blockModelRadio);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // HufffmanCoder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.encodeBTN);
            this.Controls.Add(this.decodeBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HufffmanCoder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button decodeBTN;
        private System.Windows.Forms.Button encodeBTN;
        private System.Windows.Forms.RadioButton modelWithoutMemoryRadio;
        private System.Windows.Forms.RadioButton blockModelRadio;
        private System.Windows.Forms.RadioButton markowModelRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


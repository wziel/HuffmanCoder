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
            this.inputTB = new System.Windows.Forms.TextBox();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputFileBTN = new System.Windows.Forms.Button();
            this.outputFileBTN = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.modelWithoutMemoryRadio);
            this.groupBox1.Controls.Add(this.markowModelRadio);
            this.groupBox1.Controls.Add(this.blockModelRadio);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // inputTB
            // 
            resources.ApplyResources(this.inputTB, "inputTB");
            this.inputTB.Name = "inputTB";
            this.inputTB.ReadOnly = true;
            // 
            // outputTB
            // 
            resources.ApplyResources(this.outputTB, "outputTB");
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // inputFileBTN
            // 
            resources.ApplyResources(this.inputFileBTN, "inputFileBTN");
            this.inputFileBTN.Name = "inputFileBTN";
            this.inputFileBTN.UseVisualStyleBackColor = true;
            this.inputFileBTN.Click += new System.EventHandler(this.inputFileBTN_Click);
            // 
            // outputFileBTN
            // 
            resources.ApplyResources(this.outputFileBTN, "outputFileBTN");
            this.outputFileBTN.Name = "outputFileBTN";
            this.outputFileBTN.UseVisualStyleBackColor = true;
            this.outputFileBTN.Click += new System.EventHandler(this.outputFileBTN_Click);
            // 
            // HufffmanCoder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputFileBTN);
            this.Controls.Add(this.inputFileBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.inputTB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.encodeBTN);
            this.Controls.Add(this.decodeBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HufffmanCoder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.TextBox outputTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button inputFileBTN;
        private System.Windows.Forms.Button outputFileBTN;
    }
}


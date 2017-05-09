namespace HuffmanCoder.UI
{
    partial class HuffmanStatistics
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
            this.encodedFile = new System.Windows.Forms.Label();
            this.encodedFilePath = new System.Windows.Forms.Label();
            this.entropyLabel = new System.Windows.Forms.Label();
            this.entropyValue = new System.Windows.Forms.Label();
            this.bitRateBox = new System.Windows.Forms.GroupBox();
            this.bitRateProportionWithHeader = new System.Windows.Forms.Label();
            this.bitRateProportionWithoutHeader = new System.Windows.Forms.Label();
            this.outputFileBitRateWithHeader = new System.Windows.Forms.Label();
            this.outputFileBitRateWithoutHeader = new System.Windows.Forms.Label();
            this.inputFileBitRate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.compressionRatioBox = new System.Windows.Forms.GroupBox();
            this.compressionRatioWithHeader = new System.Windows.Forms.Label();
            this.compressionRatioWithoutHeader = new System.Windows.Forms.Label();
            this.outputFileSizeWithHeader = new System.Windows.Forms.Label();
            this.outputFileSizeWithoutHeader = new System.Windows.Forms.Label();
            this.inputFileSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.uniqueSymbolCount = new System.Windows.Forms.Label();
            this.totalSymbolsCount = new System.Windows.Forms.Label();
            this.bitRateBox.SuspendLayout();
            this.compressionRatioBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // encodedFile
            // 
            this.encodedFile.AutoSize = true;
            this.encodedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.encodedFile.Location = new System.Drawing.Point(13, 13);
            this.encodedFile.Name = "encodedFile";
            this.encodedFile.Size = new System.Drawing.Size(82, 13);
            this.encodedFile.TabIndex = 0;
            this.encodedFile.Text = "Encoded file:";
            // 
            // encodedFilePath
            // 
            this.encodedFilePath.AutoSize = true;
            this.encodedFilePath.Location = new System.Drawing.Point(124, 13);
            this.encodedFilePath.Name = "encodedFilePath";
            this.encodedFilePath.Size = new System.Drawing.Size(28, 13);
            this.encodedFilePath.TabIndex = 1;
            this.encodedFilePath.Text = "path";
            // 
            // entropyLabel
            // 
            this.entropyLabel.AutoSize = true;
            this.entropyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entropyLabel.Location = new System.Drawing.Point(16, 57);
            this.entropyLabel.Name = "entropyLabel";
            this.entropyLabel.Size = new System.Drawing.Size(54, 13);
            this.entropyLabel.TabIndex = 2;
            this.entropyLabel.Text = "Entropy:";
            // 
            // entropyValue
            // 
            this.entropyValue.AutoSize = true;
            this.entropyValue.Location = new System.Drawing.Point(124, 57);
            this.entropyValue.Name = "entropyValue";
            this.entropyValue.Size = new System.Drawing.Size(42, 13);
            this.entropyValue.TabIndex = 3;
            this.entropyValue.Text = "entropy";
            // 
            // bitRateBox
            // 
            this.bitRateBox.Controls.Add(this.bitRateProportionWithHeader);
            this.bitRateBox.Controls.Add(this.bitRateProportionWithoutHeader);
            this.bitRateBox.Controls.Add(this.outputFileBitRateWithHeader);
            this.bitRateBox.Controls.Add(this.outputFileBitRateWithoutHeader);
            this.bitRateBox.Controls.Add(this.inputFileBitRate);
            this.bitRateBox.Controls.Add(this.label5);
            this.bitRateBox.Controls.Add(this.label4);
            this.bitRateBox.Controls.Add(this.label3);
            this.bitRateBox.Controls.Add(this.label2);
            this.bitRateBox.Controls.Add(this.label1);
            this.bitRateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bitRateBox.Location = new System.Drawing.Point(19, 158);
            this.bitRateBox.Name = "bitRateBox";
            this.bitRateBox.Size = new System.Drawing.Size(451, 144);
            this.bitRateBox.TabIndex = 4;
            this.bitRateBox.TabStop = false;
            this.bitRateBox.Text = "Bit rate";
            // 
            // bitRateProportionWithHeader
            // 
            this.bitRateProportionWithHeader.AutoSize = true;
            this.bitRateProportionWithHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bitRateProportionWithHeader.Location = new System.Drawing.Point(304, 111);
            this.bitRateProportionWithHeader.Name = "bitRateProportionWithHeader";
            this.bitRateProportionWithHeader.Size = new System.Drawing.Size(127, 13);
            this.bitRateProportionWithHeader.TabIndex = 11;
            this.bitRateProportionWithHeader.Text = "BRProportionWithHeader";
            // 
            // bitRateProportionWithoutHeader
            // 
            this.bitRateProportionWithoutHeader.AutoSize = true;
            this.bitRateProportionWithoutHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bitRateProportionWithoutHeader.Location = new System.Drawing.Point(155, 111);
            this.bitRateProportionWithoutHeader.Name = "bitRateProportionWithoutHeader";
            this.bitRateProportionWithoutHeader.Size = new System.Drawing.Size(142, 13);
            this.bitRateProportionWithoutHeader.TabIndex = 10;
            this.bitRateProportionWithoutHeader.Text = "BRProportionWithoutHeader";
            // 
            // outputFileBitRateWithHeader
            // 
            this.outputFileBitRateWithHeader.AutoSize = true;
            this.outputFileBitRateWithHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputFileBitRateWithHeader.Location = new System.Drawing.Point(304, 86);
            this.outputFileBitRateWithHeader.Name = "outputFileBitRateWithHeader";
            this.outputFileBitRateWithHeader.Size = new System.Drawing.Size(113, 13);
            this.outputFileBitRateWithHeader.TabIndex = 9;
            this.outputFileBitRateWithHeader.Text = "OFBitRateWithHeader";
            // 
            // outputFileBitRateWithoutHeader
            // 
            this.outputFileBitRateWithoutHeader.AutoSize = true;
            this.outputFileBitRateWithoutHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputFileBitRateWithoutHeader.Location = new System.Drawing.Point(155, 86);
            this.outputFileBitRateWithoutHeader.Name = "outputFileBitRateWithoutHeader";
            this.outputFileBitRateWithoutHeader.Size = new System.Drawing.Size(128, 13);
            this.outputFileBitRateWithoutHeader.TabIndex = 8;
            this.outputFileBitRateWithoutHeader.Text = "OFBitRateWithoutHeader";
            // 
            // inputFileBitRate
            // 
            this.inputFileBitRate.AutoSize = true;
            this.inputFileBitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputFileBitRate.Location = new System.Drawing.Point(158, 19);
            this.inputFileBitRate.Name = "inputFileBitRate";
            this.inputFileBitRate.Size = new System.Drawing.Size(51, 13);
            this.inputFileBitRate.TabIndex = 7;
            this.inputFileBitRate.Text = "IFBitRate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "With header";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Without header";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bit rate proportion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output file bit rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input file bit rate:";
            // 
            // compressionRatioBox
            // 
            this.compressionRatioBox.Controls.Add(this.compressionRatioWithHeader);
            this.compressionRatioBox.Controls.Add(this.compressionRatioWithoutHeader);
            this.compressionRatioBox.Controls.Add(this.outputFileSizeWithHeader);
            this.compressionRatioBox.Controls.Add(this.outputFileSizeWithoutHeader);
            this.compressionRatioBox.Controls.Add(this.inputFileSize);
            this.compressionRatioBox.Controls.Add(this.label6);
            this.compressionRatioBox.Controls.Add(this.label7);
            this.compressionRatioBox.Controls.Add(this.label8);
            this.compressionRatioBox.Controls.Add(this.label9);
            this.compressionRatioBox.Controls.Add(this.label10);
            this.compressionRatioBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.compressionRatioBox.Location = new System.Drawing.Point(19, 315);
            this.compressionRatioBox.Name = "compressionRatioBox";
            this.compressionRatioBox.Size = new System.Drawing.Size(451, 144);
            this.compressionRatioBox.TabIndex = 5;
            this.compressionRatioBox.TabStop = false;
            this.compressionRatioBox.Text = "Compression ratio";
            // 
            // compressionRatioWithHeader
            // 
            this.compressionRatioWithHeader.AutoSize = true;
            this.compressionRatioWithHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.compressionRatioWithHeader.Location = new System.Drawing.Point(304, 111);
            this.compressionRatioWithHeader.Name = "compressionRatioWithHeader";
            this.compressionRatioWithHeader.Size = new System.Drawing.Size(79, 13);
            this.compressionRatioWithHeader.TabIndex = 12;
            this.compressionRatioWithHeader.Text = "CRWithHeader";
            // 
            // compressionRatioWithoutHeader
            // 
            this.compressionRatioWithoutHeader.AutoSize = true;
            this.compressionRatioWithoutHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.compressionRatioWithoutHeader.Location = new System.Drawing.Point(155, 111);
            this.compressionRatioWithoutHeader.Name = "compressionRatioWithoutHeader";
            this.compressionRatioWithoutHeader.Size = new System.Drawing.Size(94, 13);
            this.compressionRatioWithoutHeader.TabIndex = 12;
            this.compressionRatioWithoutHeader.Text = "CRWithoutHeader";
            // 
            // outputFileSizeWithHeader
            // 
            this.outputFileSizeWithHeader.AutoSize = true;
            this.outputFileSizeWithHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputFileSizeWithHeader.Location = new System.Drawing.Point(304, 86);
            this.outputFileSizeWithHeader.Name = "outputFileSizeWithHeader";
            this.outputFileSizeWithHeader.Size = new System.Drawing.Size(98, 13);
            this.outputFileSizeWithHeader.TabIndex = 12;
            this.outputFileSizeWithHeader.Text = "OFSizeWithHeader";
            // 
            // outputFileSizeWithoutHeader
            // 
            this.outputFileSizeWithoutHeader.AutoSize = true;
            this.outputFileSizeWithoutHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputFileSizeWithoutHeader.Location = new System.Drawing.Point(155, 86);
            this.outputFileSizeWithoutHeader.Name = "outputFileSizeWithoutHeader";
            this.outputFileSizeWithoutHeader.Size = new System.Drawing.Size(113, 13);
            this.outputFileSizeWithoutHeader.TabIndex = 13;
            this.outputFileSizeWithoutHeader.Text = "OFSizeWithoutHeader";
            // 
            // inputFileSize
            // 
            this.inputFileSize.AutoSize = true;
            this.inputFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputFileSize.Location = new System.Drawing.Point(155, 20);
            this.inputFileSize.Name = "inputFileSize";
            this.inputFileSize.Size = new System.Drawing.Size(36, 13);
            this.inputFileSize.TabIndex = 12;
            this.inputFileSize.Text = "IFSize";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "With header";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Without header";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(6, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Compression ratio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(6, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Output file size [bytes]:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(7, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Input file size [bytes]:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.totalSymbolsCount);
            this.groupBox1.Controls.Add(this.uniqueSymbolCount);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(19, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Symbols count";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Unique";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Total";
            // 
            // uniqueSymbolCount
            // 
            this.uniqueSymbolCount.AutoSize = true;
            this.uniqueSymbolCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uniqueSymbolCount.Location = new System.Drawing.Point(155, 38);
            this.uniqueSymbolCount.Name = "uniqueSymbolCount";
            this.uniqueSymbolCount.Size = new System.Drawing.Size(80, 13);
            this.uniqueSymbolCount.TabIndex = 12;
            this.uniqueSymbolCount.Text = "uSymbolsCount";
            // 
            // totalSymbolsCount
            // 
            this.totalSymbolsCount.AutoSize = true;
            this.totalSymbolsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalSymbolsCount.Location = new System.Drawing.Point(304, 38);
            this.totalSymbolsCount.Name = "totalSymbolsCount";
            this.totalSymbolsCount.Size = new System.Drawing.Size(77, 13);
            this.totalSymbolsCount.TabIndex = 14;
            this.totalSymbolsCount.Text = "tSymbolsCount";
            // 
            // HuffmanStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.compressionRatioBox);
            this.Controls.Add(this.bitRateBox);
            this.Controls.Add(this.entropyValue);
            this.Controls.Add(this.entropyLabel);
            this.Controls.Add(this.encodedFilePath);
            this.Controls.Add(this.encodedFile);
            this.Name = "HuffmanStatistics";
            this.Text = "Huffman Statistics";
            this.bitRateBox.ResumeLayout(false);
            this.bitRateBox.PerformLayout();
            this.compressionRatioBox.ResumeLayout(false);
            this.compressionRatioBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label encodedFile;
        private System.Windows.Forms.Label encodedFilePath;
        private System.Windows.Forms.Label entropyLabel;
        private System.Windows.Forms.Label entropyValue;
        private System.Windows.Forms.GroupBox bitRateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox compressionRatioBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label inputFileBitRateValue;
        private System.Windows.Forms.Label inputFileBitRate;
        private System.Windows.Forms.Label outputFileBitRateWithoutHeader;
        private System.Windows.Forms.Label outputFileBitRateWithHeader;
        private System.Windows.Forms.Label bitRateProportionWithoutHeader;
        private System.Windows.Forms.Label bitRateProportionWithHeader;
        private System.Windows.Forms.Label inputFileSize;
        private System.Windows.Forms.Label outputFileSizeWithoutHeader;
        private System.Windows.Forms.Label outputFileSizeWithHeader;
        private System.Windows.Forms.Label compressionRatioWithoutHeader;
        private System.Windows.Forms.Label compressionRatioWithHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalSymbolsCount;
        private System.Windows.Forms.Label uniqueSymbolCount;
    }
}
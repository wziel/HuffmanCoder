using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCoder.UI
{
    public partial class HuffmanStatistics : Form
    {
        private Statistics statistics;
        private String inputFilePath;

        public HuffmanStatistics(Statistics statistics, String inputFilePath)
        {
            this.statistics = statistics;
            this.inputFilePath = inputFilePath;

            InitializeComponent();
            SetStatistics();
        }

        private void SetStatistics()
        {
            this.encodedFilePath.Text = inputFilePath;
            this.entropyValue.Text = statistics.Entropy.ToString();

            // Bit rate box
            this.inputFileBitRate.Text = statistics.BitRateStatistics.InputFileBitRate.ToString();
            this.outputFileBitRateWithoutHeader.Text = statistics.BitRateStatistics.OutputFileBitRate.ToString();
            this.outputFileBitRateWithHeader.Text = statistics.BitRateStatistics.OutputFileBitRateWithHeader.ToString();
            this.bitRateProportionWithoutHeader.Text = statistics.BitRateStatistics.BitRateProportion.ToString();
            this.bitRateProportionWithHeader.Text = statistics.BitRateStatistics.BitRateProportionWithHeader.ToString();

            // Compression rate box
            this.inputFileSize.Text = statistics.FileSizeStatistics.InputFileSize.ToString();
            this.outputFileSizeWithoutHeader.Text = statistics.FileSizeStatistics.OutputFileSize.ToString();
            this.outputFileSizeWithHeader.Text = statistics.FileSizeStatistics.OutputFileSizeWithHeader.ToString();
            this.compressionRatioWithoutHeader.Text = statistics.FileSizeStatistics.CompressionRatio.ToString();
            this.compressionRatioWithHeader.Text = statistics.FileSizeStatistics.CompressionRatioWithHeader.ToString();

        }

        private void HuffmanStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class HufffmanCoder : Form
    {
        public HufffmanCoder()
        {
            InitializeComponent();
        }

        private void encodeBTN_Click(object sender, EventArgs e)
        {
            System.IO.File.Create(outputTB.Text).Close();
            if (!System.IO.File.Exists(inputTB.Text))
            {
                MessageBox.Show("Please choose input file and output file");
                return;
            }
            UICoder coder = new UICoder();
            HuffmanEncodeModel huffmanEncodeModel;
            if (modelWithoutMemoryRadio.Checked)
                huffmanEncodeModel = HuffmanEncodeModel.Standard;
            else if (blockModelRadio.Checked)
                huffmanEncodeModel = HuffmanEncodeModel.Block;
            else
                huffmanEncodeModel = HuffmanEncodeModel.Markov;
            coder.Encode(inputTB.Text, outputTB.Text, huffmanEncodeModel);
        }

        private void decodeBTN_Click(object sender, EventArgs e)
        {
            System.IO.File.Create(inputTB.Text);
            if (!System.IO.File.Exists(outputTB.Text))
            {
                MessageBox.Show("Please choose input file and output file");
                return;
            }
            UIDecoder decoder = new UIDecoder();
            decoder.Decode(inputTB.Text, outputTB.Text);
        }

        private void inputFileBTN_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputTB.Text = openFileDialog1.FileName;
            }
        }

        private void outputFileBTN_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputTB.Text = saveFileDialog1.FileName;
            }
        }
    }
}

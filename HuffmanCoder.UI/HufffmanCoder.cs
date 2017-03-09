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
            UICoder coder = new UICoder();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HuffmanEncodeModel huffmanEncodeModel;
                if (modelWithoutMemoryRadio.Checked)
                    huffmanEncodeModel = HuffmanEncodeModel.Standard;
                else if (blockModelRadio.Checked)
                    huffmanEncodeModel = HuffmanEncodeModel.Block;
                else
                    huffmanEncodeModel = HuffmanEncodeModel.Markov;
                coder.Encode(openFileDialog1.FileName, huffmanEncodeModel);
            }
        }

        private void decodeBTN_Click(object sender, EventArgs e)
        {
            string name = saveFileDialog1.FileName;
        }
    }
}

using HuffmanCoder.Logic.CodecInterfaces.Decoder;
using HuffmanCoder.Logic.CodecInterfaces.Decoder.MarkowHuffmanDecoder;
using HuffmanCoder.Logic.CodecInterfaces.Decoder.PairHuffmanDecoder;
using HuffmanCoder.Logic.CodecInterfaces.Decoder.StandardHuffmanDecoder;
using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.Readers.Decoding;
using HuffmanCoder.Logic.Writers.Decoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UI
{
    public class UIDecoder
    {
        public void Decode(string inputFilePath, string outputFilePath)
        {
            IHuffmanDecoderInterface huffmanDecoderInterface;
            IDecoderReader input = new DecoderReader(inputFilePath);
            IDecoderFileWriter output = new DecoderFileWriter(outputFilePath);
            //if (huffmanEncodeModel == HuffmanEncodeModel.Standard)
            //   // huffmanCoderInterface = new StandardHuffmanDecoderInterface(input, output);
            //else if (huffmanEncodeModel == HuffmanEncodeModel.Block)
            //    //huffmanCoderInterface = new PairHuffmanDecoderInterface(input, output);
            //else
            //    //huffmanCoderInterface = new MarkowHuffmanDecoderInterface(input, output);
            //huffmanDecoderInterface.Decode();
        }
    }
}

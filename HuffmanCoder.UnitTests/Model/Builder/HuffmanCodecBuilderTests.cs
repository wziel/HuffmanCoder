using HuffmanCoder.Model.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Builder
{
    [TestClass]
    public class HuffmanCodecBuilderTests
    {
        IComparer<char> charComparer = Comparer<char>.Create((a, b) => a.CompareTo(b));

        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod]
        public void Add_CanAddValue()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            //when
            builder.Add('c');
            //then - sukces
        }

        [TestMethod]
        public void GetCoder_WhenMoreThanOneSymbolsAdded()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            builder.Add('c');
            builder.Add('c');
            builder.Add('d');
            //when
            builder.GetCoder();
            //then - sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetCoder_ExceptionWhenNoSymbolsAdded()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            //when
            builder.GetCoder();
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetCoder_ExceptionWhenOneSymbolsAdded()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            builder.Add('a');
            builder.Add('a');
            builder.Add('a', 4);
            //when
            builder.GetCoder();
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        public void GetDecoder_WhenMoreThanOneSymbolsAdded()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            builder.Add('c');
            builder.Add('c');
            builder.Add('d');
            //when
            builder.GetDecoder();
            //then - sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetDecoder_ExceptionWhenNoSymbolsAdded()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            //when
            builder.GetDecoder();
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetDecoder_ExceptionWhenOneSymbolsAdded()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>(charComparer);
            builder.Add('a');
            builder.Add('a');
            builder.Add('a', 4);
            //when
            builder.GetDecoder();
            //then - no exception, fail
            throw new AssertFailedException();
        }
    }
}
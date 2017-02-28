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
    public class HuffmanTreeBuilderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod]
        public void Add_CanAddValue()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>();
            //when
            builder.Add('c');
            //then - sukces
        }

        [TestMethod]
        public void Build_CanBuildWhenSomeSymbolsAdded()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>();
            builder.Add('c');
            builder.Add('c');
            builder.Add('d');
            //when
            builder.Build();
            //then - sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Build_CannotBuildWhenNoSymbolsAdded()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>();
            //when
            builder.Build();
            //then - no exception, fail
            throw new AssertFailedException();
        }
    }
}

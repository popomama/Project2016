using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project2016.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016.Helpers.Tests
{
    [TestClass()]
    public class NodeTests
    {
        [TestMethod()]
        public void PrintNodeListTest()
        {

            Node<int> nd = Node<int>.BuildIntList(10, 100);
            Node<int>.PrintNodeList(nd);

        }
    }
}
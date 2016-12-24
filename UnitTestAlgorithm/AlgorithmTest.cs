using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project2016.DP;


namespace UnitTestAlgorithm
{
    [TestClass]
    public class AlgorithmTest
    {
        [TestMethod]
        public void TestMatrixChainOrder()
        {
            GFG cfg = new GFG();
            int[] dim4_1 = { 10, 20, 30, 40, 30 };
            int[] dim4_2 = { 40, 20, 30, 10, 30 };

            int[] dim1 = { 10, 20 };
            int[] dim2 = { 10, 20, 30 };

            int minCalcuation;
            minCalcuation= cfg.MatrixChainOrder(dim1);
            Assert.AreEqual(0, minCalcuation);

            minCalcuation = cfg.MatrixChainOrder(dim2);
            Assert.AreEqual(6000, minCalcuation);

            minCalcuation = cfg.MatrixChainOrder(dim4_1);
            //((AB)C)D --> 10*20*30 + 10*30*40 + 10*40*30
            Assert.AreEqual(30000, minCalcuation);

            minCalcuation = cfg.MatrixChainOrder(dim4_2); 
            //(A(BC))D --> 20*30*10 + 40*20*10 + 40*10*30
            Assert.AreEqual(26000, minCalcuation);


        }
    }
}

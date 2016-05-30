using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2016.Helpers;

namespace Project2016.TreeGraph
{
    class TestTreeGraph
    {
        public static void  Test_CC_V6_47_BuildOrder()
        {
            Graph g = new Graph(7);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 3);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2,5);
            g.AddEdge(3, 2);
            g.AddEdge(3, 5);
            g.AddEdge(3, 6);
            g.AddEdge(4, 3);
            g.AddEdge(4, 6);
            g.AddEdge(6, 5);

            CrackCode_TreeGraph CC_TG = new CrackCode_TreeGraph();
            int[] sortedarray = CC_TG.CC_V6_47_BuildOrder(g);

       //     CC_TG.CC_V6_47_BuildOrderAll(g);
            

        }

        public static void Test_CC_V6_47_BuildOrder_All()
        {
            Graph g = new Graph(5);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(2, 4);

            CrackCode_TreeGraph CC_TG = new CrackCode_TreeGraph();
            //     int[] sortedarray = CC_TG.CC_V6_47_BuildOrder(g);

            CC_TG.CC_V6_47_BuildOrderAll(g);


            g= new Graph(6);
            g.AddEdge(5,0);
            g.AddEdge(4, 0);
            g.AddEdge(5, 2);
            g.AddEdge(4,1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            //CrackCode_TreeGraph CC_TG = new CrackCode_TreeGraph();
            //     int[] sortedarray = CC_TG.CC_V6_47_BuildOrder(g);

            CC_TG.CC_V6_47_BuildOrderAll(g);


        }
    }
}

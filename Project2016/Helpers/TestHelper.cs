﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project2016.Helpers
{
    class TestHelper
    {
        public static void TestHeap()
        {
            int currentVal;
            Heap h = new Heap(16);
            Random r = new Random(1000);
            for (int i = 0; i < 10; i++)
            {
                currentVal = r.Next(100);
                h.insert(currentVal);
            }

            for (int i = 0; i < 10; i++)
                Console.Write(h.Items[i] + "->");
            Console.WriteLine();

            for(int i=0;i<10;i++)
            {
                currentVal = h.deleteMin();
                Console.Write(currentVal + "->");
            }

            Console.WriteLine();
        }
    }
}

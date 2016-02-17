using System;
using System.Collections.Generic;
using System.Text;
using Project2016.Helpers;

namespace Project2016.TreeGraph
{
    class CrackCode_TreeGraph
    {

        //Minimal Tree: Given a sortd(increasing order) array with unique integer elements, wrte an algorithm
        //to create a binary sear ch tree with minimal height.
        TreeNode createMinimalBST(int[] arr)
        {
            return createMinimalBST(arr, 0, arr.Length - 1);
        }

        TreeNode createMinimalBST(int[] arr, int start, int end)
        {
            if (start > end)
                return null;
            int mid = (start + end) / 2;
            TreeNode root = new TreeNode(arr[mid]);
            root.Left = createMinimalBST(arr, start, mid - 1);
            root.Right = createMinimalBST(arr, mid + 1, end);

            return root;

        }

        //List of Depths; Given a binary tree, design an algorithm which creates a linked list of all the nodes at
        //each depth(eg. if you have a tree with depth D, you will have  D linked lists.
        List<List<TreeNode>> createLevelLinkedList(TreeNode root)
        {
      
            List<List<TreeNode>> lists = new List<List<TreeNode>>();
            createLevelLinkedList(root, lists, 1);

            return lists;
        }
        void createLevelLinkedList(TreeNode root, List<List<TreeNode>> lists, int level )
        {
            if (root == null)
                return;

            List<TreeNode> l;
            if (lists.Count != level)
            {
                l = new List<TreeNode>();
            }
            else
                l = lists[level];

            l.Add(root);

            createLevelLinkedList(root.Left, lists, level + 1);
            createLevelLinkedList(root.Right, lists, level + 1);



               
            
            



        }

    }
}

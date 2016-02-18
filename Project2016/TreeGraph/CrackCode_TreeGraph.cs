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

        //Rando Node: You are implementing a binary search tree class from scratch, which , in addition
        //to insert, find and delete, has a method getRandomNode() which returns a random node from the tree. 
        //all nodes should be eaually likely to be choen. Design and implement an algorighm for
        //getRandomNode, and explain how you would implement the rest of the methods.
        class TreeRandom 
        {
            //the idea is to record the size of a specific node
            // the problem of this implementation is how to adjust the size when we delete a node?
            TreeNodeWithSize root = null;
            public int size()
            {
                return root == null ? 0 : root.size;
            }

            public void insertInOrder(int value)
            {
                if(root==null)
                    root = new TreeNodeWithSize(value);
                else
                {
                    root.InsertInOrder(value);
                }
            }
            public  TreeNodeWithSize getRandomNode()
            {
                if (root == null)
                    return null;

                Random r = new Random(size());
                int i = r.Next() + 1;// get the int from 1 to size()
                return root.getIthNode(i);
            }
        }

        class TreeNodeWithSize
        {
            public int size;
            int Value;
            public TreeNodeWithSize Left, Right;
            public TreeNodeWithSize(int val)
            {
                this.Value = val;
                size = 1;
                Left =Right = null;

            }

            public void InsertInOrder(int val)
            {
                if(val<=this.Value)
                {
                    if(this.Left ==null)
                        this.Left  = new TreeNodeWithSize(val);
                    else
                        this.Left.InsertInOrder(val);
                }
                else
                {
                    if(this.Right ==null)
                        this.Right = new TreeNodeWithSize(val);
                    else
                        this.Right.InsertInOrder(val);
                }

                this.size++;
            }
            public TreeNodeWithSize getIthNode(int i)
            {

                int leftNodeSize = this.Left == null ? 0 : this.Left.size;
                if (i == leftNodeSize+1)
                    return this;

                if (i < this.size)
                    return this.Left.getIthNode(i);
                else
                    return this.Right.getIthNode(i - size-1);
            }
        }
    }
}

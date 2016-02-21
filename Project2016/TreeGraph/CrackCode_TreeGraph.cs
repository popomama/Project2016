﻿using System;
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

        //Random Node: You are implementing a binary search tree class from scratch, which , in addition
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


        // Path with Sum: Given a binary tree in whihch each node contains an integer value(which might be)
        // positive or negative). Design an algorithm to count the number of paths that sum to a given value.
        // the path doesn't need to start or end at the root or a leaf, but it must go downwards (travelling 
        // only from parent nodes to child nodes.
        int countPathWithSum(TreeNode root, int sum)
        {
            // the idea is to use recursion
            // complexity: avg case: O(NLogN), depth is LogN,  CountPathwithSum will be called  by NLogN times
            //            worst case: O(N^2) , tree with straight line down, to each node, the CountPathWith sum will be
            // called 1+2+3+...+N times, so total is O(N^2)
            int totalcount = 0;
            totalcount = countPathWithSum(root, sum, 0);
            
            if(root!=null)
            {
                totalcount += countPathWithSum(root.Left, sum); // starting from the left
                // totalcount += countPathWithSum(root.Left, sum, 0); can't use this one, as otherwise we will not be able to comeback
                totalcount += countPathWithSum(root.Right, sum); // starting from the right

            }

            return totalcount;


        }

        int countPathWithSum(TreeNode root, int sum, int currentSum)
        {
            int total=0;
            if (root == null)
                return 0;

            currentSum+=root.Value;
            if (sum == currentSum )
                total += 1;


            total += countPathWithSum(root.Left, sum, currentSum);
            total += countPathWithSum(root.Right, sum, currentSum);

            return total;
        }


        //Path with Sum:  solution2
        //use the hashcode to store the runningsum, check the hashtable to compare if there is available runningsum 
        //equals the current runningsum - target running sum
        //the time complexity is O(N) since each node will be visited only once, the average space cost is O(logN) and
        //worst space cost is O(N).
        int countPathWithSum2(TreeNode root, int targetSum)
        {
            if (root == null)
                return 0;

            //the key is the running sum while the value is the count of the running sum
            Dictionary<int, int> AvailableRunningSum = new Dictionary<int, int>();

            return countPathWithSum2(root, targetSum, 0, AvailableRunningSum);

        }

        int countPathWithSum2(TreeNode currentNode, int targetSum, int currentRunningSum, Dictionary<int,int> availableRunningSum)
        {
            if(currentNode==null)
                return 0;

            int totalCount = 0;

            currentRunningSum+=currentNode.Value;

            totalCount = availableRunningSum[currentRunningSum - targetSum];//check the hash table to see how many existingRunningsum with the 
            //value of currentRunningSum - targetSum

            if (targetSum == currentRunningSum)//we find a match
            {
                totalCount++;
                IncrementAvailableRunningSum(availableRunningSum, targetSum, 1);
            }
            else
            {
              //  totalCount = availableRunningSum[currentRunningSum - targetSum];
                //totalCount++;
                IncrementAvailableRunningSum(availableRunningSum, currentRunningSum, 1);

            }
            totalCount += countPathWithSum2(currentNode.Left, targetSum, currentRunningSum, availableRunningSum);
            totalCount += countPathWithSum2(currentNode.Right, targetSum, currentRunningSum, availableRunningSum);

            IncrementAvailableRunningSum(availableRunningSum, currentRunningSum, -1);

            return totalCount;
        }

        void IncrementAvailableRunningSum(Dictionary<int,int> availableRunningSum, int key, int delta)
        {
            if (availableRunningSum.ContainsKey(key))
            {
                availableRunningSum[key] += delta;
                if (availableRunningSum[key] == 0)
                    availableRunningSum.Remove(key);
            }
            else
            {
                availableRunningSum.Add(key, delta);
            }
        }

        //Check Subtree:

    }

}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Program start");


//Create a tree
/*
 *   3
 *  2  4
 * 1 5 6
 */

TreeNode root = new TreeNode(3);
root.appendLeftChild(new TreeNode(2));
root.appendRightChild(new TreeNode(4));
root.leftChild?.appendLeftChild(new TreeNode(1));
root.rightChild?.appendLeftChild(new TreeNode(5));
root.rightChild?.appendRightChild(new TreeNode(6));


//Create a tree
/*
 *   3
 *  2  5
 * 1 6 1
 */

TreeNode root2 = new TreeNode(3);
root2.appendLeftChild(new TreeNode(2));
root2.appendRightChild(new TreeNode(5));
root2.leftChild?.appendLeftChild(new TreeNode(1));
root2.rightChild?.appendLeftChild(new TreeNode(3));
root2.rightChild?.appendRightChild(new TreeNode(1));

//Create a tree
/*
 *    4
 *  3   8
 * 1   5 7
 */

TreeNode root3 = new TreeNode(4);
root3.appendLeftChild(new TreeNode(3));
root3.leftChild?.appendLeftChild(new TreeNode(1));
root3.appendRightChild(new TreeNode(8));
root3.rightChild?.appendLeftChild(new TreeNode(5));
root3.rightChild?.appendRightChild(new TreeNode(9));

//Create a tree
/*
 *    10
 *  5   19
 * 1 6  17 21
 */

TreeNode root4 = new TreeNode(10);
root4.appendLeftChild(new TreeNode(5));
root4.leftChild?.appendLeftChild(new TreeNode(1));
root4.rightChild?.appendLeftChild(new TreeNode(6));
root4.appendRightChild(new TreeNode(19));
root4.rightChild?.appendLeftChild(new TreeNode(17));
root4.rightChild?.appendRightChild(new TreeNode(21));

//Create a tree
/*
 *    10
 *  7    12
 * 1 8  11 13
 *    9
 */

TreeNode root5 = new TreeNode(10);
root5.appendLeftChild(new TreeNode(7));
root5.leftChild?.appendLeftChild(new TreeNode(1));
root5.rightChild?.appendLeftChild(new TreeNode(8));
root5.rightChild?.leftChild?.appendRightChild(new TreeNode(9));
root5.appendRightChild(new TreeNode(12));
root5.rightChild?.appendLeftChild(new TreeNode(11));
root5.rightChild?.appendRightChild(new TreeNode(13));




Console.WriteLine(BSTChecker.checkBST(root));
Console.WriteLine(BSTChecker.checkBST(root2));
Console.WriteLine(BSTChecker.checkBST(root3));
Console.WriteLine(BSTChecker.checkBST(root4));
Console.WriteLine(BSTChecker.checkBST(root5));



public class TreeNode
{
    public TreeNode(int value)
    {
        this.assignedValue = value;
        
    }

    public int assignedValue;
    public TreeNode? leftChild = null;
    public TreeNode? rightChild = null;



    public void appendLeftChild(TreeNode appendThisNode)
    {
        this.leftChild = appendThisNode;


    }
    public void appendRightChild(TreeNode appendThisNode)
    {
        this.rightChild = appendThisNode;

    }

}

public static class BSTChecker
{

    public static bool checkBST(TreeNode rootNode)
    {
        return noDuplicatesBST(rootNode);
    }

    //barebones all nodes getter for testing
    private static List<TreeNode> allNodesFromRoot(TreeNode root)
    {
        List<TreeNode> result = new();

        List<TreeNode> splits = new();
        TreeNode currentSplit = root;

        while(currentSplit != null)
        {
            result.Add(currentSplit);
            if(currentSplit.rightChild != null)
            {
                splits.Add(currentSplit.rightChild);
            }
            if(currentSplit.leftChild != null)
            {
                currentSplit = currentSplit.leftChild;
            }else if(splits.Count > 0)
            {
                currentSplit = splits[splits.Count - 1];
                splits.RemoveAt(splits.Count - 1);
            }else
            {
                currentSplit = null;
            }
        }
        Console.WriteLine("All nodes from this root: ");
        foreach (var item in result)
        {
            Console.WriteLine(item.assignedValue);
        }
        return result;
        
    }

    private static bool noDuplicatesBST(TreeNode root)
    {
        List<int> values = new();

        int currentMax = root.assignedValue;
        int currentMin = 0;

        List<TreeNode> splits = new();
        TreeNode? currentSplit = root;

        while (currentSplit != null)
        {
            Console.WriteLine(currentSplit.assignedValue);

            values.Add(currentSplit.assignedValue);

            //This will check for duplicates
            if(values.Count != values.Distinct().Count())
            {
                Console.WriteLine("Not a BST, contains duplicated value: " + currentSplit.assignedValue);
                return false;
            }

            if (currentSplit.rightChild != null)
            {
                //Not BST when right child smaller or equal
                if(currentSplit.rightChild.assignedValue <= currentSplit.assignedValue)
                {
                    return false;
                }

                //Not BST when right child larger than current maximum
                if (currentSplit.rightChild.assignedValue >= currentMax)
                {
                    if(currentMax != currentSplit.assignedValue)
                    {
                        
                        return false;
                    }
                    

                }

                splits.Add(currentSplit.rightChild);

            }

            if (currentSplit.leftChild != null)
            {

                //Not BST when left child larger or equal
                if (currentSplit.leftChild.assignedValue >= currentSplit.assignedValue)
                {

                    return false;
                    
                }

                //Not BST when left child smaller than current minimum
                if (currentSplit.leftChild.assignedValue <= currentMin)
                {
                    return false;
                    
                }

                currentSplit = currentSplit.leftChild;


            }
            else if (splits.Count > 0)
                {
                if(splits[splits.Count - 1].assignedValue < currentMax)
                {
                    currentMin = splits[splits.Count - 1].assignedValue;
                }
                else
                {
                    currentMin = currentMax;
                    currentMax = splits[splits.Count - 1].assignedValue;
                }
                currentSplit = splits[splits.Count - 1];
                splits.RemoveAt(splits.Count - 1);
                }else
                    {
                     currentSplit = null;
                    }
        }

        return true;


    }
}
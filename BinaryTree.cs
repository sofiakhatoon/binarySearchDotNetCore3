using System;
namespace bst
{
class BinaryTree
{
    public Node Root { get; set; }
    public Node AddRecursive(Node current,int value){
        
        if(value>current.Data)
        {
            if(current.LeftNode==null) {
                current.LeftNode=new Node(){Data=value};
            }
            else
            current.LeftNode=AddRecursive(current.LeftNode,value);
        }
        else
        {
            if(current.RightNode==null)current.RightNode=new Node(){Data=value};
            else
            current.RightNode=AddRecursive(current.RightNode,value);
        }
        return current;
    }
    public bool Add(int value)
    {
        if(this.Root==null)
        {
            Node rootNode = new Node();
            rootNode.Data=value;
            this.Root=rootNode;
            Console.WriteLine("Adding root "+value );
            return true;
        }
        else
        {
            Console.WriteLine("Adding node "+value + " when root is "+ this.Root.Data);
        }
        
        Node after = this.Root;
        after = this.AddRecursive(after,value);
 
 Console.WriteLine("value added to tree " + value);
        return true;
    }
 
    public Node Find(int value)
    {
        return this.Find(value, this.Root);            
    }
 
    public void Remove(int value)
    {
        Remove(this.Root, value);
    }
 
    private Node Remove(Node parent, int key)
    {
        if (parent == null) return parent;
 
        if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key); else if (key > parent.Data)
            parent.RightNode = Remove(parent.RightNode, key);
 
        // if value is same as parent's value, then this is the node to be deleted  
        else
        {
            // node with only one child or no child  
            if (parent.LeftNode == null)
                return parent.RightNode;
            else if (parent.RightNode == null)
                return parent.LeftNode;
 
            // node with two children: Get the inorder successor (smallest in the right subtree)  
            parent.Data = MinValue(parent.RightNode);
 
            // Delete the inorder successor  
            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }
 
        return parent;
    }
 
    private int MinValue(Node node)
    {
        int minv = node.Data;
 
        while (node.LeftNode != null)
        {
            minv = node.LeftNode.Data;
            node = node.LeftNode;
        }
 
        return minv;
    }
 
    private Node Find(int value, Node parent)
    {
        if (parent != null)
        {
            if (value == parent.Data) return parent;
            if (value < parent.Data)
                return Find(value, parent.LeftNode);
            else
                return Find(value, parent.RightNode);
        }
 
        return null;
    }
 
    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.Root);
    }
 
    private int GetTreeDepth(Node parent)
    {
        return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }
 
    public void TraversePreOrder(Node parent)
    {
        
        if (parent != null)
        {
            Console.WriteLine("Travesing pre order i.e. depthwise left to right "+parent.Data + " ");
            TraversePreOrder(parent.LeftNode);
            Console.WriteLine("End Left ");
            TraversePreOrder(parent.RightNode);
            Console.WriteLine("End right ");
        }
        else
        {
            Console.WriteLine("");
        }
    }
 
    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.LeftNode);
            Console.WriteLine(parent.Data + " ");
            TraverseInOrder(parent.RightNode);
        }
         else
        {
            Console.WriteLine("");
        }
    }
 
    public void TraversePostOrder(Node parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.LeftNode);
            TraversePostOrder(parent.RightNode);
            Console.WriteLine(parent.Data + " ");
        }
         else
        {
            Console.WriteLine("");
        }
    }
}
}

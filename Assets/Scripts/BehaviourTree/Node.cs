using System.Collections.Generic;

namespace BehaviourTree {
//------------------------------------------

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node
{

    protected NodeState state;
    
    public Node parent = null;
    protected List<Node> children = new();

    private Dictionary<string, object> dataContext = new Dictionary<string, object>();

    public Node() {}
    public Node(List<Node> children) {
        foreach (Node child in children) {
            Attach(child);
        }
    }
    public Node(Node parent) {
        parent.Attach(this);
    }
    public Node(List<Node> children, Node parent) {
        foreach (Node child in children) {
            Attach(child);
        }

        parent.Attach(this);
    } 

    public void Attach(Node node) {
        node.parent = this;
        children.Add(node);
    }

    public virtual NodeState Evaluate() => NodeState.FAILURE;



    public void SetData(string key, object value)
    {
        dataContext[key] = value;
    }

    public object GetData(string key) {
        object value;
        if (dataContext.TryGetValue(key, out value))
            return value;

        Node node = parent;
        while (node != null) {

            value = node.GetData(key);
            if (value != null)
                return value;
            node = node.parent;

        }
        return null;
    }

    public bool ClearData(string key) {
        if (dataContext.ContainsKey(key)) {
            dataContext.Remove(key);
            return true;
        }

        Node node = parent;
        while (node != null) {

            bool cleared = node.ClearData(key);
            if (cleared)
                return true;
            node = node.parent;
            
        }
        return false;
    }

}

}

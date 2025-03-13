using System.Collections.Generic;

namespace BehaviourTree {
//------------------------------------------

/// <summary>
/// Evaluate child nodes in order <br/>
/// Stop the sequence when a node is running or succeeds<br/>
/// <br/>
/// !! Order of children is important !!
/// </summary>
public class Selector: Node
{
    public Selector() : base() {}
    public Selector(List<Node> children) : base(children) {}
    public Selector(Node parent) : base(parent) {}
    public Selector(List<Node> children, Node parent) : base(children, parent) {}
    

    public override NodeState Evaluate() {

        foreach (Node child in children) 
            switch (child.Evaluate()) {
                case NodeState.FAILURE:
                    continue;
                case NodeState.RUNNING:
                    return NodeState.RUNNING;
                case NodeState.SUCCESS:
                    return NodeState.SUCCESS;
                default:
                    continue;
            }

        return NodeState.FAILURE;
    }

}

}

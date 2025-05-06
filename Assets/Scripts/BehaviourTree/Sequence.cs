using System.Collections.Generic;

namespace BehaviourTrees {
//------------------------------------------

/// <summary>
/// Evaluate child nodes in order <br/>
/// Stop the sequence when a node fails<br/>
/// <br/>
/// !! Order of children is important !!
/// </summary>
public class Sequence: Node
{
    public Sequence() : base() {}
    public Sequence(List<Node> children) : base(children) {}
    public Sequence(Node parent) : base(parent) {}
    public Sequence(List<Node> children, Node parent) : base(children, parent) {}
    

    public override NodeState Evaluate() {
        
        bool anyChildRunning = false;

        foreach (Node child in children) 
            switch (child.Evaluate()) {
                case NodeState.FAILURE:
                    return NodeState.FAILURE;
                case NodeState.RUNNING:
                    anyChildRunning = true;
                    continue;
                case NodeState.SUCCESS:
                    continue;
                default:
                    return NodeState.SUCCESS;
            }

        return anyChildRunning? NodeState.RUNNING 
                              : NodeState.SUCCESS;
    }

}

}

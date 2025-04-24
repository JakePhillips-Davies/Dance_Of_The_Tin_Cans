using System.Collections.Generic;

namespace BehaviourTree {
//------------------------------------------

/// <summary>
/// Evaluate child nodes in order <br/>
/// Doesn't stop the sequence<br/>
/// <br/>
/// !! Order of children is important !!
/// </summary>
public class Runner: Node
{
    public Runner() : base() {}
    public Runner(List<Node> children) : base(children) {}
    public Runner(Node parent) : base(parent) {}
    public Runner(List<Node> children, Node parent) : base(children, parent) {}
    

    public override NodeState Evaluate() {

        foreach (Node child in children) 
            child.Evaluate();

        return NodeState.SUCCESS;
    }

}

}

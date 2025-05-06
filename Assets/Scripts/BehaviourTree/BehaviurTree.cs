using UnityEngine;

namespace BehaviourTrees {
//------------------------------------------

public abstract class BehaviourTree : MonoBehaviour
{

    public Node root { get; private set; } = null;

    protected void Start()
    {
        root = SetupTree();
    }

    private void FixedUpdate()
    {
        root?.Evaluate();
    }

    protected abstract Node SetupTree();

}


}
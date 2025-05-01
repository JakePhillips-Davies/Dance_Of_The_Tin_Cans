using UnityEngine;

namespace BehaviourTree {
//------------------------------------------

public abstract class BehaviurTree : MonoBehaviour
{

    private Node root = null;

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
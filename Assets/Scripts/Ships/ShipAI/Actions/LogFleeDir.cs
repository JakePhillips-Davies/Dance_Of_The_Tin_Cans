using BehaviourTree;
using UnityEngine;

public class LogFleeDir : Node
{
    private SpaceShip ship;

    public LogFleeDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            ship.SetFleeDir(Vector3.zero);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
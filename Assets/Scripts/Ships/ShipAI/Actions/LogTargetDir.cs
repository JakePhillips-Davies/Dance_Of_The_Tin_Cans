using BehaviourTree;
using UnityEngine;

public class LogTargetDir : Node
{
    private SpaceShip ship;

    public LogTargetDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            Transform target = ship.target;
    
            Vector3 desiredDir = target.transform.position - ship.transform.position;
    
            ship.SetTargetDir(desiredDir.normalized);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
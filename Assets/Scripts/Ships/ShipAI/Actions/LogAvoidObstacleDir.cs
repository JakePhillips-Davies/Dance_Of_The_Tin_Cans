using BehaviourTree;
using UnityEngine;

public class LogAvoidObstacleDir : Node
{
    private SpaceShip ship;

    public LogAvoidObstacleDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            ship.SetAvoidObstacleDir(Vector3.zero);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
using BehaviourTrees;
using UnityEngine;

public class LogLeaveDir : Node
{
    private SpaceShip ship;

    public LogLeaveDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            ship.SetTargetDir(ship.transform.position.normalized); // Away from 0, 0, 0
            ship.SetTargetDist(ship.searchRange);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
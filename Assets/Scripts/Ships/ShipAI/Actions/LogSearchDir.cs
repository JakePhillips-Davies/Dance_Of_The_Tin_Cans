using BehaviourTree;
using UnityEngine;

public class LogSearchDir : Node
{
    private SpaceShip ship;

    public LogSearchDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            ship.SetTargetDir((ship.searchPoint - ship.transform.position).normalized);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
using BehaviourTrees;
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
            ship.SetTargetDist((ship.searchPoint - ship.transform.position).magnitude);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
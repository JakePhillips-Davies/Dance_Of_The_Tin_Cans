using BehaviourTree;
using UnityEngine;

public class ClearDirectionLogs : Node
{
    private SpaceShip ship;

    public ClearDirectionLogs(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        ship.SetTargetDir(Vector3.zero);
        ship.SetAvoidObstacleDir(Vector3.zero);
        ship.SetFleeDir(Vector3.zero);
        ship.SetDesiredMoveDir(Vector3.zero);

        return NodeState.SUCCESS;
    }
}
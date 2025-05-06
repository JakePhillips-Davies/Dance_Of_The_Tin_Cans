using BehaviourTrees;
using UnityEngine;

public class ClearDirectionLogs : Node
{
    private SpaceShip ship;

    public ClearDirectionLogs(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        ship.SetDesiredMoveDir(Vector3.zero);

        ship.SetTargetDir(Vector3.zero);

        ship.SetAvoidObstacleDir(Vector3.zero);
        ship.SetClosestObstacleDist(100000);
        
        ship.SetFleeDir(Vector3.zero);
        ship.SetClosestHostileDist(100000);

        return NodeState.SUCCESS;
    }
}
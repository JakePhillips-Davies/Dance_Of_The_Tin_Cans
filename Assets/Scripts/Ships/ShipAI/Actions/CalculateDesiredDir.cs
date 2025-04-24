using BehaviourTree;
using UnityEngine;

public class CalculateDesiredDir : Node
{
    private SpaceShip ship;

    public CalculateDesiredDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        ship.SetDesiredMoveDir(ship.targetDir * ship.maxSpeed);

        return NodeState.SUCCESS;
    }
}
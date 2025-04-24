using UnityEngine;
using BehaviourTree;

public class CheckIsTargetLocked : Node
{
    private SpaceShip ship;

    public CheckIsTargetLocked(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        if (ship.target != null) return NodeState.SUCCESS;
        else return NodeState.FAILURE;
    }

}
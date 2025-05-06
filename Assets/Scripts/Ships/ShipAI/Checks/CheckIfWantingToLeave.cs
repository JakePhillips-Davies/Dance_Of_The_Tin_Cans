using UnityEngine;
using BehaviourTrees;

public class CheckIfWantingToLeave : Node
{
    private SpaceShip ship;

    public CheckIfWantingToLeave(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        if (ship.shipEmotionChip.desireToLeave > 1.5f) return NodeState.SUCCESS;
        else return NodeState.FAILURE;
    }

}
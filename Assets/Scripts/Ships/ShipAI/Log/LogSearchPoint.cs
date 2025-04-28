using BehaviourTree;
using UnityEngine;

public class LogSearchPoint : Node
{
    private SpaceShip ship;

    public LogSearchPoint(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        if (((ship.searchPoint - ship.transform.position).magnitude <= 100) || ((ship.searchPoint - ship.transform.position).magnitude >= ship.searchRange * 4))
            ship.SetSearchPoint(ship.transform.position + (2 * ship.searchRange * Random.onUnitSphere));

        return NodeState.SUCCESS;
    }
}
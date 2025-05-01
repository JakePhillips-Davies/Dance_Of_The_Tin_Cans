using BehaviourTree;
using UnityEngine;

public class LogSearchPoint : Node
{
    private SpaceShip ship;

    public LogSearchPoint(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        if (((ship.searchPoint - ship.transform.position).magnitude <= 100) || ((ship.searchPoint - ship.transform.position).magnitude >= ship.searchRange * 1.5f)) {
            Vector3 searchPoint = ship.transform.position + (1.25f * ship.searchRange * Random.onUnitSphere);

            if (searchPoint.magnitude > 19000) searchPoint = ship.transform.position - ship.transform.position.normalized * ship.searchRange; // if outside a certain distance from 0, move back inwards

            ship.SetSearchPoint(searchPoint);
        }

        return NodeState.SUCCESS;
    }
}
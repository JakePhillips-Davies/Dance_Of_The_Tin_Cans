using BehaviourTrees;
using UnityEngine;

public class LogSearchPoint : Node
{
    private SpaceShip ship;

    public LogSearchPoint(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        if (((ship.searchPoint - ship.transform.position).magnitude <= 100) || ((ship.searchPoint - ship.transform.position).magnitude >= ship.searchRange * 1.5f) || (ship.searchPoint == Vector3.zero)) {
            
            Vector3 searchPoint = Vector3.zero;
            bool checking = true;
            int itt = 0;
            while (checking) {
                searchPoint = ship.transform.position + (1.25f * ship.searchRange * Random.onUnitSphere);

                if ((Random.Range(0f, 4f) <= Mathf.Pow(Vector3.Dot(ship.rb.linearVelocity, searchPoint - ship.transform.position) + 1, 2)) || (itt == 100)) {
                    checking = false;
                }
                else itt++;

                if (itt > 100) return NodeState.FAILURE;
            }            

            if (searchPoint.magnitude > 19000) searchPoint = ship.transform.position - ship.transform.position.normalized * ship.searchRange; // if outside a certain distance from 0, move back inwards

            
            ship.SetSearchPoint(searchPoint);
        }

        return NodeState.SUCCESS;
    }
}
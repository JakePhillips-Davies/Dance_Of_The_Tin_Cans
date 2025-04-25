using BehaviourTree;
using UnityEngine;

public class LogAvoidObstacleDir : Node
{
    private SpaceShip ship;

    public LogAvoidObstacleDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            Vector3 avoidObstacleDir = Vector3.zero;
            Collider[] surroundingColliders = Physics.OverlapSphere(ship.transform.position, ship.avoidObstacleRange);

            Vector3 directionToCollider;
            float distanceToCollider;
            foreach (Collider collider in surroundingColliders) {
                if (collider.attachedRigidbody != ship.rb) {
                    directionToCollider = (collider.ClosestPoint(ship.transform.position) - ship.transform.position).normalized;
                    distanceToCollider = Vector3.Distance(ship.transform.position, collider.ClosestPoint(ship.transform.position));

                    avoidObstacleDir += -directionToCollider * (1f / distanceToCollider);

                    if (ship.closestObstacleDist > distanceToCollider || ship.closestObstacleDist == -1) ship.SetClosestObstacleDist(distanceToCollider);
                }
            }            

            ship.SetAvoidObstacleDir(avoidObstacleDir.normalized);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
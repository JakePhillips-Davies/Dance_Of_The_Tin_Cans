using System;
using BehaviourTree;
using UnityEngine;

public class LogFleeDir : Node
{
    private SpaceShip ship;
    private LayerMask mask;

    public LogFleeDir(SpaceShip _ship, String maskName) {
        this.ship = _ship;
        this.mask = LayerMask.GetMask(maskName);
    }

    public override NodeState Evaluate() {
        try {
            Vector3 fleeDir = Vector3.zero;
            Collider[] shipColliders = Physics.OverlapSphere(ship.transform.position, ship.scannerRange, mask);
            if (shipColliders.Length <= 0) return NodeState.FAILURE;

            Vector3 directionToCollider;
            float distanceToCollider;
            foreach (Collider collider in shipColliders) {
                if (collider.attachedRigidbody != ship.rb) {
                    directionToCollider = (collider.transform.position - ship.transform.position).normalized;
                    distanceToCollider = Vector3.Distance(ship.transform.position, collider.transform.position);

                    fleeDir += -directionToCollider * (100f / distanceToCollider);

                    if (ship.closestHostileDist > distanceToCollider || ship.closestHostileDist == -1) ship.SetClosestHostileDist(distanceToCollider);
                }
            }            

            ship.SetFleeDir(fleeDir.normalized);
    
            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
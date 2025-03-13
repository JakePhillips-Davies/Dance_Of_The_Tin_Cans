using BehaviourTree;
using UnityEngine;

public class MoveUpToTarget : Node
{
    private SpaceShip ship;

    public MoveUpToTarget(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        Transform target = ship.target;
        Vector3 steeringDir;
        Rigidbody rb = ship.rb;

        if (target != null) {
            Vector3 desiredDir = target.transform.position - ship.transform.position;
        
            ship.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(ship.transform.forward, desiredDir, 0.02f, 0.0f)); // rotate towards target

            float distance = desiredDir.magnitude;
            if (distance < ship.slowRange) {

                float d = (distance - ship.stopRange) / (ship.slowRange - ship.stopRange); // get how far the ship is between slowRange and stopRange [1.0 - 0.0]

                desiredDir = desiredDir.normalized * (ship.maxSpeed * d);

            }
            else {

                desiredDir = desiredDir.normalized * ship.maxSpeed;

            }

            steeringDir = desiredDir - rb.linearVelocity;
            steeringDir = Vector3.ClampMagnitude(steeringDir, ship.engineForceMax);

            rb.AddForce(steeringDir, ForceMode.Impulse);
        }

        return NodeState.RUNNING;
    }
}
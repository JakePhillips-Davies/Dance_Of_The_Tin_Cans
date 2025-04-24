using BehaviourTree;
using UnityEngine;

public class ApplyThrust : Node
{
    private SpaceShip ship;

    public ApplyThrust(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        Vector3 steeringDir;
        Rigidbody rb = ship.rb;

        steeringDir = ship.desiredMoveDir - rb.linearVelocity;
        steeringDir = Vector3.ClampMagnitude(steeringDir, ship.engineForceMax);

        rb.AddForce(steeringDir, ForceMode.Impulse);

        return NodeState.RUNNING;
    }
}

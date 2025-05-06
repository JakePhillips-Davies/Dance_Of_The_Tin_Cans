using BehaviourTrees;
using UnityEngine;

public class AttemptToLeave : Node
{
    private SpaceShip ship;

    public AttemptToLeave(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            if (ship.transform.position.magnitude > 20000) ship.Leave();
    
            return NodeState.FAILURE;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
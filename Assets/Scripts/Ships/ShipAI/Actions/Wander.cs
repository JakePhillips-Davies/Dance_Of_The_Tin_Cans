using BehaviourTree;
using UnityEngine;

public class Wander : Node
{
    private SpaceShip ship;

    public Wander(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        
        Debug.Log("wandering");

        return NodeState.RUNNING;
    }
}
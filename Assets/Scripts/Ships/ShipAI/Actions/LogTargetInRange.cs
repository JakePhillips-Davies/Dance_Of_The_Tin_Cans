using UnityEngine;
using BehaviourTree;
using System;

public class LogTargetInRange : Node
{
    private SpaceShip ship;
    private LayerMask mask;


    public LogTargetInRange(SpaceShip _ship, string _mask) {
        this.ship = _ship;
        this.mask = LayerMask.GetMask(_mask);
    }

    public override NodeState Evaluate() {
        try {
            Collider[] targetsInRange = Physics.OverlapSphere(ship.transform.position, ship.searchRange, mask);
            if (targetsInRange.Length == 0) return NodeState.FAILURE;
    
            int randomIndex = UnityEngine.Random.Range(0, targetsInRange.Length);
            ship.SetTarget(targetsInRange[randomIndex].transform);

            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    
    }

}
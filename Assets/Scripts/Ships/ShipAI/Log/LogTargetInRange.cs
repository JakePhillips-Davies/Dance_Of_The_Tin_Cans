using UnityEngine;
using BehaviourTree;

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

            bool checking = true;
            int itt = 0;
            while (checking) {
                int randomIndex = Random.Range(0, targetsInRange.Length);

                if ((Random.Range(-1, 1) <= Vector3.Dot(ship.rb.linearVelocity, targetsInRange[randomIndex].transform.position - ship.transform.position)) || (itt == 100)) {
                    ship.SetTarget(targetsInRange[randomIndex].transform);
                    checking = false;
                }
                else itt++;

                if (itt > 100) return NodeState.FAILURE;
            }

            ship.shipEmotionChip.ResetTimer();

            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    
    }

}
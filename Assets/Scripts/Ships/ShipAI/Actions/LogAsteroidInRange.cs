using UnityEngine;
using BehaviourTree;

public class LogAsteroidInRange : Node
{
    private SpaceShip ship;

    public LogAsteroidInRange(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            Collider[] asteroidsInRange = Physics.OverlapSphere(ship.transform.position, ship.searchRange, LayerMask.NameToLayer("Asteroid"));
            if (asteroidsInRange.Length == 0) return NodeState.FAILURE;
    
            int randomCheck = Random.Range(0, asteroidsInRange.Length - 1);
            if (asteroidsInRange[randomCheck].TryGetComponent<Asteroid>(out Asteroid randomAsteroid))
                ship.SetTarget(randomAsteroid.transform);
            else return NodeState.FAILURE;

            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    
    }

}
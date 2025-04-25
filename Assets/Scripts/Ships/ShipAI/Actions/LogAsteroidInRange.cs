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
            Collider[] asteroidsInRange = Physics.OverlapSphere(ship.transform.position, ship.searchRange, LayerMask.GetMask("Asteroid"));
            if (asteroidsInRange.Length == 0) return NodeState.FAILURE;
    
            int randomIndex = Random.Range(0, asteroidsInRange.Length);
            if (asteroidsInRange[randomIndex].TryGetComponent<Asteroid>(out Asteroid randomAsteroid))
                ship.SetTarget(randomAsteroid.transform);

            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    
    }

}
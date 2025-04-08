using UnityEngine;
using BehaviourTree;

public class CheckForAsteroidInRange : Node
{
    private SpaceShip ship;

    public CheckForAsteroidInRange(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            if (ship.target != null) return NodeState.SUCCESS;

            Collider[] asteroidsInRange = Physics.OverlapSphere(ship.transform.position, ship.searchRange, LayerMask.NameToLayer("Asteroid"));
    
            int randomCheck = Random.Range(0, asteroidsInRange.Length - 1);

            if (asteroidsInRange[randomCheck].TryGetComponent<Asteroid>(out Asteroid randomAsteroid))
                ship.SetTarget(randomAsteroid.transform);
            else return NodeState.FAILURE; // Do something better here

            return NodeState.SUCCESS;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    
    }

}
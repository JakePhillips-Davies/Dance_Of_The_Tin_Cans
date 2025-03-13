using UnityEngine;
using BehaviourTree;

public class CheckForAsteroidInRange : Node
{
    private SpaceShip ship;

    public CheckForAsteroidInRange(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        
        if (ship.target == null){ //!!!!!!!! TEMP !!!!!!!!!!!!!
            foreach (Asteroid asteroid in Object.FindObjectsByType<Asteroid>(FindObjectsSortMode.None)){
                if (Random.Range(0, 30) == 2){
                    ship.SetTarget(asteroid.transform);
                    return NodeState.SUCCESS;
                }
            }
        }
        else return NodeState.SUCCESS;

        return NodeState.FAILURE;
    
    }

}
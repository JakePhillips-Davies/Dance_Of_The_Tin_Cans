using BehaviourTrees;

public class CheckTargetInWeaponRange : Node
{
    private SpaceShip ship;

    public CheckTargetInWeaponRange(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        
        if (ship.target == null) {
            return NodeState.FAILURE;
        }

        float distance = (ship.target.position - ship.transform.position).magnitude; 

        if (distance <= ship.gun.range) {
            return NodeState.SUCCESS;
        }
        else {
            return NodeState.FAILURE;
        }
    
    }

}
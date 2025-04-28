using BehaviourTree;

public class AttackTarget : Node
{
    private SpaceShip ship;

    public AttackTarget(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        
        if (ship.target == null) {
            return NodeState.FAILURE;
        }

        return ship.gun.Shoot(ship.target.transform.position - ship.gun.transform.position) ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
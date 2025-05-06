using BehaviourTrees;

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

        if (ship.gun.Shoot(ship.target.transform.position - ship.gun.transform.position)) {
            SetTopData("boredomTimer", 0);
            return NodeState.SUCCESS;
        }
        else return NodeState.FAILURE;
    }
}
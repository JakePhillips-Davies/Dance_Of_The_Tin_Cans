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

        if (ship.target.TryGetComponent<Health>(out Health targetHealth)) {
            targetHealth.Damage(ship.weaponDamage);
        }
        else {
            return NodeState.FAILURE;
        }

        return NodeState.SUCCESS;
    }
}
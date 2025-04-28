using BehaviourTree;
using UnityEngine;

public class Timer : Node
{
    private SpaceShip ship;

    public Timer(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        try {
            ship.shipEmotionChip.IncramentTimer(Time.fixedDeltaTime);

            if (ship.shipEmotionChip.timer >= ship.shipEmotionChip.timeoutTime)
                return NodeState.SUCCESS;
            
            else 
                return NodeState.FAILURE;
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
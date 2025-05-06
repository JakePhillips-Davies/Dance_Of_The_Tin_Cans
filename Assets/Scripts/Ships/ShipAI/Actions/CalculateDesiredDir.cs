using BehaviourTrees;
using UnityEngine;

public class CalculateDesiredDir : Node
{
    private SpaceShip ship;

    public CalculateDesiredDir(SpaceShip _ship) {
        this.ship = _ship;
    }

    public override NodeState Evaluate() {
        ship.shipEmotionChip.CalculateEmotion();
        
        Vector3 desiredDir = Vector3.zero;

        desiredDir += ship.targetDir * ship.shipEmotionChip.greed/3;

        desiredDir += ship.fleeDir * Mathf.Max(0f, 1 - (ship.closestHostileDist/ship.searchRange)) * (
            3*ship.shipEmotionChip.fear +
            ship.shipEmotionChip.caution
        );

        desiredDir += ship.avoidObstacleDir * Mathf.Max(0f, 1 - (ship.closestObstacleDist/ship.avoidObstacleRange)) * (
            ship.shipEmotionChip.fear +
            3*ship.shipEmotionChip.caution
        );

        ship.SetDesiredMoveDir(desiredDir.normalized * ship.maxSpeed);

        return NodeState.SUCCESS;
    }
}
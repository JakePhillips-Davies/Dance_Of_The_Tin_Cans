using BehaviourTree;
using UnityEngine;

/// <summary>
/// Will pass a success after a certain amount of time has passed
/// </summary>
public class Timer : Node
{
    private float holdTime;
    private float currTime;
    private float lastPingTime;

    public Timer(float holdTime) { 
        this.holdTime = holdTime;
        this.currTime = 0;

        this.lastPingTime = Time.time;
    }

    public override NodeState Evaluate() {
        try {
            currTime += Time.time - lastPingTime;
            lastPingTime = Time.time;

            if (currTime >= holdTime) {
                currTime = 0;
                return NodeState.SUCCESS;
            }
            else {
                return NodeState.FAILURE;
            }
        }
        catch (System.Exception) {
            return NodeState.FAILURE;
        }
    }
}
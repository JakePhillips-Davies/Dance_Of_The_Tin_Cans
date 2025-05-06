using BehaviourTrees;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Will pass a success after a certain amount of time has passed
/// </summary>
public class Timer : Node
{
    private float holdTime;
    private float lastPingTime;
    private string key;

    public Timer(float holdTime, string _key) { 
        this.holdTime = holdTime;
        this.key = _key;

        this.lastPingTime = Time.time;

    }

    public override NodeState Evaluate() {
        try {
            float timer = (GetData(key) == null) ? 0f : GetData(key).ConvertTo<float>();
            timer += Time.time - lastPingTime;
            lastPingTime = Time.time;

            SetTopData(key, timer);

            if (GetData(key).ConvertTo<float>() >= holdTime) {
                SetTopData(key, 0);
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
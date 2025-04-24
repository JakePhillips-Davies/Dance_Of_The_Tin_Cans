using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Health))]
public class SpaceShip : MonoBehaviour
{
    //
    [field: SerializeField] public float engineForceMax { get; private set; }
    [field: SerializeField] public float maxSpeed { get; private set; }
    [field: SerializeField] public float weaponRange { get; private set; }
    [field: SerializeField] public float weaponDamage { get; private set; }
    [field: SerializeField] public float targetRange { get; private set; }
    [field: SerializeField] public float searchRange { get; private set; }
    [field: SerializeField] public Vector3 searchPoint { get; private set; }
    [field: SerializeField] public Vector3 desiredMoveDir { get; private set; }
    [field: SerializeField] public Vector3 targetDir { get; private set; }
    [field: SerializeField] public Vector3 avoidObstacleDir { get; private set; }
    [field: SerializeField] public Vector3 fleeDir { get; private set; }

    public Rigidbody rb { get; private set; }
    public Health health { get; private set; }

    public Transform target { get; private set; } = null;

    private Color gizmoColour;
    //

    private void Start() {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();

        gizmoColour = Random.ColorHSV();
    }

    private void OnDrawGizmos() {
        Gizmos.color = gizmoColour;

        if (target != null) Gizmos.DrawLine(transform.position, target.transform.position);
    }

    public void SetTarget(Transform _target) {
        target = _target;
    }

    public void SetSearchPoint(Vector3 _searchPoint) {
        searchPoint = _searchPoint;
    }

    public void SetDesiredMoveDir(Vector3 _desiredMoveDir) {
        desiredMoveDir = _desiredMoveDir;
    }
    public void SetTargetDir(Vector3 _targetDir) {
        targetDir = _targetDir;
    }
    public void SetAvoidObstacleDir(Vector3 _avoidObstacleDir) {
        avoidObstacleDir = _avoidObstacleDir;
    }
    public void SetFleeDir(Vector3 _fleeDir) {
        fleeDir = _fleeDir;
    }

}

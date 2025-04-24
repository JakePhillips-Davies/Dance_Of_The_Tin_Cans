using UnityEngine;
using EditorAttributes;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Health))]
public class SpaceShip : MonoBehaviour
{
//--#
    #region Variables


    [field: Title("Variables")]
    [field: SerializeField] public float engineForceMax { get; private set; }
    [field: SerializeField] public float maxSpeed { get; private set; }
    [field: SerializeField] public float weaponRange { get; private set; }
    [field: SerializeField] public float weaponDamage { get; private set; }
    [field: SerializeField] public float targetRange { get; private set; }
    [field: SerializeField] public float searchRange { get; private set; }

    [field: Space(10)]
    [field: Title("Logged points/directions")]
    [FoldoutGroup("", nameof(searchPoint), nameof(desiredMoveDir), nameof(targetDir), nameof(avoidObstacleDir), nameof(fleeDir))]
    [SerializeField] private Void loggedInfoHolder;
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 searchPoint { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 desiredMoveDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 targetDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 avoidObstacleDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 fleeDir { get; private set; }

    [field: Space(10)]
    [field: Title("Debug settings")]
    [FoldoutGroup("", nameof(drawDesiredMoveDir), nameof(drawTargetDir), nameof(drawAvoidObstacleDir), nameof(drawFleeDir))]
    [SerializeField] private Void debugHolder;
    [field: SerializeField, HideProperty] public bool drawDesiredMoveDir { get; private set; }
    [field: SerializeField, HideProperty] public bool drawTargetDir { get; private set; }
    [field: SerializeField, HideProperty] public bool drawAvoidObstacleDir { get; private set; }
    [field: SerializeField, HideProperty] public bool drawFleeDir { get; private set; }

    public Rigidbody rb { get; private set; }
    public Health health { get; private set; }

    public Transform target { get; private set; } = null;


    #endregion
//--#

//--#
    #region Unity Methods


    private void Start() {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
    }

    private void OnDrawGizmos() {
        if (drawDesiredMoveDir) {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, desiredMoveDir);
        }
        if (drawTargetDir) {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, targetDir * 40);
        }
        if (drawAvoidObstacleDir) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, avoidObstacleDir * 40);
        }
        if (drawFleeDir) {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, fleeDir * 40);
        }
    }


    #endregion
//--#

//--#
    #region Setters


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


    #endregion
//--#
}

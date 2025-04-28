using UnityEngine;
using EditorAttributes;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Health), typeof(ShipEmotionChip))]
public class SpaceShip : MonoBehaviour
{
//--#
    #region Variables


    [field: Title("Variables")]
    [field: SerializeField] public float engineForceMax { get; private set; }
    [field: SerializeField] public float maxSpeed { get; private set; }
    [field: SerializeField] public float scannerRange { get; private set; }
    [field: SerializeField] public float searchRange { get; private set; }
    [field: SerializeField] public float avoidObstacleRange { get; private set; }

    [field: Space(10)]
    [field: Title("Logged points/directions")]
    [FoldoutGroup("", nameof(searchPoint), nameof(desiredMoveDir), nameof(targetDir), nameof(avoidObstacleDir), nameof(fleeDir), nameof(closestObstacleDist), nameof(closestHostileDist), nameof(targetDist))]
    [SerializeField] private Void loggedInfoHolder;
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 searchPoint { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 desiredMoveDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 targetDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public float targetDist { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 avoidObstacleDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public float closestObstacleDist { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public Vector3 fleeDir { get; private set; }
    [field: SerializeField, ReadOnly, HideProperty] public float closestHostileDist { get; private set; }

    [field: Space(10)]
    [field: Title("Debug settings")]
    [FoldoutGroup("", nameof(drawDesiredMoveDir), nameof(drawTargetDir), nameof(drawScannerRange), nameof(drawAvoidObstacleDir), nameof(drawAvoidObstacleRange), nameof(drawFleeDir))]
    [SerializeField] private Void debugHolder;
    [field: SerializeField, HideProperty] public bool drawDesiredMoveDir { get; private set; }
    [field: SerializeField, HideProperty] public bool drawTargetDir { get; private set; }
    [field: SerializeField, HideProperty] public bool drawScannerRange { get; private set; }
    [field: SerializeField, HideProperty] public bool drawAvoidObstacleDir { get; private set; }
    [field: SerializeField, HideProperty] public bool drawAvoidObstacleRange { get; private set; }
    [field: SerializeField, HideProperty] public bool drawFleeDir { get; private set; }

    public Rigidbody rb { get; private set; }
    public Health health { get; private set; }
    public ShipEmotionChip shipEmotionChip { get; private set; }
    public ShipGun gun { get; private set; }

    public Transform target { get; private set; } = null;


    #endregion
//--#

//--#
    #region Unity Methods


    private void Start() {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        shipEmotionChip = GetComponent<ShipEmotionChip>();
        gun = GetComponent<ShipGun>();
    }

    private void OnDrawGizmos() {
        if (drawDesiredMoveDir) {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, desiredMoveDir * 40);
        }

        if (drawTargetDir) {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, targetDir * 40);
        }
        if (drawScannerRange) {
            Gizmos.DrawWireSphere(transform.position, scannerRange);
        }

        if (drawAvoidObstacleDir) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, avoidObstacleDir * 40);
        }
        if (drawAvoidObstacleRange) {
            Gizmos.DrawWireSphere(transform.position, avoidObstacleRange);
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
    public void SetTargetDist(float _targetDist) {
        targetDist = _targetDist;
    }

    public void SetAvoidObstacleDir(Vector3 _avoidObstacleDir) {
        avoidObstacleDir = _avoidObstacleDir;
    }
    public void SetClosestObstacleDist(float _closestObstacleDist) {
        closestObstacleDist = _closestObstacleDist;
    }

    public void SetFleeDir(Vector3 _fleeDir) {
        fleeDir = _fleeDir;
    }
    
    public void SetClosestHostileDist(float _closestHostileDist) {
        closestHostileDist = _closestHostileDist;
    }

    public void SetMaxSpeed(float _maxSpeed) {
        maxSpeed = _maxSpeed;
    }


    #endregion
//--#
}

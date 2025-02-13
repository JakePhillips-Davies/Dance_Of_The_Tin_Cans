using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShip : MonoBehaviour
{
    //
    private Vector3 steeringDir;
    [SerializeField] private float steeringForce;

    private Rigidbody rb;

    private Transform tempTarget = null;
    //

    private void Start() {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Random.onUnitSphere * 40000);

        steeringDir = transform.forward;
    }

    private void Update() {
        transform.LookAt(Vector3.Lerp(transform.position + transform.forward, transform.position + steeringDir, 0.25f)); // rotate towards velovity lerped
    }

    private void FixedUpdate() {
        if (tempTarget == null){ ///!!!!!!!! TEMP !!!!!!!!!!!!!
            foreach (Asteroid asteroid in FindObjectsByType<Asteroid>(FindObjectsSortMode.None)){
                if (Random.Range(0, 30) == 2){
                    tempTarget = asteroid.transform;
                }
            }
        }

        Vector3 desiredDir = tempTarget.position - transform.position;

        steeringDir = Vector3.Normalize(desiredDir - rb.linearVelocity);

        rb.AddForce(steeringDir * steeringForce);

    }
}

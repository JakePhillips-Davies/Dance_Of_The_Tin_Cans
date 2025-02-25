using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShip : MonoBehaviour
{
    //
    private Vector3 steeringDir;
    [SerializeField] private float engineForceMax;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float stopRange;
    [SerializeField] private float slowRange;
    [SerializeField] private float weaponRange;
    [SerializeField] private float weaponDamage;

    private Rigidbody rb;

    private Asteroid tempTarget = null;
    //

    private void Start() {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Random.onUnitSphere * 40000);

        steeringDir = transform.forward;
    }

    private void FixedUpdate() {
        if (tempTarget == null){ ///!!!!!!!! TEMP !!!!!!!!!!!!!
            foreach (Asteroid asteroid in FindObjectsByType<Asteroid>(FindObjectsSortMode.None)){
                if (Random.Range(0, 30) == 2){
                    tempTarget = asteroid;
                }
            }
        }


        Vector3 desiredDir = tempTarget.transform.position - transform.position;
        
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, desiredDir, 0.02f, 0.0f)); // rotate towards target

        float distance = desiredDir.magnitude;
        if (distance < slowRange) {

            float d = (distance - stopRange) / (slowRange - stopRange); // get how far the ship is between slowRange and stopRange [1.0 - 0.0]

            desiredDir = desiredDir.normalized * (maxSpeed * d);

        }
        else {

            desiredDir = desiredDir.normalized * maxSpeed;

        }

        steeringDir = desiredDir - rb.linearVelocity;
        steeringDir = Vector3.ClampMagnitude(steeringDir, engineForceMax);

        rb.AddForce(steeringDir, ForceMode.Impulse);


        if (distance < weaponRange)
        {
            tempTarget.Damage(weaponDamage);
        }

    }
}

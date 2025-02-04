using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    // 
    //Private material list
    
    private Rigidbody rb;
    [SerializeField] private Vector3 initialVelocity;
    [SerializeField] private Vector3 initialRotation;
    //

    private void Start() {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = initialVelocity;
        rb.angularVelocity = initialRotation;
    }
}

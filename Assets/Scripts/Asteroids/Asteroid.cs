using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    // 
    [SerializeField] private List<Ore> oreList;
    
    private Rigidbody rb;
    [SerializeField] private Vector3 initialVelocity; public void SetInitialVelocity(Vector3 velocity) {initialVelocity = velocity;}
    [SerializeField] private Vector3 initialAngularVelocity; public void SetInitialAngularVelocity(Vector3 aVelocity) {initialAngularVelocity = aVelocity;}
    //

    private void Start() {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = initialVelocity;
        rb.angularVelocity = initialAngularVelocity;
    }

    // private void FixedUpdate() {
    //     transform.Rotate(initialAngularVelocity);
    // }
}

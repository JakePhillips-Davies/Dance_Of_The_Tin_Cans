using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Health))]
public class Asteroid : MonoBehaviour
{
    // 
    [SerializeField] private List<Ore> oreList;
    
    private Rigidbody rb;
    [SerializeField] private Vector3 initialVelocity; public void SetInitialVelocity(Vector3 velocity) {initialVelocity = velocity;}
    [SerializeField] private Vector3 initialAngularVelocity; public void SetInitialAngularVelocity(Vector3 aVelocity) {initialAngularVelocity = aVelocity;}
    public Health health { get; private set; }
    //

    private void Start() {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();

        rb.linearVelocity = initialVelocity;
        rb.angularVelocity = initialAngularVelocity;
    }
}

using System;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float scrollSensitivity = 5f;
    [SerializeField] private float orbitRadius = 5f;
    [SerializeField] private KeyCode moveKey = KeyCode.Mouse1;
    [SerializeField] private FocusController focusController;

    private float yaw;
    private float pitch;

    private float camDistance;

    void Start() {
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void Update() {
        if (Input.GetKey(moveKey)) {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * sensitivity;
            pitch -= mouseY * sensitivity;
            pitch = Mathf.Clamp(pitch, -90, 90);

            transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        }

        camDistance = (transform.position- focusController.GetFocus().position).magnitude;

        orbitRadius -= Mathf.Clamp(camDistance, 0.05f, 100000) * Input.mouseScrollDelta.y * scrollSensitivity / 10;
        orbitRadius = Mathf.Clamp(orbitRadius, 0, 100000);

        transform.position = -transform.forward * orbitRadius + focusController.GetFocus().position;
    }

}

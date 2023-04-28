using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        horizontal,
        vertical,
        h_and_v
    }

    [SerializeField] private RotationAxes rotateAxe = RotationAxes.h_and_v;

    [SerializeField] private float horizontalSensitivity=9.0f;
    private float horizontalRotation;

    [SerializeField] float verticalSensitivity = 9.0f;
    private float verticalRotation;
    [SerializeField] private float verticalAngleMax = 45.0f;
    [SerializeField] private float verticalAngleMin = -45.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody!=null)
        {
            rigidbody.freezeRotation=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateAxe==RotationAxes.horizontal)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        }
        else if (rotateAxe==RotationAxes.vertical)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, verticalAngleMin, verticalAngleMax);
            transform.localEulerAngles = new Vector3(verticalRotation,transform.rotation.y);
        }
        else if(rotateAxe==RotationAxes.h_and_v)
        {
            horizontalRotation += Input.GetAxis("Mouse X") * horizontalSensitivity;

            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, verticalAngleMin, verticalAngleMax);
            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation);

        }
    }
}

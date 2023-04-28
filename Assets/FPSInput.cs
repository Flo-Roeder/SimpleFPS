using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float moveX, moveZ;
    private float gravity = -9.81f;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        moveZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement.y = gravity;
        movement*=Time.deltaTime;
        movement= transform.TransformDirection(movement);
        characterController.Move(movement);

    }
}

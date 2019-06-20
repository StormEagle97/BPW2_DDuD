using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float sprintSpeed;
    public Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController Gun;

    public InGameMenu menu;

    public bool shot = false;
    public bool sprinting = false;

    void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        Gun.canFire = true;
        Gun.canThrow = true;
        menu = FindObjectOfType<InGameMenu>();

    }
    void Update () {

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;

        if(Input.GetKey(KeyCode.LeftShift)) {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * sprintSpeed;
            Gun.canFire = false;
            sprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Gun.canFire = true;
            sprinting = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Gun.canThrow = false;
            sprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Gun.canThrow = true;
            sprinting = false;
        }

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (!menu.paused)
        {
            if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        }

        if (Input.GetMouseButtonDown(0)){
            Gun.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0)){
            Gun.isFiring = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Gun.isThrowing = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Gun.isThrowing = false;
        }
    }

    void FixedUpdate () {
        myRigidBody.velocity = moveVelocity;
    }
}

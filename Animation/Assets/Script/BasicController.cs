using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    public float transitionTime = 0.25f;
    private float speedLimit = 1.0f;
    public bool moveDiagonally = true;
    public bool mouseRotate = true;
    public bool keyboardRotate = false;

    public float jumpHeight = 3f;
    private float verticalSpeed = 0f;
    private float xVelocity = 0f;
    private float zVelocity = 0f;
    private bool collidedAbove = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
                verticalSpeed = jumpHeight;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("TurnLeft", true);
                transform.Rotate(Vector3.up * (Time.deltaTime * -45.0f), Space.World);
            }
            else
            {
                anim.SetBool("TurnLeft", false);
            }

            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("TurnRight", true);
                transform.Rotate(Vector3.up * (Time.deltaTime * 45.0f), Space.World);
            }
            else
            {
                anim.SetBool("TurnRight", false);
            }

            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                speedLimit = 0.5f;
            }
            else
            {
                speedLimit = 1.0f;
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float xSpeed = h * speedLimit;
            float zSpeed = v * speedLimit;
            float speed = Mathf.Sqrt(h * h + v * v);

            if (v != 0 && !moveDiagonally)
            {
                xSpeed = 0;
            }

            if (v != 0 && keyboardRotate)
            {
                this.transform.Rotate(Vector3.up * h, Space.World);
            }

            if (mouseRotate)
            {
                this.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X")) * Mathf.Sign(v), Space.World);
            }

            anim.SetFloat("zSpeed", zSpeed, transitionTime, Time.deltaTime);
            anim.SetFloat("xSpeed", xSpeed, transitionTime, Time.deltaTime);
            anim.SetFloat("Speed", speed, transitionTime, Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetBool("Grenade", true);
            }
            else
            {
                anim.SetBool("Grenade", false);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("Fire", true);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("Fire", false);
            }
        }
    }

    private void OnAnimatorMove()
    {
        Vector3 deltaPosition = anim.deltaPosition;
        if (controller.isGrounded)
        {
            xVelocity = controller.velocity.x;
            zVelocity = controller.velocity.z;
        }
        else
        {
            deltaPosition.x = xVelocity * Time.deltaTime;
            deltaPosition.z = zVelocity * Time.deltaTime;
            anim.SetBool("Jump", false);
        }
        deltaPosition.y = verticalSpeed * Time.deltaTime;
        controller.Move(deltaPosition);
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        if ((controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            verticalSpeed = 0;
            collidedAbove = false;
        }
        if((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            if (!collidedAbove)
            {
                verticalSpeed = 0;
            }

            collidedAbove = true;
        }
    }
}

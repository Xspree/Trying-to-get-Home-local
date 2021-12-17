using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float gravityScaler = 2.0f;

    private Player2Controller playerController;
    private Player2Controls playerControls;
    private Rigidbody playerRigibody;
    
    private float moveForce = 20;
    private float smoothRotation = 0.1f;

    private float currentPickUpRange;

    //Animation code
    public Animator player2DAnim;
    public GameObject held;
    public bool is2DGrounded;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    public SpriteRenderer playerSpriteRender;
    public float pickUpRange = 5;
    public Transform holdParent;
    public float sphereRadius = 10f;
    public LayerMask layerMask;


    float turnSmoothVelocity;

    void Awake()
    {
        playerRigibody = GetComponent<Rigidbody>();
        playerController = GetComponent<Player2Controller>();

        playerControls = new Player2Controls();
        playerControls.Land.Enable();
        
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        Vector2 inputVector = playerControls.Land.Move.ReadValue<Vector2>();
        

        

        RaycastHit hitGround;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hitGround, 1f, whatIsGround))
        {
            //Debug.Log("2D on ground");
            is2DGrounded = true;
            if(inputVector != Vector2.zero)
            {
                float targetAngle = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothRotation);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                playerRigibody.velocity = new Vector3(inputVector.x * speed, playerRigibody.velocity.y, inputVector.y * speed);

                if(inputVector.y == 1)
                {
                    //Debug.Log("isWalking true, isBackwards true");
                    player2DAnim.SetBool("isWalking", true);
                    player2DAnim.SetBool("isBackwards", true);
                }
                else
                {
                    //Debug.Log("isWalking true, isBackwards false");
                    player2DAnim.SetBool("isWalking", true);
                    player2DAnim.SetBool("isBackwards", false);
                }
                //Debug.Log(inputVector.y);
                
            }
            else
            {
                player2DAnim.SetBool("isWalking", false);
            }
            
            
        }
        else
        {
            //Debug.Log("2D not on ground");
            is2DGrounded = false;
            playerRigibody.AddForce(Vector3.down * gravityScaler);
        }

        if(playerControls.Land.Interaction.triggered && held == null)
        {
            //Debug.Log("2D Trying to pick up or move something");
            RaycastHit hitObj;
            if (Physics.SphereCast(transform.position, sphereRadius,transform.TransformDirection(Vector3.forward), out hitObj, pickUpRange, layerMask))
            {
                PickupObject(hitObj.transform.gameObject);
                currentPickUpRange = hitObj.distance;
            }
            
        }
        else if(playerControls.Land.Interaction.triggered && held != null)
        {
            DropObject();
        }
        if(held != null)
        {
            MoveObject();
        }

        

        if (playerSpriteRender.flipX && inputVector.x < 0)
        {
            playerSpriteRender.flipX = false;
        } else if(!playerSpriteRender.flipX && inputVector.x > 0)
        {
            
            playerSpriteRender.flipX = true;
        }
    }

    private void MoveObject()
    {
        if(Vector3.Distance(held.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - held.transform.position);
            held.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    private void PickupObject(GameObject pickObj)
    {
        
        if(pickObj.GetComponent<Rigidbody>())
        {
            
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            
            objRig.freezeRotation = true;
            objRig.transform.parent = holdParent;
            
            held = pickObj;
        }
    }

    public void DropObject()
    {
        Rigidbody heldRig = held.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;
        heldRig.freezeRotation = false;

        held.transform.parent = null;
        held = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Debug.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * currentPickUpRange);
        Gizmos.DrawWireSphere(transform.position + transform.TransformDirection(Vector3.forward) * currentPickUpRange, sphereRadius);
    }

}

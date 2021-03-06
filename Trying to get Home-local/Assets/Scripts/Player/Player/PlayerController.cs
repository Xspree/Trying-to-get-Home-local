using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private readonly float rigDrag = 6.0f;

    [SerializeField]
    private float gravityScaler = -25.0f;

    

    private PlayerController playerController;
    private PlayerControls playerControls;
    private Rigidbody playerRigibody;
    
    private float moveForce = 60;
    private float smoothRotation = 0.1f;

    private float currentPickUpRange;


    public GameObject held;
    public bool is3DGrounded;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    public float pickUpRange = 5;
    public Transform holdParent;
    public Animator player3DAnim;
    public float sphereRadius = 10f;
    public LayerMask layerMask;


    float turnSmoothVelocity;

    void Awake()
    {
        playerRigibody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        
        playerControls = new PlayerControls();
        playerControls.Land.Enable();
        
    }

    
    // Update is called once per frame

    private void Update()
    {
        ControlDrag();

        

    }
    private void MoveObject()
    {
        if (Vector3.Distance(held.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - held.transform.position);
            held.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    private void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.freezeRotation = true;
            objRig.useGravity = false;
            objRig.drag = 10;

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

    private void ControlDrag()
    {
        playerRigibody.drag = rigDrag;
    }


    private void FixedUpdate()
    {
        Vector2 inputVector = playerControls.Land.Move.ReadValue<Vector2>();
        if(!is3DGrounded)
        {
            //Debug.Log("Falling");
            player3DAnim.SetBool("isWalking", false);
            //player would be falling so set their animation to falling but we don't have that 
            playerRigibody.AddForce(Vector3.down * gravityScaler * speed);
            playerRigibody.AddForce(new Vector3(inputVector.x  *gravityScaler, 0, inputVector.y * gravityScaler) * speed);
        }
        else
        {
            
            if(inputVector != Vector2.zero)
            {
                float targetAngle = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothRotation);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                playerRigibody.AddForce(new Vector3(inputVector.x, 0, inputVector.y).normalized * speed, ForceMode.Force);
                //Debug.Log("Walking");
                player3DAnim.SetBool("isWalking", true);
            }
            else
            {
                //Debug.Log("Idle");
                player3DAnim.SetBool("isWalking", false);
            }
            
            
        }

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, 1.15f, whatIsGround))
        {
            //Debug.Log("3D on ground");
            is3DGrounded = true;
        }
        else
        {
            //Debug.Log("3D not on ground");
            is3DGrounded = false;

        }
        if (playerControls.Land.Interaction.triggered && held == null)
        {

            RaycastHit hitObj;
            
            if (Physics.SphereCast(transform.position, sphereRadius,transform.TransformDirection(Vector3.forward), out hitObj, pickUpRange, layerMask))
            {
                currentPickUpRange = hitObj.distance;
                PickupObject(hitObj.transform.gameObject);
            }
            else
            {
                currentPickUpRange = pickUpRange;
            }
        }
        else if (playerControls.Land.Interaction.triggered && held != null)
        {
            DropObject();
        }

        if (held != null)
        {
            MoveObject();
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
        Debug.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * currentPickUpRange);
        Gizmos.DrawWireSphere(transform.position + transform.TransformDirection(Vector3.forward) * currentPickUpRange, sphereRadius);
    }
}

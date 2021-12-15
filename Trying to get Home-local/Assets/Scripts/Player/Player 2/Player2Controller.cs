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
    
    private GameObject held;
    private float moveForce = 50;

    //Animation code
    public Animator player2DAnim;

    public bool is2DGrounded;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    public SpriteRenderer playerSpriteRender;
    public int pickUpRange = 10;
    public Transform holdParent;

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
                playerRigibody.velocity = new Vector3(inputVector.x * speed, playerRigibody.velocity.y, inputVector.y * speed);
                player2DAnim.SetBool("isWalking", true);
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
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitObj, pickUpRange))
            {
                PickupObject(hitObj.transform.gameObject);
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
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            held = pickObj;
        }
    }

    private void DropObject()
    {
        Rigidbody heldRig = held.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        held.transform.parent = null;
        held = null;
    }

}

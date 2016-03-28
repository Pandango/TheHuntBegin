using UnityEngine;
using System.Collections;

public class TestAnimal : MonoBehaviour {

    private CharacterController characterController;
    private Animator anim;
    public bool isGrounded;
    public bool isStun = false;
    bool facingRight = true;
    [SerializeField]
    bool isEnter = false;

    public  float gravity = 15.5f;
    private float fallSpeed;
    public float jumpSpeed = 7;
    public float moveSpeed = 7;
    private float speedx;
    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        characterController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        groundCheck();
        Fall();
        Jump();
        Move();
        stunned();
        EnterInCave();
    }

    void FixedUpdate()
    {
        if (speedx > 0 && !facingRight)
        {
            Flip();

        }
        else if (speedx < 0 && facingRight)
        {
            Flip();
        }
    }

    void groundCheck()
    {
        //using raycast need start position/direction/magnitude,lenght
        isGrounded = (Physics.Raycast(transform.position, -transform.up, characterController.height/0.9f));
        anim.SetBool("Grounded", isGrounded);
    }

    void Move()
    {
        speedx = Input.GetAxis("Horizontal");
        if (speedx != 0)
        {
            characterController.Move(new Vector3(speedx, 0) * moveSpeed * Time.deltaTime);
            anim.SetFloat("Speed", Mathf.Abs(speedx));
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            fallSpeed = -jumpSpeed;
        }
    }

    void Fall()
    {
        if (!isGrounded)
        {
            fallSpeed += gravity * Time.deltaTime;
        }
        else
        {
            if (fallSpeed > 0) fallSpeed = 0;
        }
        characterController.Move(new Vector3(0, -fallSpeed * Time.deltaTime));
    }

    void Flip()
    {
        if (isGrounded)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }

    void stunned()
    {
        if (isStun == true)
        {
            characterController.enabled = false;
        }
        else if(isStun == false)
        {
            characterController.enabled = true;
        }
    }

    void EnterInCave()
    {
        GameObject cave2Pos = GameObject.Find("Cave2");
        if (Input.GetKeyDown(KeyCode.LeftControl) && isEnter)
        {
            this.transform.position = cave2Pos.transform.position;
        }


    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "Cave")
        {
            isEnter = true;
        }
        Debug.Log(hitInfo);
        Debug.Log(this.transform.position);
    }



    void OnTriggerExit(Collider hitInfo)
    {
        if (hitInfo.tag == "Cave")
        {
            isEnter = false;
        }
       
       
    }
}

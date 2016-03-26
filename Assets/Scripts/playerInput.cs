using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {

    private CharacterController characterContoller;
    public bool isGrounded;

    [SerializeField]
    bool isEnter = false;

    public float gravity = 15.5f;
    private float fallSpeed;
    public float jumpSpeed = 5;
    public float moveSpeed = 5;
    private float speedx;
    // Use this for initialization
    void Start () {
        characterContoller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {


        groundCheck();
        Fall();
        Jump();
        Move();
        EnterInCave();
	}

    void groundCheck()
    {
        //using raycast need start position/direction/magnitude,lenght
        isGrounded = (Physics.Raycast(transform.position, -transform.up, characterContoller.height / 2.8f));
    }

    void Move()
    {
        speedx = Input.GetAxis("Horizontal");
        if(speedx != 0)
        {
            characterContoller.Move(new Vector3(speedx, 0) * moveSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
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
        characterContoller.Move(new Vector3(0, -fallSpeed*Time.deltaTime));
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
        if(hitInfo.tag == "Cave" ){
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

using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {

    private CharacterController characterContoller;
    SpriteRenderer playerRenderer;
    public bool isGrounded;

    public float gravity = 15.5f;
    private float fallSpeed;
    public float jumpSpeed = 5;
    public float moveSpeed = 5;
    private float speedx;

    [SerializeField]
    bool isEnter = false;
    [SerializeField]
    bool isEnterBush = false;
    bool isGetInBush = false;
    string caveName;



    // Use this for initialization
    void Start () {
        characterContoller = GetComponent<CharacterController>();
        playerRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        groundCheck();
        Fall();
        Jump();
        Move();
        EnterInCave();
        EnterInBush();
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
        if (!isGrounded){
            fallSpeed += gravity * Time.deltaTime;
        }
        else{
            if (fallSpeed > 0) fallSpeed = 0;
        }
        characterContoller.Move(new Vector3(0, -fallSpeed*Time.deltaTime));
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if(hitInfo.tag == "Cave" ){
            isEnter = true;
            caveName = hitInfo.name;
        }
        else if (hitInfo.tag == "Bush"){
            isEnterBush = true;
        }
    }

    void OnTriggerExit(Collider hitInfo)
    {
        if (hitInfo.tag == "Cave")
        {
            isEnter = false;
            caveName = "";
        }
        else if(hitInfo.tag == "Bush"){
            isEnterBush = false;
        }
    }

    void EnterInCave()
    {
        GameObject cave2Pos = GameObject.Find("Cave2");
        GameObject cave1Pos = GameObject.Find("Cave1");
        if (Input.GetKeyDown(KeyCode.LeftControl) && isEnter && caveName == "Cave1")
        {
            this.transform.position = cave2Pos.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && isEnter && caveName == "Cave2")
        {
            this.transform.position = cave1Pos.transform.position;
        }
    }

    void EnterInBush()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isEnterBush && !isGetInBush)
        {
            playerRenderer.sortingLayerName = "playerHide";
            playerRenderer.enabled = false;
            characterContoller.enabled = false;
            isGetInBush = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && isEnterBush && isGetInBush)
        {
            playerRenderer.sortingLayerName = "player";
            playerRenderer.enabled = true;
            characterContoller.enabled = true;
            isGetInBush = false;
        }

    }
}

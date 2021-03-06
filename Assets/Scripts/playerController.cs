﻿using UnityEngine;
using System.Collections;


public class playerController : MonoBehaviour {
    private float moveHorizontal;
    public int maxSpeed = 10;
    bool faceRight = true;

    [SerializeField]
    float jumpSpeed = 350f;
    float hitDistance = 1f;
 
    private Rigidbody localRigidbody;



    bool isGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, -Vector3.up, out hit,hitDistance);
    }

	void Start () {
        localRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {

        //เคลื่อนที่ ซ้ายขวา
        moveHorizontal = Input.GetAxis("Horizontal");
        localRigidbody.velocity = new Vector3(moveHorizontal * maxSpeed, localRigidbody.velocity.y);
        if (moveHorizontal > 0 && !faceRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && faceRight)
        {
            Flip();
        }

        Vector3 jumpPosition = new Vector3(0, jumpSpeed/2);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            localRigidbody.AddForce(jumpPosition);
        }
	}

    void Flip()
    {
            faceRight = !faceRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        
    }

}

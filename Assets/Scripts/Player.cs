using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPressed;
    private float horizontalInput;
    public Transform GroundCheckTransform = null;
    private Rigidbody rigidbodyComponent;
    private int superJump;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            jumpKeyPressed = true;
            
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }
        if (jumpKeyPressed)

        {
            float jumpPower = 5;
            if (superJump>0)
            {
                jumpPower *= 2;
                superJump--;
            }
            rigidbodyComponent.AddForce(Vector3.up*jumpPower,ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
            
        {
            Destroy(other.gameObject);
            superJump++;
            score++;
            Score.score += 100;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float waitTime = 4.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private float DeltaTime= 0.01f;


    public CharacterController controller;
    public Collision collision;
    public Rigidbody rb;
    public float speed = 6f;
    public bool cubeIsOnGround = true;
    public bool canDash=true;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){

        timer += DeltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal")*Time.deltaTime*speed;
        float vertical = Input.GetAxisRaw("Vertical")*Time.deltaTime*speed;
        transform.Translate(horizontal,0,vertical);
        

        if(Input.GetButtonDown("Jump") && cubeIsOnGround){
            Jump();
        }
        if(Input.GetButtonDown("Dash") && cubeIsOnGround && Input.GetButton("Vertical") && canDash ){
            Dash();
        }
        wait();
    }

    private void wait(){
        if (timer > waitTime){
            visualTime = timer;
            timer = timer - waitTime;
            cubeIsOnGround=true;
            canDash=true;
        }   
    }

    private void OnCollisionEnter(Collision collision){
                if(collision.gameObject.tag=="Ground" && timer>waitTime){
                cubeIsOnGround=true;
                canDash=true;
                }
    }

    private void Jump(){
        cubeIsOnGround=false;
        rb.AddForce(new Vector3(0,10,0),ForceMode.Impulse);
    }

    private void Dash(){ 
        cubeIsOnGround=false;
        canDash=false;
        rb.AddForce(new Vector3(0,4,25),ForceMode.Impulse);            
    }

}
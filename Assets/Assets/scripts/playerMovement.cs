using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{ 
    float horizontalMovement = 0f;
    float player_speed = 8f;
   
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal")*player_speed*Time.deltaTime;
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
        
        transform.position += new Vector3(horizontalMovement, 0 , 0);

        if(horizontalMovement > 0){
            spriterenderer.flipX = false;
            
        }
        else if(horizontalMovement < 0){
            spriterenderer.flipX = true;
        }

        if(Input.GetButtonDown("Jump")){
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 250);
            animator.SetBool("isJumping", true);
        }

        
    }

    public void OnCollisionEnter(Collision collision) {
            if(collision.gameObject.CompareTag("ground")){
                animator.SetBool("isJumping", false);
            }
        
        
        }
}

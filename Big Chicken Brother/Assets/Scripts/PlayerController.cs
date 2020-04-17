using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float state_Combat = 0;
    public float state_Sword = 0;
    private bool upped = false;

    public Rigidbody2D rg;
    Vector2 movement;
    public Animator animator;

    void Start()
    {
      rg = gameObject.GetComponent<Rigidbody2D>();
      animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("state_Combat", state_Combat);
        animator.SetFloat("state_Sword", state_Sword);
        animator.SetBool("upped",upped);

        if(Input.GetKeyDown ("c")){
          if(state_Combat == 1f){
            state_Combat = 0f;
          }else{state_Combat = 1f;}
        }
        if(Input.GetKeyDown ("1")){
          state_Sword = 0f;
        }
        if(Input.GetKeyDown ("2")){
          state_Sword = 1f;
        }
        if(Input.GetKeyDown ("a")){
          //Flip(1);
          //upped = false;
        }
        if(Input.GetKeyDown ("d")){
          //Flip(-1);
          //upped = false;
        }
        if(Input.GetKeyDown ("w")){
          //upped = true;
        }
        if(Input.GetKeyDown ("s")){
          //upped = false;
        }

        Debug.Log(Input.mousePosition);
        Debug.Log(rg.position);

        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x > rg.position.x){
          Flip(-1);
        }else{
          Flip(1);
        }

        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).y > rg.position.y){
          upped = true;
          animator.SetFloat("UpVal", 1);
        }else{
          upped = false;
          animator.SetFloat("UpVal", 0);
        }
    }

    void Flip(int fliprate)
      {
          Vector2 theScale = transform.localScale;
          theScale.x = fliprate;
          transform.localScale = theScale;
      }

    void FixedUpdate()
    {
        rg.MovePosition(rg.position + movement * speed * Time.fixedDeltaTime);
    }
}

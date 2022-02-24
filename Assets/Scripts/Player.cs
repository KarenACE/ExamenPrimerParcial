using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;
     [SerializeField]
     float jumpForce = 7.0f;
      Rigidbody2D rb2D;
      SpriteRenderer spr;
       Animator anim;

      void Start()
      {
           rb2D = GetComponent<Rigidbody2D>();
           spr = GetComponent<SpriteRenderer>();
           anim = GetComponent<Animator>();
      }


           void Update()
               { 
               transform.Translate(Vector2.right*AxisRaw.x * speed * Time.deltaTime);
        
               if(JumpButton)
               { 
                   rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
               }
               spr.flipX = FlipSprite;
               anim.SetFloat("AxisX", Mathf.Abs(Axis.x));
               }

Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
Vector2 AxisRaw => new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
bool JumpButton => Input.GetButtonDown("Jump");
bool FlipSprite => Axis.x > 0 ? false : Axis.x < 0 ? true: spr.flipX;
}

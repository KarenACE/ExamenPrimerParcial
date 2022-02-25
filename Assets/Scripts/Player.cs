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

    [SerializeField,Range (0.01f,10f)]
    float rayDistance = 2f;
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Vector3 rayOrigin;
    [SerializeField]
    Score score; 


    

      void Start()
      {
           rb2D = GetComponent<Rigidbody2D>();
           spr = GetComponent<SpriteRenderer>();
           anim = GetComponent<Animator>();
      }


           void Update()
               { 
               transform.Translate(Vector2.right * AxisRaw.x * speed * Time.deltaTime);
               if(JumpButton)
               { 
                   rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
                   anim.SetTrigger("jump"); 
                  
               }
               spr.flipX = FlipSprite;
               anim.SetFloat("AxisX",Mathf.Abs(Axis.x));
              
               
               }
               void LateUpdate()
                   {
anim.SetFloat("AxisX",Mathf.Abs(Axis.x));
anim.SetBool("ground",IsGrounding); 

                   }
               

Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
Vector2 AxisRaw => new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
bool JumpButton => Input.GetButtonDown("Jump");
bool FlipSprite => Axis.x > 0 ? false : Axis.x < 0 ? true: spr.flipX;
bool IsGrounding => Physics2D.Raycast(transform.position + rayOrigin,Vector3.down,rayDistance,groundLayer);

void OnTriggerEnter2D(Collider2D col)
 {
    if(col.CompareTag("egg"))
    {
       egg egg = col.GetComponent<egg>();
       score.AddPoints(egg.GetPoints);
       Destroy(col.gameObject);
   }

 } 

 void OnDrawGizmosSelected()
 {
     Gizmos.color = rayColor;
     Gizmos.DrawRay(transform.position + rayOrigin,Vector3.down * rayDistance);
 }
}

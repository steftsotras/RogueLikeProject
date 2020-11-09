using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[Header("Input settings:")]
    [Space]
    [Header("Character attributes:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;

    [Space]
    [Header("Character Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    

    private Animator animator;  
    private int hitRange = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
    }

    void ProcessInputs(){
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        if(Input.GetButtonDown("Fire1")){
            animator.SetTrigger ("playerChop");
            Attack();
        }
    }

    void Move(){
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Attack() {
     RaycastHit hit;
     Vector3 forward = transform.TransformDirection(Vector3.forward);
     Vector3 origin = transform.position;
 
     if(Physics.Raycast(origin, forward, out hit, hitRange))
     {
         if(hit.transform.gameObject.tag == "Enemy")
         {
             hit.transform.gameObject.SendMessage("TakeDamage", 30);
         }
     }
 }

}

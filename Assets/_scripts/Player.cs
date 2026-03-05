using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Threading;

public class Player : MonoBehaviour
{
    
    //[SerializeField] private float moveSpeed = 10f; // movement option 1
    [SerializeField] private float targetSpeed = 5f; // movement option 2
    [SerializeField] private float acceleration = 25f; // movement option 2
    [SerializeField] private float jumpForce = 7f;


    public float ProjectileSpeed = 10f;
    public Vector3 spawnpoint;
    public float cooldown = 2;
    public GameObject  Projectile;

    private Rigidbody2D rigidbody;
    
    private float moveInputX;
    private float moveInputY;

    float timer = .2f;

    
   

    private float xSpeed;
    private float ySpeed;

    public void OnMoveX(InputAction.CallbackContext context)
    {
        
        moveInputX = context.ReadValue<float>();
        if (moveInputX != 0 && xSpeed == 0 && ySpeed == 0 )
        {
            xSpeed = moveInputX * targetSpeed;
        }
        
    }

    public void OnMoveY(InputAction.CallbackContext context)
    {
      
        moveInputY = context.ReadValue<float>();
        if (moveInputY != 0 && ySpeed == 0 && xSpeed == 0)
        {
            ySpeed = moveInputY * targetSpeed;
        }
        
        
    }
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocityX = Mathf.MoveTowards(rigidbody.linearVelocityX, xSpeed, acceleration * Time.fixedDeltaTime);
        rigidbody.linearVelocityY = Mathf.MoveTowards(rigidbody.linearVelocityY, ySpeed, acceleration * Time.fixedDeltaTime);

        

        if(Mathf.Abs(rigidbody.linearVelocityX) <= .5f)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                xSpeed = 0;
                rigidbody.linearVelocityX = 0;
                timer = .2f;
            }
        }

        if(Mathf.Abs(rigidbody.linearVelocityY) <= .5f)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                ySpeed = 0;
                rigidbody.linearVelocityY = 0;
                timer = .2f;
            }
        }
        

        //transform.position += new Vector3(moveInputX, moveInputY, 0) * targetSpeed * Time.deltaTime;
       
            //transform.position += new Vector3(1 *xSpeed, 1 *ySpeed , 0) * Time.deltaTime; //* targetSpeed * Time.deltaTime;
            //transform.position += Vector3.right * xSpeed * Time.deltaTime;
           // transform.position += Vector3.up * ySpeed * Time.deltaTime;
            //print(rigidbody.linearVelocityX);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stop"))
        {
            xSpeed = ySpeed = 0;
        }
    }

    IEnumerator DelayedAction()
    {
        
        
        // Wait for 3 seconds (scaled time)
        yield return new WaitForSeconds(.30f);
        

    }
}
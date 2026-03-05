using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{ 
    GameManager gm;
    float speed = 2f;
    float maxTimer = 4f;
    float timer;
    public bool movingRight = true;

    void Start()
    {
        if (!movingRight)
        {
            speed = -speed;
        }

        timer = maxTimer;
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.changehealth(-1);
            Debug.Log("health -1");
        }
    }


    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            timer = maxTimer;
            speed = -speed;
        }
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0); 
    }

}
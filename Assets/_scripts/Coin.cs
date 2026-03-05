using UnityEngine;

public class Coin : MonoBehaviour
{ 
    GameManager gm;
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            gm.changecoins(1);
            Destroy(gameObject);

        }
    }
}
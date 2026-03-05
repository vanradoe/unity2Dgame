using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{ 
    GameManager gm;
    void Start()
    {
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
}

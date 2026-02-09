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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.changehealth(-3);
            Debug.Log("health -3");
        }
    }
}

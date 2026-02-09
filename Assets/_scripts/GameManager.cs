using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int health;
    private int coins;
    public void changehealth(int amount)
    {
        health += amount;
    }
    public void changecoins(int amount)
    {
        coins += amount;
    }
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

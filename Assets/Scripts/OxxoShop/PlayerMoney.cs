using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money = 3000;

    public bool CanAfford(int cost)
    {
        return money >= cost;
    }

    public void SpendMoney(int amount)
    {
        money -= amount;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

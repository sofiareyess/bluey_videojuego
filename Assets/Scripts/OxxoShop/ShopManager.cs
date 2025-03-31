using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] items;
    public Transform placementArea; // Donde se colocaran los objetos
    public PlayerMoney playerMoney;

    public ObjectPlacer objectPlacer; // Asignado desde el Inspector


public void BuyItem(int index)
{
    if (index < 0 || index >= items.Length)
    {
        Debug.LogError("Índice fuera de rango.");
        return;
    }

    ShopItem item = items[index];

    if (playerMoney.CanAfford(item.price))
    {
        playerMoney.SpendMoney(item.price);

        //Guardamos que este ibjeto fue comprado (1 = comprado)
        PlayerPrefs.SetInt("Comprando_" + item.itemName, 1);
        PlayerPrefs.Save();

        //Cambiamos de escena al tycoon
        SceneManager.LoadScene("OxxoScene");
        // En vez de colocarlo automáticamente, lo pasa al ObjectPlacer
        objectPlacer.SetObjectToPlace(item.prefab);
    }
    else
    {
        Debug.Log("No tienes suficiente dinero");
    }
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

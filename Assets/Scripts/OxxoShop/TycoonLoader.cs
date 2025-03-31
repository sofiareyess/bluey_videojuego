using UnityEngine;

public class TycoonLoader : MonoBehaviour
{
    public ShopItem[] allShopItems; // Asignas los mismos que en la tienda
    public ObjectPlacer placer; // Referencia al ObjectPlacer

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (ShopItem item in allShopItems)
        {
            if (PlayerPrefs.GetInt("Comprando_"+ item.itemName, 0) == 1)
            {
                Debug.Log ("Cargando item comprado: " + item.itemName);

                //Preparamos el objeto para colocar
                placer.SetObjectToPlace(item.prefab);

                //Limpiamos el flag (opcional si solo se puede colocar una vez)
                PlayerPrefs.SetInt("Comprado_" + item.itemName, 0);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

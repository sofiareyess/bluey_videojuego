using UnityEngine;

public class TycoonLoader : MonoBehaviour
{
    public ShopItem[] allShopItems;
    public ObjectPlacer placer; // ¡Asegúrate de asignarlo desde el Inspector!

    void Start()
    {
        // Primero cargamos todos los objetos ya colocados guardados en JSON
        string json = PlayerPrefs.GetString("PlacedObjects", "");
        
        if (!string.IsNullOrEmpty(json))
        {
            SaveWrapper data = JsonUtility.FromJson<SaveWrapper>(json);

            foreach (SavedObjectData item in data.objects)
            {
                foreach (ShopItem shopItem in allShopItems)
                {
                    if (shopItem.itemName.Trim().ToLower() == item.objectName.Trim().ToLower())
                    {
                        GameObject obj = Instantiate(shopItem.prefab);
                        obj.transform.position = new Vector3(item.posX, item.posY, item.posZ);
                        obj.transform.rotation = Quaternion.Euler(0, 0, item.rotZ);
                        obj.tag = "Placed"; // Asegura que tenga el tag para mover/borrar
                        obj.AddComponent<PlacedObjectController>(); // Le damos control
                        break;
                    }
                }
            }
        }

        // Luego revisamos si hay un objeto recién comprado (y aún no colocado)
        foreach (ShopItem shopItem in allShopItems)
        {
            if (PlayerPrefs.GetInt("Comprando_" + shopItem.itemName, 0) == 1)
            {
                Debug.Log("Cargando item comprado: " + shopItem.itemName);
                placer.SetObjectToPlace(shopItem.prefab);
                PlayerPrefs.SetInt("Comprando_" + shopItem.itemName, 0);
                break;
            }
        }
    }
}


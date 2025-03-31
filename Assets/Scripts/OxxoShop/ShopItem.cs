using UnityEngine;

[CreateAssetMenu(fileName = "NuevoItem", menuName = "Tienda/Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public int price;
    public GameObject prefab;
}

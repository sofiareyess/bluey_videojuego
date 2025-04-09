using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private GameObject objectToPlace;

    public void SetObjectToPlace(GameObject prefab)
    {
        objectToPlace = Instantiate(prefab);
    }

    void Update()
    {
        if (objectToPlace != null && Input.GetMouseButtonDown(0))
        {
            Vector3 placementPos = GetMouseWorldPosition();
            objectToPlace.transform.position = placementPos;

            // IMPORTANTE: Darle el tag y el script
            objectToPlace.tag = "Placed";
            objectToPlace.AddComponent<PlacedObjectController>();

            objectToPlace = null; // Ya lo colocamos

            // ✅ Guardamos todo en JSON con el sistema global
            PlacedObjectManager.GuardarTodo();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
}



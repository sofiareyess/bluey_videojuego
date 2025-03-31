using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject objectToPlace;

    public void SetObjectToPlace(GameObject prefab)
    {
        objectToPlace = Instantiate(prefab);
    }

    void Update()
    {
        if (objectToPlace != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            objectToPlace.transform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                objectToPlace = null;
            }
        }
    }
}


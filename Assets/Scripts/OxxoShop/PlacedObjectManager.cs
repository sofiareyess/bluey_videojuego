using UnityEngine;
using System.Collections.Generic;

public class PlacedObjectManager : MonoBehaviour
{
    public static void GuardarTodo()
    {
        GameObject[] allPlaced = GameObject.FindGameObjectsWithTag("Placed");
        List<SavedObjectData> newData = new List<SavedObjectData>();

        foreach (GameObject obj in allPlaced)
        {
            if (obj != null)
            {
                SavedObjectData data = new SavedObjectData();
                data.objectName = obj.name.Replace("(Clone)", "").Trim().ToLower();
                data.posX = obj.transform.position.x;
                data.posY = obj.transform.position.y;
                data.posZ = obj.transform.position.z;
                data.rotZ = obj.transform.rotation.eulerAngles.z;

                Debug.Log("Guardando objectName: " + data.objectName);


                newData.Add(data);
            }
        }
        Debug.Log("Guardando " + newData.Count + " objetos colocados."); // ✅ AQUÍ VA


        SaveWrapper wrapper = new SaveWrapper { objects = newData };
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("PlacedObjects", json);
        PlayerPrefs.Save();
        

        Debug.Log("Guardado actualizado");
    }
}


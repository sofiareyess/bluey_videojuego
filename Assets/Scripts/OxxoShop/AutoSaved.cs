using UnityEngine;
using UnityEngine.UI;

public class AutoSaved : MonoBehaviour
{
    public Button botonGuardar;

    void Start()
    {
        botonGuardar.onClick.AddListener(() => {
            PlacedObjectManager.GuardarTodo();
        });
    }
}



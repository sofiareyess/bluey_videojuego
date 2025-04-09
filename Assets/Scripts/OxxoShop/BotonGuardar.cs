using UnityEngine;
using UnityEngine.UI;

public class BotonGuardar : MonoBehaviour
{
    public Button guardarButton;
    public FadeUI fadeUI;

    void Start()
    {
        guardarButton.onClick.AddListener(() =>
        {
            PlacedObjectManager.GuardarTodo();
            fadeUI.ShowMessage(); // 🎉 Activa la animación
        });
    }
}


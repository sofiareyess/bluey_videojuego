using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputLogin : MonoBehaviour
{
    public InputField nameInputField; // Aquí arrastras tu input en el inspector
    public InputField passwordInputField;

    public void OnLoginButtonClicked()
    {
        string playerName = nameInputField.text;
        
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName); // Guardar el nombre
            
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("El nombre no puede estar vacío.");
        }
    }
}

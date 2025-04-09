using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections;
using UnityEngine.SceneManagement;

public class Identifylogin : MonoBehaviour
{
    public InputField nameInputField;
    public InputField passwordInputField;
    public Text errorMessageText;
    
    // Variable global para guardar el id_puntos
    private int id_puntos;

    private string playerName;
    private string password;

    public void OnLoginButtonClicked()
    {
        playerName = nameInputField.text;
        password = passwordInputField.text;

        if (!string.IsNullOrEmpty(playerName) && !string.IsNullOrEmpty(password))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.SetString("Password", password);
            PlayerPrefs.Save();

            errorMessageText.text = "";
            StartCoroutine(GetData());
        }
    }

    IEnumerator GetData()
    {
        string JSONurl = "https://192.168.100.7:7264/PuntosOxxo/" + UnityWebRequest.EscapeURL(playerName) + "/" + UnityWebRequest.EscapeURL(password);
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.certificateHandler = new ForceAcceptAll();
        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error API: " + web.error);
        }
        else
        {
            // Deserializa a LoginResponse en lugar de int
            LoginResponse response = JsonConvert.DeserializeObject<LoginResponse>(web.downloadHandler.text);

            // Guarda el puntos_id en PlayerPrefs
            id_puntos = response.puntos_id;
            PlayerPrefs.SetInt("IdPuntos", id_puntos);  // Guardar el id_puntos
            PlayerPrefs.Save();  // Asegúrate de guardar los cambios

            // Sigue con la validación usando confirmnumber
            CheckInfo(response.confirmnumber);
        }
    }

    public void CheckInfo(int confirmnumber)
    {
        if (confirmnumber == 1)
        {
            SceneManager.LoadScene("OxxoScene");
        }
        else
        {
            errorMessageText.text = "Usuario o contraseña incorrectos."; 
        }
    }
}


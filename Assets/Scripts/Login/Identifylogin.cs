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
    string JSONurl = "https://10.22.156.118:7264/PuntosOxxo/" + UnityWebRequest.EscapeURL(playerName) + "/" + UnityWebRequest.EscapeURL(password);
    UnityWebRequest web = UnityWebRequest.Get(JSONurl);
    web.certificateHandler = new ForceAcceptAll();
    yield return web.SendWebRequest();

    if (web.result != UnityWebRequest.Result.Success)
    {
        Debug.Log("Error API: " + web.error);
    }
    else
    {
        int exists = JsonConvert.DeserializeObject<int>(web.downloadHandler.text); 
        CheckInfo(exists);
    }
}

public void CheckInfo(int exists)
{
    if (exists == 1)
    {
        SceneManager.LoadScene("OxxoScene");
    }
    else
    {
        errorMessageText.text = "Usuario o contraseña incorrectos."; 
    }
}

}

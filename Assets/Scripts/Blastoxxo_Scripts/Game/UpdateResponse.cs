using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections;

public class UpdateResponse : MonoBehaviour
{
    private int id_puntos;
    private int puntos;

    // Obtén estos valores del juego
    void Start()
    {
        id_puntos = PlayerPrefs.GetInt("IdPuntos", 0); // Obtener el id_puntos de PlayerPrefs
        puntos = PlayerPrefs.GetInt("Puntos", 0); // Obtener los puntos actuales
    }

    public void OnLoginButtonClicked()
    {
        // Llama al IEnumerator que enviará los datos al servidor
        StartCoroutine(UpdateData());
    }

    // Método para actualizar los puntos
   IEnumerator UpdateData()
{
    string url = "https://192.168.100.7:7264/PuntosOxxo/" + id_puntos;

    // Crear el objeto con los datos que vamos a enviar
    Puntos puntosOxxo = new Puntos
    {
        id_puntos = id_puntos,
        puntos = puntos , // Usamos el mismo valor para puntos y puntos_historico
        puntos_historico= puntos
    };

    // Serializamos el objeto a JSON
    string jsonData = JsonConvert.SerializeObject(puntosOxxo);

    // Configurar la solicitud POST
    UnityWebRequest web = new UnityWebRequest(url, "POST");
    byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
    web.uploadHandler = new UploadHandlerRaw(bodyRaw);
    web.downloadHandler = new DownloadHandlerBuffer();
    web.SetRequestHeader("Content-Type", "application/json");

    // Asegura que el certificado SSL sea aceptado si es necesario
    web.certificateHandler = new ForceAcceptAll();

    // Enviar la solicitud
    yield return web.SendWebRequest();

    if (web.result != UnityWebRequest.Result.Success)
    {
        Debug.Log("Error al actualizar los puntos: " + web.error);
    }
    else
    {
        Debug.Log("Puntos actualizados correctamente.");
    }
}

}
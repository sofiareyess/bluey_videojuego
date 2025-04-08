using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
public class PuntosController : MonoBehaviour
{
    public Text puntosText;

void Start()
{
    GetPuntosTotales(5); // Esto hará que apenas cargue la escena, traiga los puntos y los muestre
}

public void GetPuntosTotales(int idPuntos)
{
    StartCoroutine(GetPuntosCoroutine(idPuntos));
}

IEnumerator GetPuntosCoroutine(int idPuntos)
{
    string JSONurl = $"https://10.22.148.9:5001/Libros/Puntostotales?id_puntos=2";
    UnityWebRequest web = UnityWebRequest.Get(JSONurl);
    web.certificateHandler = new ForceAccepAll(); // Para aceptar SSL si estás en local
    yield return web.SendWebRequest();

    if (web.result != UnityWebRequest.Result.Success)
    {
if (web.result != UnityWebRequest.Result.Success)
{
    UnityEngine.Debug.LogError("❌ Error al obtener puntos: " + web.error);
    UnityEngine.Debug.LogError("URL llamada: " + JSONurl);
    puntosText.text = "Error al cargar puntos.";
}

    }
    else
    {
        PuntosTotalesResponse puntos = JsonConvert.DeserializeObject<PuntosTotalesResponse>(web.downloadHandler.text);
        UnityEngine.Debug.Log("Puntos totales: " + puntos.puntosTotales);
        puntosText.text = $"$ {puntos.puntosTotales}";
        PlayerPrefs.SetInt("puntos_totales", puntos.puntosTotales);
    }
}
[System.Serializable]
public class PuntosTotalesResponse
{
    public int puntosTotales;
}


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
}

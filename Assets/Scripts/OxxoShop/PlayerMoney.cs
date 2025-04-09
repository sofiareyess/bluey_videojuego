using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections;

public class PlayerMoney : MonoBehaviour
{
    public int money = 3000;

    public bool CanAfford(int cost)
    {
        return money >= cost;
    }

    public void SpendMoney(int amount)
    {
        money -= amount;
        StartCoroutine(ActualizarDineroEnAPI(money));
    }

    void Start()
    {
        StartCoroutine(CargarDineroDesdeAPI());
    }
    public void RefundMoney(int amount)
{
    money += amount;
    StartCoroutine(ActualizarDineroEnAPI(money));
    Debug.Log($"💸 Se reembolsaron {amount} monedas. Nuevo total: {money}");
}


    IEnumerator CargarDineroDesdeAPI()
    {
        string url = "https://10.22.148.9:5001/Libros/Puntostotales?id_puntos=2";
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.certificateHandler = new ForceAccepAll();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            PuntosTotalesResponse data = JsonConvert.DeserializeObject<PuntosTotalesResponse>(request.downloadHandler.text);
            money = data.puntostotales;
            Debug.Log("💰 Dinero cargado desde API: " + money);
        }
        else
        {
            Debug.LogError("Error al cargar dinero: " + request.error);
        }
    }

    IEnumerator ActualizarDineroEnAPI(int nuevoValor)
    {
        string url = "https://10.22.148.9:5001/Libros/UpdatePuntos?id=2";

        PuntosTotalesResponse data = new PuntosTotalesResponse
        {
            id_puntos = 5,
            puntostotales = nuevoValor,
            id_partida = 1
        };

        string json = JsonConvert.SerializeObject(data);

        UnityWebRequest request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.certificateHandler = new ForceAccepAll();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(" Dinero actualizado en la API: " + nuevoValor);
        }
        else
        {
            Debug.LogError(" Error al actualizar dinero: " + request.error);
        }
    }

    [System.Serializable]
    public class PuntosTotalesResponse
    {
        public int id_puntos;
        public int puntostotales;
        public int id_partida;
    }
}

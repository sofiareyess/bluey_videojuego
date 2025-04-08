using UnityEngine;
using UnityEngine.UI;

public class PuntosController : MonoBehaviour
{
    public Text textoPuntos;
    private int puntos = 0;

    void Start()
    {
        ActualizarTexto();
    }

    public void AgregarPuntos(int cantidad)
    {
        int totalPuntos = PlayerPrefs.GetInt("Puntos", 0); // Obtener puntos guardados
        totalPuntos += cantidad; // Ahora sumamos los puntos correctamente
        PlayerPrefs.SetInt("Puntos", totalPuntos); // Guardar los puntos
        GameController.Instance.checkGameOver(totalPuntos);
        PlayerPrefs.Save();
        ActualizarTexto(); // Actualizar el texto con el nuevo total
    }

   public void ActualizarTexto()
    {
        puntos = PlayerPrefs.GetInt("Puntos", 0); // Obtener los puntos actualizados
        textoPuntos.text = "PuntOxxos: " + puntos;
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes agregar lógica si necesitas actualizar el texto de manera dinámica
    }
}

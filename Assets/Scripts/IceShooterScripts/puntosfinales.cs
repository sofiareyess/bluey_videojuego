using UnityEngine;
using UnityEngine.UI;

public class PuntosFinalesController : MonoBehaviour
{
    public Text textoPuntosFinales;

    void Start()
    {
        int puntosGuardados = PlayerPrefs.GetInt("Puntos", 0); // Carga el puntaje guardado
        textoPuntosFinales.text = "Tus PuntOXXOs: " + puntosGuardados;
        
    }
}
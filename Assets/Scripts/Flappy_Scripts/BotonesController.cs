using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesController : MonoBehaviour
{
    private PreguntasController preguntasController;
    private PausaBehaviour pauseBehaviour; // Referencia a PauseBehaviour
    private PuntosController puntosController; // Referencia a PuntosController

    void Start()
    {
        preguntasController = FindFirstObjectByType<PreguntasController>();
        pauseBehaviour = FindFirstObjectByType<PausaBehaviour>(); // Obtener el script de pausa
        puntosController = FindFirstObjectByType<PuntosController>(); // Obtener el PuntosController
    }

    public void SeleccionarOpcion(int opcion)
    {
        Preguntas preguntaActual = preguntasController.GetPreguntaActual();
        if (preguntaActual != null)
        {
            if (opcion == preguntaActual.respuestaCorrecta)
            {
                PlayerPrefs.SetInt("RespuestaCorrecta", 1);
                
                // Sumar puntos directamente usando PlayerPrefs
                int totalPuntos = PlayerPrefs.GetInt("Puntos", 0) + 100;
                PlayerPrefs.SetInt("Puntos", totalPuntos);
                PlayerPrefs.Save();

                // Llamar a ActualizarTexto para actualizar el texto de los puntos
                puntosController.ActualizarTexto();

                // Cierra el panel de preguntas y reanuda el juego solo si la respuesta es correcta
                if (pauseBehaviour != null)
                {
                    pauseBehaviour.ResumeGame();
                }
                preguntasController.IncrementarEstrellas();
            }
            else
            {
                SceneManager.LoadScene("EndGame_HormiOXXO");
            }
        }
    }
}



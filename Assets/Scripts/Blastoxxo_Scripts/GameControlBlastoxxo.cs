using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class GameControlBlastoxxo : MonoBehaviour
{
    PreguntasController preguntasController;
     public void Start()
     {
        preguntasController = FindFirstObjectByType<PreguntasController>();
     }
     public void GoToPauseMenu()
    {
        GameEvents.GameOver(false);
        GameEvents.AddScores(0);
        
    }

    public void opcionA()
    {
        SeleccionarOpcion(0);
    }

    public void opcionB()
    {
        SeleccionarOpcion(1);
    }

    public void opcionC()
    {
        SeleccionarOpcion(2);
    }

    public void SeleccionarOpcion(int opcion)
    {
        Preguntas preguntaActual = preguntasController.GetPreguntaActual();
        if (preguntaActual != null)
        {
            if (opcion == preguntaActual.respuestaCorrecta)
            {
                //hide el panel y cambiar text
                GameEvents.HidePanel();
                preguntasController.BorrarPregunta();
            }
            else
            {
                GameEvents.ResetScore();
                preguntasController.BorrarPregunta();
                GameEvents.HidePanel();
            }
        }
    }
}

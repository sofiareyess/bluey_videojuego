using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PreguntasController : MonoBehaviour
{


    public Text preguntaText;
    public Text opcionAText;
    public Text opcionBText;
    public Text opcionCText;
    private int estrellasChocadas = 0;

    List<Preguntas> preguntasflappy = new List<Preguntas>
    {
        new Preguntas("¿Cómo aumentar las ventas?", "Subir precios", "Ignorar clientes", "Mantener estantes organizados", 2),
        new Preguntas("¿Cómo debe ser la atención al cliente?", "Rápida sin amabilidad", "Solo si el cliente lo pide", "Amable y proactiva", 2),
        new Preguntas("¿Qué hacer si un cliente se queja?", "Ignorarlo", "Resolver el problema con cortesía", "Llamar al gerente de inmediato", 1),
        new Preguntas("¿Qué productos deben estar al frente en los estantes?", "Los más viejos", "Los más vendidos", "Los productos al azar", 1),
        new Preguntas("¿Cómo manejar el cambio en la caja?", "Dar lo menos posible", "Decir que no hay", "Dar el cambio exacto con amabilidad", 2),
        new Preguntas("¿Cómo debe estar la tienda en todo momento?", "Limpia y ordenada", "Con productos fuera de lugar", "Sin personal atendiendo", 0),
        new Preguntas("¿Qué hacer si un cliente se siente mal atendido?", "Ofrecer disculpas y solucionar el problema", "Decir que no es culpa del asesor", "Dejarlo ir sin hacer nada", 0),
        new Preguntas("¿Cómo atender a un cliente que quiere una devolución?", "Verificar la política y ofrecer la solución correcta", "Decir que no se aceptan devoluciones", "Decir que el gerente decidirá", 0),
        new Preguntas("¿Qué hacer cuando un cliente está insatisfecho con un producto?", "Ofrecerle un reemplazo o reembolso", "Decir que no podemos hacer nada", "Ignorarlo", 0),
        new Preguntas("¿Cómo deben estar los precios en los productos?", "Claramente visibles", "Ocultos o borrosos", "Sin etiquetas de precio", 0)


    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Si el juego se reinició, asegúrate de que se reinicie desde la primera pregunta
         // Si el juego se reinició, reiniciar las estrellas a 0
    if (PlayerPrefs.GetInt("ReiniciarJuego", 0) == 1)
    {
         PlayerPrefs.SetInt("RespuestaCorrecta", 0); 
        PlayerPrefs.SetInt("ReiniciarJuego", 0); // Limpia el flag para futuros intentos
        PlayerPrefs.Save();
    }
    else if (PlayerPrefs.GetInt("RespuestaCorrecta", 0) == 1)
    {
        IncrementarEstrellas();
        PlayerPrefs.SetInt("RespuestaCorrecta", 0); // Resetear el flag
        PlayerPrefs.Save();
    }
    MostrarPregunta();
    }
     void MostrarPregunta()
    {
        estrellasChocadas=PlayerPrefs.GetInt("EstrellasChocadas", 0);
        if (estrellasChocadas < preguntasflappy.Count)
        {
            preguntaText.text = preguntasflappy[estrellasChocadas].pregunta;
            opcionAText.text = preguntasflappy[estrellasChocadas].opciones[0];
            opcionBText.text = preguntasflappy[estrellasChocadas].opciones[1];
            opcionCText.text = preguntasflappy[estrellasChocadas].opciones[2];
        }

    }

       public void IncrementarEstrellas()
    {
        int numestrellas=PlayerPrefs.GetInt("EstrellasChocadas", 0);
        numestrellas+=1;

        PlayerPrefs.SetInt("EstrellasChocadas", numestrellas); // Guardar el número de estrellas
        PlayerPrefs.Save();
        MostrarPregunta();
    }
public Preguntas GetPreguntaActual()
{
    int index = PlayerPrefs.GetInt("EstrellasChocadas", 0);
    if (index < preguntasflappy.Count)  // Asegurar que el índice es válido
    {
        return preguntasflappy[index];
    }
    return null; // Evita errores si el índice es inválido
}


    // Update is called once per frame
    void Update()
    {
        
    }
}

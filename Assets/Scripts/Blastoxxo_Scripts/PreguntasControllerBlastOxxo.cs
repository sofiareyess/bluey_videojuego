using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PreguntasController : MonoBehaviour
{
    public Text preguntaText;
    public Text opcionAText;
    public Text opcionBText;
    public Text opcionCText;

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

    public void MostrarPregunta()
    {
       int indexPreguntas = PlayerPrefs.GetInt("IndexPreguntas");
        if (indexPreguntas < preguntasflappy.Count)
        {
            preguntaText.text = preguntasflappy[indexPreguntas].pregunta;
            opcionAText.text = preguntasflappy[indexPreguntas].opciones[0];
            opcionBText.text = preguntasflappy[indexPreguntas].opciones[1];
            opcionCText.text = preguntasflappy[indexPreguntas].opciones[2];
        }

    }
    
public Preguntas GetPreguntaActual()
{
    int indexPreguntas = PlayerPrefs.GetInt("IndexPreguntas");
    if (indexPreguntas < preguntasflappy.Count)
    {
        return preguntasflappy[indexPreguntas];
    }
    else if(indexPreguntas == preguntasflappy.Count)
    PlayerPrefs.SetInt("IndexPreguntas", 0);
    return null; 
}

public void BorrarPregunta()
{
    preguntaText.text = "Esperando Siguiente Pregunta";
    opcionAText.text = "Opcion A";
    opcionBText.text = "Opcion B";
    opcionCText.text = "Opcion C";
}



}

public class Preguntas
{
    public string pregunta;
    public string[] opciones;
    public int respuestaCorrecta; // Índice de la opción correcta

    public Preguntas(string pregunta, string op1, string op2, string op3, int correcta)
    {
        this.pregunta = pregunta;
        this.opciones = new string[] { op1, op2, op3 };
        this.respuestaCorrecta = correcta;
    }
}


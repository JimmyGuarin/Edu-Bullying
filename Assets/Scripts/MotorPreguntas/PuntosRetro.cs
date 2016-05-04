using UnityEngine;
using System.Collections;

public class PuntosRetro {


    public ArrayList misPreguntas;
    public string retroalimentacion;

    public PuntosRetro(string retro)
    {
        misPreguntas = new ArrayList();
        retroalimentacion = retro;
    }


    public void Barajar()
    {
        for (int i = 0; i < misPreguntas.Count; i++)
        {
            Preguntas temp = (Preguntas)misPreguntas[i];
            int randomIndex = Random.Range(0, misPreguntas.Count);
            misPreguntas[i] = misPreguntas[randomIndex];
            misPreguntas[randomIndex] = temp;

        }
    }
}

using UnityEngine;
using System.Collections;

public class BullyingFisico : MonoBehaviour {

    public Nivel miNivel;



    void Awake()
    {
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("El jefe es alguien que tiene la A en su nombre, yo no programo en Ruby");
            p1.misPreguntas.Add(new Preguntas("Quien es el Jefe", "Yo", "Felipe", "Faber", "Viviana"));
            p1.misPreguntas.Add(new Preguntas("¿Programo en Unity?", "Si", "No"));
            p1.Barajar();

        miNivel.puntosRetro.Add(p1);
        GetComponent<Bullying>().misPuntosRetro = miNivel.puntosRetro;
        //toString();

    }


    public void toString()
    {

        for(int i = 0; i < miNivel.puntosRetro.Count; i++){

            PuntosRetro pr = (PuntosRetro)miNivel.puntosRetro[i];

            Debug.Log(pr.retroalimentacion);
            for(int j = 0; j < pr.misPreguntas.Count;j++){

                Preguntas p =(Preguntas) pr.misPreguntas[j];

                Debug.Log(p.Enunciado);
                Debug.Log("");
                for(int k = 0; k < p.Respuestas.Length; k++){

                    Debug.Log("-" + p.Respuestas[k]);
                }

            }

        }

    }


}

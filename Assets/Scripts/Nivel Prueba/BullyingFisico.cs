using UnityEngine;
using System.Collections;

public class BullyingFisico : MonoBehaviour {

    public Nivel miNivel;



    void Awake()
    {
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("El lider de Proyectos tiene un su nombre la letra Y, nosotros no programamos en Ruby.");
            p1.misPreguntas.Add(new Preguntas("Quien es el  Lider de Proyectos", "Yovanny", "Felipe", "Jimmy", "Viviana"));
            p1.misPreguntas.Add(new Preguntas("¿Programo en Unity?", "Si", "No"));
            

        PuntosRetro p2 = new PuntosRetro("Si quieres tener éxito necesitas mucha disciplina, valentía y empeño");
            p2.misPreguntas.Add(new Preguntas("¿ Qué no necesita para tener éxito?", "Plata", "Valentía", "Disciplina", "Empeño"));
            p2.misPreguntas.Add(new Preguntas("¿Necesitas Valentía para tener éxito ? ", "Si", "No"));
            p2.Barajar();

        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        GetComponent<Bullying>().misPuntosRetro = miNivel.puntosRetro;
        GetComponent<Bullying>().Barajar();
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

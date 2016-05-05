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
            p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("Si quieres tener éxito necesitas mucha disciplina, valentía y empeño");
            p2.misPreguntas.Add(new Preguntas("¿ Qué no necesita para tener éxito?", "Plata", "Valentía", "Disciplina", "Empeño"));
            p2.misPreguntas.Add(new Preguntas("¿Necesitas Valentía para tener éxito ? ", "Si", "No"));
            p2.Barajar();

        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);


        GameObject personaje = GameObject.FindGameObjectWithTag("Player");
        personaje.GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
        personaje.GetComponent<ManejadorPreguntas>().Barajar();
     

    }
}

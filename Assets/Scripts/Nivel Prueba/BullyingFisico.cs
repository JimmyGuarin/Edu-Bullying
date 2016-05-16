using UnityEngine;
using System.Collections;
public class BullyingFisico : MonoBehaviour
{

    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("El Bullying Físico incluye agresiones físicas");
            p1.misPreguntas.Add(new Preguntas("Quien es el  Lider de Proyectos", "Yovanny", "Felipe", "Jimmy", "Viviana",true));
            p1.misPreguntas.Add(new Preguntas("¿Programo en Unity?", "Si", "No"));
            p1.Barajar();

		PuntosRetro p2 = new PuntosRetro("Aquí son muy comunes las acciones humillantes como bajar los pantalones");
            p2.misPreguntas.Add(new Preguntas("¿ Qué no necesita para tener éxito?", "Plata", "Valentía", "Disciplina", "Empeño", true));
            p2.misPreguntas.Add(new Preguntas("¿Necesitas Valentía para tener éxito ? ", "Si", "No"));
            p2.Barajar();

        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);


        GameObject personaje = GameObject.FindGameObjectWithTag("Player");
		GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
		GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------

        EstadoConversacion ec0 = new EstadoConversacion(0, new Preguntas("Deseas que te pegue", "tal vez", "quiero hablarte del bullying", "ya me canse de eso", "",false));
        EstadoConversacion ec1 = new EstadoConversacion(0, new Preguntas("Pues entonces lo haré", "No por favor", "Lo que sea", "Se lo diré a mi mamá", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(0, new Preguntas("Y que es esa cosa", "Es lo que tu me haces", "Es pegarle a los otros", "la profesora lo sabe", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(0, new Preguntas("Y que vas hacer", "Pegarte", "Se lo diré a mi mamá", "Decirle a tu mamá", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(0, new Preguntas("Por que no tendria que hacerlo", "Por que voy a hablarte de Bullying", "Por que aquí está la profe", "Se lo diré a mi mamá", "", false));
        EstadoConversacion ec5 = new EstadoConversacion(0, new Preguntas("Te pegaré!!!", "No por favor", "Estoy listo", "la profesora lo sabra", "", false));
        EstadoConversacion ec6 = new EstadoConversacion(0, new Preguntas("Pues digale", "Eso Haré", "Se lo diré a tu mamá", "tal vez", "", false));

        ec0.AgregarProximos(new int[3] { 1, 2, 3 });
        ec1.AgregarProximos(new int[3] { 4, 5, 6 });
        

        conversacion.estados = new EstadoConversacion[7] { ec0, ec1, ec2, ec3,ec4,ec5,ec6 };
        


    }
}

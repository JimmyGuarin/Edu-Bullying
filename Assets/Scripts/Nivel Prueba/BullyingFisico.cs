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

        PuntosRetro p1 = new PuntosRetro("El Bullying Físico ess el tipo de acoso más común, especialmente entre chicos.");
            p1.misPreguntas.Add(new Preguntas("Cuál es el tipo de Bullying más común", "Bullying Físico", "Bullying Psicológico", "Bullying Verbal", "CyberBullying",true));
            p1.misPreguntas.Add(new Preguntas("¿El Bullying Físico es más común entre chicas?", "Si", "No"));
            p1.Barajar();

		PuntosRetro p2 = new PuntosRetro("El Bullying Físico incluye golpes, empujones e incluso palizas entre uno o varios agresores contra una sola víctima.");
            p2.misPreguntas.Add(new Preguntas("El bullying Físico incluye: ", "Golpes", "Ataques virtuales", "Chismes", "Abuso Sexual", true));
            p2.misPreguntas.Add(new Preguntas("En el Bullying Físico se dan palizas entre uno o varios agresoras contra una sola víctima", "Verdadero", "Falso"));
            p2.Barajar();




        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);



		GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
		GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------


        EstadoConversacion ec0 = new EstadoConversacion(0, new Preguntas("Deseas que te pegue", "tal vez", "quiero hablarte del bullying", "ya me canse de eso", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(-10, new Preguntas("Pues entonces lo haré", "No por favor", "Lo que sea", "Se lo diré a mi mamá", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(10, new Preguntas("Y que es esa cosa", "Es lo que tu me haces", "Es pegarle a los otros", "la profesora lo sabe", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(-10, new Preguntas("Y que vas hacer", "Pegarte", "Se lo diré a mi mamá", "quiero hablarte del bullying", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(10, new Preguntas("Por que no tendria que hacerlo", "Por que voy a hablarte de Bullying", "Por que aquí está la profe", "Se lo diré a mi mamá", "", false));
        EstadoConversacion ec5 = new EstadoConversacion(-10, new Preguntas("Te pegaré!!!", "No por favor", "Estoy listo", "la profesora lo sabra", "", false));
        EstadoConversacion ec6 = new EstadoConversacion(-10, new Preguntas("Pues digale y verás", "Eso Haré", "Se lo diré a tu mamá", "tal vez", "", false));
        EstadoConversacion ec7 = new EstadoConversacion(10, new Preguntas("Lo que tú sientas me tiene sin cuidado", "Tienes problemas que debes solucionar", "Se lo diré a tu mamá", "Ya verás lo que haré", "", false));
        EstadoConversacion ec8 = new EstadoConversacion(10, new Preguntas("Lo que tú sientas me tiene sin cuidado", "Tienes problemas que debes solucionar", "Se lo diré a tu mamá", "Le diré a la profesora", "", false));

        ec0.AgregarProximos(new int[3] { 1, 2, 3 });
        ec1.AgregarProximos(new int[3] { 4, 5, 6 });
        ec2.AgregarProximos(new int[3] { 7, 5, 6 });
        ec3.AgregarProximos(new int[3] { 5, 5, 2 });
        ec4.AgregarProximos(new int[3] { 2, 6, 5 });
        ec5.AgregarProximos(new int[3] { 4, 1, 6 });
        ec6.AgregarProximos(new int[3] { 5, 5, 1 });
        ec7.AgregarProximos(new int[3] { 8, 5, 6 });
        ec8.AgregarProximos(new int[3] { 8, 5, 6 });


        conversacion.estados = new EstadoConversacion[9] { ec0, ec1, ec2, ec3, ec4, ec5, ec6, ec7, ec8 };



    }
}

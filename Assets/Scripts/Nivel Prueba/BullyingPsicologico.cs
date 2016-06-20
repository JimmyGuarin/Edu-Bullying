using UnityEngine;
using System.Collections;

public class BullyingPsicologico : MonoBehaviour {


    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("Los Factores del Bullying Psicológico son las más difíciles de detectar por parte de los profesores o padres porque son formas de acoso o exclusión que se llevan a cabo a espaldas de cualquier persona que pueda advertir la situación.");
            p1.misPreguntas.Add(new Preguntas("¿Por qué es tan difícil de detectar el Bullying Psicológico?", " Ocurre a espaldas de cualquier persona que advierta la situación", " Es común en Hombres", " Es común en Mujeres", "Por que todos lo saben", true));
            p1.misPreguntas.Add(new Preguntas("¿Es el Bullying Psicológico el más difícil de detectar?", "Sí", "No"));
            p1.misPreguntas.Add(new Preguntas("¿La exclusión hace parte del Bullying Psicológico?", "Verdadero", "Falso"));
            p1.misPreguntas.Add(new Preguntas("¿A quién debería informarse en caso de presentarse Bullying Psicológico?", "Todas son correctas", "Profesores", "Coordinadores o Rectores", "Padres", true));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("El Bullying Psicológico son acciones que dañan la autoestima de la víctima y fomentan su sensación de temor; aumenta el sentimiento de indefensión y vulnerabilidad, pues percibe este atrevimiento como una amenaza que tarde o temprano se materializará de manera más contundente.");
            p2.misPreguntas.Add(new Preguntas("¿Qué sentimiento presenta una victima del Bullying Psicológico?", "Indefensión y vulnerabilidad", "Rabia y egoísmo", "Frustración", "Ninguna de las anteriores", true));
            p2.misPreguntas.Add(new Preguntas("¿Los factores presentes en el Bullying Psicológico afecta la autoestima de la víctima?", "Sí", "No"));
            p2.misPreguntas.Add(new Preguntas("¿Las víctimas del Bullying Psicológico nunca sienten miedo?", "Falso", "Verdadero"));
            p2.misPreguntas.Add(new Preguntas("¿Por qué las personas perciben que las acciones del Bullying Psicológico tarde o temprano se materializarán de una amenaza a algo más contundente?", "Todas las anteriores", "Porque hay sentimientos de indefensión y vulnerabilidad", " Fomentan la sensación de temor", "Porque dañan la autoestima de la víctima", true));
        p2.Barajar();

        PuntosRetro p3 = new PuntosRetro("El Bullying Psicológico es la persecución, intimidación, tiranía, chantaje, manipulación y amenazas al otro.");
        p3.misPreguntas.Add(new Preguntas("¿Qué factor NO  hace parte del Bullying Psicológico?", "Empujones", "Intimidación", "Persecución", "Tiranía", true));
        p3.misPreguntas.Add(new Preguntas("¿El chantaje hace parte de los factores que ocurren en el Bullying Psicológico?", "Sí", "No"));
        p3.misPreguntas.Add(new Preguntas("¿Los golpes pertenecen al Bullying Psicológico?", "Falso", "Verdadero"));
        p3.misPreguntas.Add(new Preguntas("¿El Bullying Psicológico se presenta cuando existe manipulación y amenazas a otra persona?", "Verdadero", "Falso"));
        p3.misPreguntas.Add(new Preguntas("¿Estos factores son comunes en el Bullying Psicológico?", "Manipulación, persecución y amenazas al otro", "Golpes y Gritos", "Chismes", "Ninguna es Correcta", true));
        p3.Barajar();



        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        miNivel.puntosRetro.Add(p3);

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


        conversacion.estados = new EstadoConversacion[9] { ec0, ec1, ec2, ec3, ec4, ec5, ec6,ec7,ec8 };



    }
}

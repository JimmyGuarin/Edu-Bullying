using UnityEngine;
using System.Collections;

public class BullyingSocial : MonoBehaviour
{
    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("En el Bullying social se pretende aislar al niño o joven del resto del grupo, ignorándolo, aislandolo y excluyéndolo del resto.");
            p1.misPreguntas.Add(new Preguntas("¿Qué acciones se presentan en el Bullying Social?", "Todas son correctas", "Aislar el joven del resto del grupo", "Ignorarlo", " Excluir del resto", true));
            p1.misPreguntas.Add(new Preguntas("¿Excluir un joven de las actividades que se realicen en conjunto puede considerarse como Bullying Social?", "Sí", "No"));
            p1.misPreguntas.Add(new Preguntas("¿Qué Factor se presenta normalmente en el Bullying Social?", "Ignorarlo", " Obligar a una persona hacer lo que no quiere", "Intimidar una persona", "Golpear y Amenazar", true));
            p1.misPreguntas.Add(new Preguntas("¿Aislar al niño o joven del grupo puede considerarse Bullying Social?", "Verdadero", "Falso"));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("El Bullying Social puede transmitirse de forma directa: excluir, no dejar participar a la víctimas en actividades y sacarlos del grupo, comunicándolo directamente.");
        p2.misPreguntas.Add(new Preguntas("¿De qué forma puede transmitirse el Bullying Social?", "Directa", "Homófono", "Acoso sexual", "Ninguna es correcta", true));
        p2.misPreguntas.Add(new Preguntas("¿En qué consiste el Bullying Social Directo?", "En no dejar participar la víctima en actividades", "En golpear directamente a la víctima", "En generar chismes sobre una persona", "Ninguna es correcta", true));
        p2.misPreguntas.Add(new Preguntas("¿Sacar a un compañero del grupo y no dejar que realice actividades es Bullying Social?", "Sí", "No"));
        p2.misPreguntas.Add(new Preguntas("¿Ignorar a una persona, tratándola como un objeto hace parte del Bullying Social directo?", "Falso", "Verdadero"));
        p2.Barajar();

        PuntosRetro p3 = new PuntosRetro("El Bullying social indirecto es ignorar, tratar como un objeto, como si no existiera o hacer ver que no está ahí.");
        p3.misPreguntas.Add(new Preguntas("¿Cuáles son factores presentes en el Bullying Social indirecto?", "Todas son correctas", "Tratarlos como a un objeto", "Ignorar a otros", "Fingir que no existen", true));
        p3.misPreguntas.Add(new Preguntas("¿Hacer ver que alguien no está presente es Bullying Social indirecto?", "Verdadero", "Falso"));
        p3.misPreguntas.Add(new Preguntas("¿Tratar a una persona como un objeto es hacer Bullying Directo?", "Falso", "Verdadero"));
        p3.Barajar();

        PuntosRetro p4 = new PuntosRetro("Ser víctima de bullying no es algo divertido. Muchas personas, niños, adolescentes y adultos, son víctimas de bullying en sus vidas.");
        p4.misPreguntas.Add(new Preguntas("¿Qué personas pueden ser víctimas de Bullying?", "Todas son correctas", "Los niños", "Los Adolescentes", "Los Adultos", true));
        p4.misPreguntas.Add(new Preguntas("¿En el Bullying las víctimas pueden ser incluso personas adultas?", "Verdadero", "Falso"));
        p4.Barajar();

        PuntosRetro p5 = new PuntosRetro("Algunas veces, cuando el bullying llega a puntos extremos, las personas deciden terminar con sus vidas.");
        p5.misPreguntas.Add(new Preguntas("¿Cuál es la peor consecuencia cuando el Bullying llega a puntos extremos?", "Que las víctimas terminan con sus vidas", "Que las víctimas golpeen a su agresor", "Que los agresores se cansen de hacer Bullying", "Que los padres de las víctimas nunca se enteren", true));
        p5.misPreguntas.Add(new Preguntas("¿El Bullying puede llegar a hacer  que las víctimas decidan terminar con sus vidas?", "Verdadero", "Falso"));
        p5.Barajar();


        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        miNivel.puntosRetro.Add(p3);
        miNivel.puntosRetro.Add(p4);
        miNivel.puntosRetro.Add(p5);

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

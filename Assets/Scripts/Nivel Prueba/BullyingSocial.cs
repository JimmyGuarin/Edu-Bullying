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

        EstadoConversacion ec0 = new EstadoConversacion(new int[] { -10, 10, -20 }, new Preguntas("Llegó el chico invisible", "No me importa que me veas así", "No me veas así, no te he hecho nada malo", "También eres invisible para mí", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(new int[] { -20,-30, 10 }, new Preguntas("Simplemente no me gusta verte", "La verdad tampoco me gusta verte", "Eres la peor persona del Colegio", "Podemos solucionar esto con ayuda de profesores y padres", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(new int[] { -30, 10, -30 }, new Preguntas("No se si me llegues a caer bien", "Entonces te voy a ignorar", "Quiero intentarlo, podemos ser grandes amigos", "Tú nunca me vas a caer bien", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(new int[] { 20, -10, 20 }, new Preguntas("Jamás serás feliz en este colegio", "Por favor no me discrimines", "Haré que tampoco seas feliz", "¿Por qué no quieres que seamos amigos?", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(new int[] { 30, -10, -10 }, new Preguntas("¡Eso me hace feliz!", "Yo quiero tener una buena relación con todos", "Tú me irritas", "Nadie en este colegio me cae bien", "", false));
        EstadoConversacion ec5 = new EstadoConversacion(new int[] { -10, 30, -10 }, new Preguntas("A todos nos irrita el solo verte", "Aquí nadie me importa", "¿Por qué me dices invisible?", "Tú no me importas", "", false));
    
        ec0.AgregarProximos(new int[3] { 3, 1, 5 });
        ec1.AgregarProximos(new int[3] { 4, 5, 2 });
        ec2.AgregarProximos(new int[3] { 4, 2, 3 });
        ec3.AgregarProximos(new int[3] { 1, 5, 1 });
        ec4.AgregarProximos(new int[3] { 2, 5, 5 });
        ec5.AgregarProximos(new int[3] { 5, 1, 5 });

        conversacion.estados = new EstadoConversacion[6] { ec0, ec1, ec2, ec3, ec4, ec5};
    }
}

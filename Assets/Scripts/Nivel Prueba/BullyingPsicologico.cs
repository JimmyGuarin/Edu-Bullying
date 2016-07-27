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
            p1.misPreguntas.Add(new Preguntas("¿Por qué es tan difícil de detectar el Bullying Psicológico?", " Ocurre a espaldas de cualquier persona que advierta la situación", " Es más común en Hombres", " Es más común en Mujeres", "Por que todos lo saben", true));
            p1.misPreguntas.Add(new Preguntas("¿Es el Bullying Psicológico el más difícil de detectar?", "Sí", "No"));
            p1.misPreguntas.Add(new Preguntas("¿La exclusión hace parte del Bullying Psicológico?", "Verdadero", "Falso"));
            p1.misPreguntas.Add(new Preguntas("¿A quién debería informarse en caso de presentarse Bullying Psicológico?", "Todas son correctas", "Profesores", "Coordinadores o Rectores", "Padres", true));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("El Bullying Psicológico son acciones que dañan la autoestima de la víctima y fomentan su sensación de temor; aumenta el sentimiento de indefensión y vulnerabilidad, pues percibe este atrevimiento como una amenaza que tarde o temprano se materializará de manera más contundente.");
            p2.misPreguntas.Add(new Preguntas("¿Qué sentimiento presenta una victima del Bullying Psicológico?", "Indefensión y vulnerabilidad", "Rabia y egoísmo", "Frustración", "Ninguna de las anteriores", true));
            p2.misPreguntas.Add(new Preguntas("¿Los factores presentes en el Bullying Psicológico afecta la autoestima de la víctima?", "Sí", "No"));
            p2.misPreguntas.Add(new Preguntas("Las víctimas del Bullying Psicológico nunca sienten miedo.", "Falso", "Verdadero"));
            p2.misPreguntas.Add(new Preguntas("¿Por qué las personas perciben que las acciones del Bullying Psicológico tarde o temprano se materializarán de una amenaza a algo más contundente?", "Todas las anteriores", "Porque hay sentimientos de indefensión y vulnerabilidad", " Fomentan la sensación de temor", "Porque dañan la autoestima de la víctima", true));
        p2.Barajar();

        PuntosRetro p3 = new PuntosRetro("El Bullying Psicológico es la persecución, intimidación, tiranía, chantaje, manipulación y amenazas al otro.");
        p3.misPreguntas.Add(new Preguntas("¿Qué factor NO  hace parte del Bullying Psicológico?", "Empujones", "Intimidación", "Persecución", "Tiranía", true));
        p3.misPreguntas.Add(new Preguntas("¿El chantaje hace parte de los factores que ocurren en el Bullying Psicológico?", "Sí", "No"));
        p3.misPreguntas.Add(new Preguntas("¿Los golpes pertenecen al Bullying Psicológico?", "Falso", "Verdadero"));
        p3.misPreguntas.Add(new Preguntas("¿El Bullying Psicológico se presenta cuando existe manipulación y amenazas a otra persona?", "Verdadero", "Falso"));
        p3.misPreguntas.Add(new Preguntas("¿Estos factores son comunes en el Bullying Psicológico?", "Manipulación, persecución y amenazas al otro", "Golpes y Gritos", "Chismes", "Ninguna es Correcta", true));
        p3.Barajar();


        PuntosRetro p4 = new PuntosRetro("Para prevenir el Bullying y los problemas que trae es muy  importante el apoyo entre todos los alumnos, que siempre exista el respeto y la tolerancia.");
        p4.misPreguntas.Add(new Preguntas("Para prevenir el Bullying es muy importante que entre los alumnos haya...", "Respeto y Tolerancia", "Odio y Venganza", "Indiferencia", "Enemistades", true));
        p4.misPreguntas.Add(new Preguntas("¿Para prevenir el Bullying todos los alumnos se deben estar en un ambiente de respeto y tolerancia.?", "Sí", "No"));
        p4.misPreguntas.Add(new Preguntas("Para evitar el Bullying lo mejor es no relacionarse con nadie y no tener amigos.", "Falso", "Verdadero"));
        p4.Barajar();

        PuntosRetro p5 = new PuntosRetro("Los observadores del Bullying  deben mostrar una actitud de apertura, comunicación e interés por la víctima. No posicionarse en el lado del acosador y hacer que la víctima se lo cuente a sus padres o personas cercanas, incluso ofertar a ir con él si no esta seguro. ");
        p5.misPreguntas.Add(new Preguntas("¿De qué lado deben de estar los observadores del bullying?", "De la víctima", "Del agresor", "De ninguno", "De la víctima y el agresor", true));
        p5.misPreguntas.Add(new Preguntas("¿Los observadores del Bullying pueden aconsejar a la víctima de que  cuente sus problemas a los padres o personas cercanas?", "Verdadero", "Falso"));
        p5.Barajar();



        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        miNivel.puntosRetro.Add(p3);
        miNivel.puntosRetro.Add(p4);
        miNivel.puntosRetro.Add(p5);

        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------

        EstadoConversacion ec0 = new EstadoConversacion(new int[] {-30, 10, 10 }, new Preguntas("¿Quién te viste? Tu abuelita, ¿no tienes un espejo en tu casa?", "Mejor me voy de Aquí", "¿Tienes algún problema con mi forma de vestir?", "Lo siento si no te gusta, a mí me encanta", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(new int[] { 10, -10, -40 }, new Preguntas("Eres todo un perdedor, que tonto pareces", "Haga el favor de respetar", "Mejor no digo nada", "Mas perdedor será usted", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(new int[] { -10, 10, -30 }, new Preguntas("¿Por qué debería respetarte?", "Porque no existes para mí", "Porque todos merecemos respeto", "Porque también eres un perdedor", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(new int[] { 10, 20, -20 }, new Preguntas("¿Qué fue lo que dijiste?", "No dije nada, disculpame", "Que me encanta mi ropa", "Que también eres un perdedor", "", false));
    


        ec0.AgregarProximos(new int[3] { 0, 1, 1 });
        ec1.AgregarProximos(new int[3] { 2, 0, 3 });
        ec2.AgregarProximos(new int[3] { 1, 2, 3 });
        ec3.AgregarProximos(new int[3] { 0, 1, 3 });
      


        conversacion.estados = new EstadoConversacion[4] { ec0, ec1, ec2, ec3 };



    }
}

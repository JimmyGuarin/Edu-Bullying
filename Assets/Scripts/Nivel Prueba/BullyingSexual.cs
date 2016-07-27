using UnityEngine;
using System.Collections;

public class BullyingSexual : MonoBehaviour {

    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("El Bullying sexual genera un asedio, inducción o abuso sexual o referencias malintencionadas a partes íntimas del cuerpo de la víctima.");
        p1.misPreguntas.Add(new Preguntas("Son factores presentes en el Bullying Sexual.", "Todas son correctas", " Asedio constante a la víctima", "Inducción sexual", "Acoso sexual", true));
        p1.misPreguntas.Add(new Preguntas("¿Las referencias malintencionadas a partes íntimas del cuerpo de una persona es Bullying Sexual?", "Verdadero", "Falso"));
        p1.misPreguntas.Add(new Preguntas("¿Puede considerarse algún tipo de acoso sexual como Bullying Sexual?", "Verdadero", "Falso"));
        p1.misPreguntas.Add(new Preguntas("Es un factor común ante la presencia del Bullying Sexual", "Frases malintencionadas a partes íntimas del cuerpo de una persona", "Chismes y calumnias sobre una persona", "Golpes y amenazas", "Ninguna es Correcta", true));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("El Bullying Sexual Incluye el bullying homófobo, que es cuando el maltrato hace referencia a la orientación sexual de la víctima por motivo de homosexualidad real o imaginaria.");
        p2.misPreguntas.Add(new Preguntas("¿Qué tipo de Bullying puede incluirse dentro del Bullying Sexual?", "Bullying Homófobo", "Bullying Físico", "Bullying Psicológico", "Ninguna es correcta", true));
        p2.misPreguntas.Add(new Preguntas("¿A que hace referencia el Bullying Homófobo?", "Rechazo a la orientación sexual de la víctima", "Comprensión a las otras personas", "Golpes y amenazas", "Todas son correctas",true));
        p2.misPreguntas.Add(new Preguntas("¿Cuándo el maltrato hace referencia a la orientación sexual, ésta puede ser solo imaginaria?", "Verdadero", "Falso"));
        p2.misPreguntas.Add(new Preguntas("¿El rechazo a la orientación sexual por motivo de homosexualidad real, hace parte del Bullying Sexual?", "Verdadero", "Falso"));
        p2.Barajar();

        PuntosRetro p3 = new PuntosRetro("Cuando existe una presión constante para hacer algo que la persona no quiere hacer. Insistir en que la persona haga algo que no quiere, ya sea dar un beso o ver pornografía, es Bullying sexual.");
        p3.misPreguntas.Add(new Preguntas("Es Bullying Sexual insistir en que una persona haga cosas que no quiere cómo ...", "Todas son correctas", "Dar un beso", "Ver pornografía", "Permitir tocar sus partes íntimas", true));
        p3.misPreguntas.Add(new Preguntas("¿Obligar a una persona a dar un beso es Bullying Sexual?", "Sí", "No"));
        p3.misPreguntas.Add(new Preguntas("¿Incitar a una persona que vea pornografía cuando realmente no lo quiere hacer puede considerarse Bullying Sexual?", "Verdadero", "Falso"));
        p3.misPreguntas.Add(new Preguntas("¿La presión constante sobre una persona para hacer algo que no quiere hacer, especialmente acciones como dar un beso o ver pornografía podría considerarse en Bullying Sexual?", "Verdadero", "Falso"));
        p3.Barajar();


        PuntosRetro p4 = new PuntosRetro("Evita la estrategia de confrontación para combatir el Bullying, la cual consiste en tratar  el problema de forma directa, mediante acciones agresivas o potencialmente arriesgadas, que  solo empeoran el conflicto.");
        p4.misPreguntas.Add(new Preguntas("¿ Que tipo de acciones se deben evitar para combatir el Bullying?", "Todas son correctas", "Acciones agresivas", "Enfrentamiento Directo", "Confrontacción",true));
        p4.misPreguntas.Add(new Preguntas("Es cierto que la mejor forma de solucionar el Bullying es por medio de una confrontación directa y con acciones agresivas frente al acosador.", "Falso", "Verdadero"));
        p4.misPreguntas.Add(new Preguntas("Frente a la prevención del acoso escolar ¿cuál acción podría ser efectiva?", "Búsqueda de apoyo social", "Distanciamiento", "Evitación ó escape", "Reevaluación positiva",true));
        p4.Barajar();

        PuntosRetro p5 = new PuntosRetro("Los observadores o testigos presentan unas características especiales, que se convierten en factores de riesgos, ya que se ha visto que frente al fenómeno del bullying se aumentan los sentimientos de sensibilidad y de poca solidaridad en este grupo.");
        p5.misPreguntas.Add(new Preguntas("¿En que se convierten las características de los observadores o testigos del Bullying?", "Factores de riesgos", "Desventajas para las víctimas del Bullying", "Ventajas para las víctimas del Bullying", "Ninguna es correcta", true));
        p5.misPreguntas.Add(new Preguntas("¿Las características especiales de los testigos se convierten en factores de riesgos?", "Sí", "No"));
        p5.misPreguntas.Add(new Preguntas("¿Frente al Bullying disminuyen los sentimientos de sensibilidad y de poca solidaridad?", "No", "Sí"));
        p5.Barajar();





        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        miNivel.puntosRetro.Add(p3);
        miNivel.puntosRetro.Add(p4);
        miNivel.puntosRetro.Add(p5);

        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------

        EstadoConversacion ec0 = new EstadoConversacion(new int[] { -10, 10, -10 }, new Preguntas("¿Te digo algo? me gustaría tocarte", "¿Qué te gustaría tocar?", " Mi cuerpo merece respeto y nadie debe tocarme", "No entiendo lo que dices", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(new int[] { 20, -10, -20 }, new Preguntas("Es que yo deseo tu cuerpo", "Por favor te exigo que me respetes", "Me tienes confundido", "Quiero saber más sobre eso", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(new int[] { -30, 10, -20 }, new Preguntas("Estoy seguro que no te vas a arrepentir", "Me pones a dudarlo", "Por favor no insistas, te digo que no", "Umm, no lo sé", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(new int[] { -10, 10, -10 }, new Preguntas("Nadie se va a enterar", "Voy a pensarlo", "No me gusta tu comportamiento", "Suena interesante", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(new int[] { -10, -20, 10 }, new Preguntas("Se que eres una persona fácil, no mereces respeto", "Me hiciste sentir mal", "Y que te gustaría hacer", "Hablaré con mis amigos y padres, se que me ayudarán", "", false));
       

        ec0.AgregarProximos(new int[3] { 1, 2, 1 });
        ec1.AgregarProximos(new int[3] { 2, 3, 1 });
        ec2.AgregarProximos(new int[3] { 3, 4, 1 });
        ec3.AgregarProximos(new int[3] { 3, 1, 3 });
        ec4.AgregarProximos(new int[3] { 2, 0, 4 });


        conversacion.estados = new EstadoConversacion[5] { ec0, ec1, ec2, ec3, ec4 };



    }
}

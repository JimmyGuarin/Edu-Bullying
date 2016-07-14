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

        EstadoConversacion ec0 = new EstadoConversacion(0, new Preguntas("¿Acaso deseas que te pegue?", "Tal vez", "Quiero hablarte del bullying", "Ya me canse de eso", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(-10, new Preguntas("Pues entonces lo haré", "No por favor", "Haga lo que quiera", "Se lo diré a mi mamá", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(10, new Preguntas("¿Qué es el bullying?", "Es la agresión que tu me haces cada día", "Es pegarle a los otros", "La profesora lo sabe", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(-10, new Preguntas("Y que vas hacer", "Golpearte", "Se lo diré a mi mamá", "Quisiera hablarte un poco del bullying", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(10, new Preguntas("¿Por qué no tendría que hacerlo?", "Por qué voy a hablarte un poco Bullying", "Porque aquí está la profe", "Se lo diré a mi mamá", "", false));
        EstadoConversacion ec5 = new EstadoConversacion(-10, new Preguntas("Te pegaré!!!", "No por favor", "Estoy listo", "La profesora lo sabrá", "", false));
        EstadoConversacion ec6 = new EstadoConversacion(-10, new Preguntas("Pues dígale y verás", "Eso Haré", "Se lo diré a tu mamá", "tal vez", "", false));
        EstadoConversacion ec7 = new EstadoConversacion(10, new Preguntas("Lo que tú sientas me tiene sin cuidado", "Ponte en mis zapatos y te darás cuenta", "Se lo diré a tu mamá", "Ya verás lo que haré", "", false));
        EstadoConversacion ec8 = new EstadoConversacion(10, new Preguntas("Lo siento, intentare hacerlo", "Pronto lo descubrirás", "Se lo diré a tu mamá", "Le diré a la profesora", "", false));

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

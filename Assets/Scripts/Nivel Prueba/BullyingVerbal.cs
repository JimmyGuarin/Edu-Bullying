using UnityEngine;
using System.Collections;

public class BullyingVerbal : MonoBehaviour {


    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("El Bullying Verbal son acciones no corporales con la finalidad de discriminar, difundir chismes o rumores.");
        p1.misPreguntas.Add(new Preguntas("¿Que tipo de acciones que hacen parte del Bullying Verbal?", "No corporales", "Corporales", "Acoso Sexual", "Ninguna es correcta", true));
        p1.misPreguntas.Add(new Preguntas("¿Con que finalidad se presentan las acciones no corporales del Bullying Verbal?", "Todas son correctas", "Discriminar", "Difundir Chismes", "Generar Rumores", true));
        p1.misPreguntas.Add(new Preguntas("¿En el Bullying verbal se presentan discriminación a través de rumores?", "Sí", "No"));
        p1.misPreguntas.Add(new Preguntas("¿Difundir chismes hace parte de las discriminaciones del Bullying Verbal?", "Verdadero", "Falso"));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("Es común en el Bullying verbal realizar acciones de exclusión o bromas insultantes y repetidas del tipo poner apodos, insultar, amenazar, burlarse de los demás.");
        p2.misPreguntas.Add(new Preguntas("¿Es una de las acciones más comunes en el Bullying Verbal?", "Bromas Insultantes", "Golpes", " Intimidación", "Ninguna es correcta", true));
        p2.misPreguntas.Add(new Preguntas("¿Realizar acciones de exclusión a través de bromas insultantes hace parte del Bullying verbal?", "Sí", "No"));
        p2.misPreguntas.Add(new Preguntas("¿Poner apodos a los compañeros puede considerarse Bullying verbal?", "Sí", "No"));
        p2.misPreguntas.Add(new Preguntas("¿Las acciones más comunes en el Bullying Verbal son?", "Todas son correctas", "Insultar", "Amenazar", " Burlarse de los demás", true));
        p2.Barajar();


        PuntosRetro p3 = new PuntosRetro("En el Bullying Verbal se generan rumores de carácter racista o sexual, calumnias. Es más utilizado por algunas chicas a medida que se van acercando a la adolescencia.");
        p3.misPreguntas.Add(new Preguntas("¿Los rumores generados en el Bullying Verbal pueden ser?", "Todas son correctas", "De carácter racista", "Sexuales", "Calumnias", true));
        p3.misPreguntas.Add(new Preguntas("El Bullying Verbal es más común en ...", "Mujeres", "Hombres", "Profesores", "Padres", true));
        p3.misPreguntas.Add(new Preguntas("¿Se puede afirmar que los rumores sexuales sobre un compañero es Bullying Verbal?", "Sí", "No"));
        p3.misPreguntas.Add(new Preguntas("¿Hacer comentarios de carácter racista puede considerarse Bullying Verbal?", "Sí", "No"));
        p3.Barajar();


        PuntosRetro p4 = new PuntosRetro("Asertividad: “Es uno de los camino hacia la  autoestima, hacia la capacidad de relacionarse con los demás de igual a igual, no estando ni por encima ni por debajo. Sólo quien posee una alta autoestima, quien se aprecia y valora a sí mismo, podrá relacionarse con los demás en el mismo plano.”");
        p4.misPreguntas.Add(new Preguntas("¿Cuando se puede considerar que una persona es asertiva?", "Se valora a sí mismo y se relaciona con los demás de igual a igual", "Tiene adecuado desempeño académico y disciplinado", "Tiene buenos amigos y es expresivo", "No genera conflicto y es dócil", true));
        p4.misPreguntas.Add(new Preguntas("Ser una persona asertiva puede ayudar a solucionar los conflictos del Bullying", "Verdadero", "Falso"));
        p4.misPreguntas.Add(new Preguntas("La asertividad es uno de los caminos para mejorar el autoestima", "Verdadero", "Falso"));
        p4.Barajar();

        PuntosRetro p5 = new PuntosRetro("El Dialogo y la búsqueda de apoyo social a través de tu profesora, amigos o familiares, puede ser la manera efectiva de enfrentarse al acosador del Bullying.");
        p5.misPreguntas.Add(new Preguntas("¿Cual puede ser la forma mas efectiva de solucionar el Bullying?", "El Dialogo y búsqueda de apoyo social", "La Confrontación directa del conflicto", "Golpear a tu agresor", "Todas son correctas", true));
        p5.misPreguntas.Add(new Preguntas("¿Hablar en presencia de tu profesora, amigos o familiares con un agresor podría ayudar a solucionar el conflicto de una forma sencilla?", "Sí", "No"));
        p5.misPreguntas.Add(new Preguntas("¿Dialogar solo empeora el conflicto con el agresor?", "Falso", "Verdadero"));
        p5.Barajar();





        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        miNivel.puntosRetro.Add(p3);
        miNivel.puntosRetro.Add(p4);
        miNivel.puntosRetro.Add(p5);


        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------

        EstadoConversacion ec0 = new EstadoConversacion(new int[] { -10, -10, 10 }, new Preguntas("Miren quien llego, el tanque de guerra del colegio", "Es cierto, llego el tanque de guerra", "Mejor no digo nada", "Que comentario tan de mal gusto", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(new int[] { -20, -10, 20 }, new Preguntas("El Chupamedias de la profesora, el sapo del salón", "¿Cuál es tu problema, quieres problemas o qué?", "No digo nada, mejor me voy", "Lo que haces está mal, te exijo respeto", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(new int[] { 10, -40, -30 }, new Preguntas("Jajaja, no te voy a respetar Chupamedias", "Hablaré con mis padres y profesores para que me ayuden", "Entonces también voy a ponerte apodos", "Mejor voy a dejar de hablarte", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(new int[] { 10, -30, -20 }, new Preguntas("¿No te gustó? pues demalas", "Hablaré con mis padres y profesores para que me ayuden", "Mejor me voy del colegio", "Le dire todo a la profesora", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(new int[] { -10, -10, 10 }, new Preguntas("No ganarás nada con eso","Entonces respetame", "Te veré llorando", "Es la mejor manera de solucionar este asunto", "", false));
        EstadoConversacion ec5 = new EstadoConversacion(new int[] { -10, 30, -10 }, new Preguntas("Sí, vete mejor", "Eso haré", "De verdad respetame", "Te veré llorando bobo", "", false));

        ec0.AgregarProximos(new int[3] { 1, 1, 3 });
        ec1.AgregarProximos(new int[3] { 1, 5, 2 });
        ec2.AgregarProximos(new int[3] { 4, 2, 5 });
        ec3.AgregarProximos(new int[3] { 4, 5, 1 });
        ec4.AgregarProximos(new int[3] { 2, 3, 4 });
        ec5.AgregarProximos(new int[3] { 5, 2, 5 });


        conversacion.estados = new EstadoConversacion[6] { ec0, ec1, ec2, ec3, ec4, ec5};



    }
}


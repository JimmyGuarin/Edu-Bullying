using UnityEngine;
using System.Collections;

public class CyberBullying : MonoBehaviour {

    public Nivel miNivel;
    public MaquinaEstadosConver conversacion;


    void Awake()
    {
        //Creando Motor de preguntas del Nivel--------------------------------------------
        miNivel = new Nivel();

        PuntosRetro p1 = new PuntosRetro("El Bullying Cibernético es un tipo de acoso muy grave y preocupante por la gran visibilidad y alcance que se logra de los actos de humillación contra la víctima y el anonimato en que pueden permanecer los acosadores.");
            p1.misPreguntas.Add(new Preguntas("¿Qué es lo más preocupante del Bullying Cibernético?", "Todas son correctas", "El alcance que se logra", "La gran visibilidad", "Los actos de humillación", true));
            p1.misPreguntas.Add(new Preguntas("¿No hay Anonimato en el Bullying Cibernético?", "Falso", "Verdadero"));
            p1.misPreguntas.Add(new Preguntas("¿El Anonimato que pueden tener los acosadores en el Bullying Cibernético es uno de los factores más preocupantes?", "Verdadero", "Falso"));
            p1.misPreguntas.Add(new Preguntas("Otros factores del Bullying Cibernético pueden ser...", " Ninguno es correcto", "Los golpes y amenazas", "Indiferencias", "La intimidación y vulnerabilidad", true));
        p1.Barajar();

        PuntosRetro p2 = new PuntosRetro("Los canales de trasmisión del Bullying Cibernético son muy variados: mensajes de texto en móviles, tabletas y ordenadores, páginas web y blogs, juegos online, correos electrónicos, chats, encuestas online de mal gusto, redes sociales, suplantación de identidad para poner mensajes etc.");
            p2.misPreguntas.Add(new Preguntas("Es uno de los canales de trasmisión del Bullying Cibernético.", "Correos electrónicos", "Cartas", "Voz a voz", "Ninguna es correcta", true));
            p2.misPreguntas.Add(new Preguntas("¿Existe la suplantación de identidad en el Bullying Cibernético?", "Sí", "No"));
            p2.misPreguntas.Add(new Preguntas("¿Son los chats tan seguros como para evitar el Bullying Cibernético?", "No", "Sí"));
            p2.misPreguntas.Add(new Preguntas("¿El Bullying Cibernético solo incluye eliminar o bloquear a alguien de las redes sociales?", "No", "Sí"));
            p2.misPreguntas.Add(new Preguntas("¿Dónde podrían encontrarse con Bullying Cibernético?", "Todas son Correctas", "Redes Sociales", "Juegos Online", "Páginas web o Blogs", true));
        p2.Barajar();

        PuntosRetro p3 = new PuntosRetro("El contenido del acoso va desde los típicos insultos a montajes fotográficos o de vídeo de mal gusto, imágenes inadecuadas de la víctima tomadas sin su permiso, críticas respecto al origen, religión, el nivel socioeconómico de la víctima o de sus familiares y amigos, etc. Todo vale con el fin de humillarla.");
            p3.misPreguntas.Add(new Preguntas("¿Qué tipo de contenido está presente en el acoso de las víctimas en el Bullying Cibernético?", "Todas son correctas", "Montajes fotográficos", "Videos de mal gusto", "Críticas respecto a la religión de la víctima", true));
            p3.misPreguntas.Add(new Preguntas("¿Fotografiar una persona sin su permiso y después utilizar las imágenes con insultos o montajes fotográficos es Bullying Cibernético?", "Sí", "No"));
            p3.misPreguntas.Add(new Preguntas("¿Puede encontrarse el Bullying Cibernético en las conversaciones en persona?", "No", "Sí"));
            p3.misPreguntas.Add(new Preguntas("¿Se puede usar el nivel socioeconómico de  los familiares o amigos de una víctima para humillarla a través del Bullying Cibernético?", "Verdadero", "Falso"));
        p3.Barajar();

        PuntosRetro p4 = new PuntosRetro("El Bullying causa  daños  muy profundos en la persona afectada, pero también sobre la persona que agrede y los compañeros que se acostumbran a vivir aceptando la violencia como parte de la vida cotidiana.");
            p4.misPreguntas.Add(new Preguntas("¿Qué personas son afectadas a causa del Bullying?", "Todas son correctas", "Las víctimas", "Los agresores", "Los compañeros que aceptan la violencia", true));
            p4.misPreguntas.Add(new Preguntas("Los compañeros que son testigos del Bullying y aceptan la violencia como parte de su vida no reciben ningún daño  a causa del Bullying.", "Sí, reciben daños psicológicos", "No, son insensibles al Bullying"));
            p4.misPreguntas.Add(new Preguntas("¿Cuando se presenta actos de Bullying entre dos compañeros lo mejor es aceptar esa violencia como parte de la vida cotidiana?", "No", "Sí"));
        p4.Barajar();


        PuntosRetro p5 = new PuntosRetro("La cooperación por parte del colegio(directores, profesores) junto a la de los padres es la única vía para salir del círculo vicioso del bullying.");
            p5.misPreguntas.Add(new Preguntas("¿Quiénes deben cooperar para salir del círculo vicioso del bullying?", "El colegio(directores, profesores) y padres de familia", "Los padres de la víctima", "Los padres del agresor", "Los directores y profesores", true));
            p5.misPreguntas.Add(new Preguntas("El Bullying  se debe de resolver sin la cooperación del colegio y los padres de familia", "Falso","Verdadero"));
        p5.Barajar();


        miNivel.puntosRetro.Add(p1);
        miNivel.puntosRetro.Add(p2);
        miNivel.puntosRetro.Add(p3);
        miNivel.puntosRetro.Add(p4);
        miNivel.puntosRetro.Add(p5);

        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro = miNivel.puntosRetro;
        GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().Barajar();

        //Creando Sistema de conversación del nivel------------------------------------------------------------------------------------------

        EstadoConversacion ec0 = new EstadoConversacion(new int[] { -20, -10, 10 }, new Preguntas("Ya subí a internet el video de la broma que te hice, JAJAJA", "Escribiré en Twitter sobre eso", "Mejor no hablaré sobre ese tema", "Te pido por favor que elimines eso", "", false));
        EstadoConversacion ec1 = new EstadoConversacion(new int[] { -10, 20, -10 }, new Preguntas("Ya verás, serás la burla en Facebook", "Entonces te haré lo mismo a ti", "Respetame por favor", "Escribiré en Twitter lo que haces", "", false));
        EstadoConversacion ec2 = new EstadoConversacion(new int[] { -20, 10, 10 }, new Preguntas("No, me divierto burlandome de ti", "Eres un bobo, no te saldrás con la tuya", "Te voy a bloquear y denunciar", "Hablaré con mis padres y profesores", "", false));
        EstadoConversacion ec3 = new EstadoConversacion(new int[] { 10, -30, 10 }, new Preguntas("No tienes forma de probar mis amenazas", "Mis padres y profesores me ayudarán", "La verdad no lo sé", "Se cómo guardar las conversaciones", "", false));
        EstadoConversacion ec4 = new EstadoConversacion(new int[] { 10, -10, -10 }, new Preguntas("Escribiré en tu muro que tienes una enfermedad de transmisión sexual", "Voy a bloquearte por lo que haces", "Yo escribiré lo mismo de ti", "Te ganaste un enemigo", "", false));
        EstadoConversacion ec5 = new EstadoConversacion(new int[] { -10, 10, -10 }, new Preguntas("Todo lo que escribes por Twitter son tonterías", "Arruinaré tu vida, te odio", "Por favor respeta mis opiniones como respeto las tuyas", "Te pagaré de la misma manera", "", false));
       

        ec0.AgregarProximos(new int[3] { 5, 1, 2 });
        ec1.AgregarProximos(new int[3] { 4, 2, 5 });
        ec2.AgregarProximos(new int[3] { 1, 3, 3 });
        ec3.AgregarProximos(new int[3] { 3, 1, 3 });
        ec4.AgregarProximos(new int[3] { 1, 4, 4 });
        ec5.AgregarProximos(new int[3] { 5, 1, 5 });




        conversacion.estados = new EstadoConversacion[6] { ec0, ec1, ec2, ec3, ec4, ec5};



    }
}


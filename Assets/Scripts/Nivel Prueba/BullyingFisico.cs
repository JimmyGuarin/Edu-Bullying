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

        PuntosRetro p1 = new PuntosRetro("El Bullying Físico es el tipo de acoso más común, especialmente entre hombres.");
            p1.misPreguntas.Add(new Preguntas("¿Cuál es el tipo de acoso más común?", "Bullying Físico", "Bullying Sexual", "Bullying Verbal", "CyberBullying",true));
            p1.misPreguntas.Add(new Preguntas("¿Los hombres hacen más Bullying físico que las Mujeres?", "Verdadero", "Falso"));
            p1.misPreguntas.Add(new Preguntas("¿Se puede afirmar que las mujeres realizan acoso de tipo Bullying Físico más que los hombres?", "No", "Sí"));
            p1.misPreguntas.Add(new Preguntas("El Bullying Físico es más común en...", "Hombres", "Mujeres", "Profesores", "Rectores", true));
            p1.Barajar();

		PuntosRetro p2 = new PuntosRetro("El Bullying Físico Incluye golpes, empujones e incluso palizas entre uno o varios agresores contra una sola víctima.");
            p2.misPreguntas.Add(new Preguntas("¿Qué factores se presentan en el Bullying físico?", "Golpes, empujones o palizas", "Chismes y calumnias", "Timidez al hablar con los compañeros", "Insultos y gritos", true));
            p2.misPreguntas.Add(new Preguntas("¿El Bullying Físico se presenta generalmente contra una sola víctima?", "Verdadero", "Falso"));
            p2.misPreguntas.Add(new Preguntas("¿Cuántos agresores pueden participar en el Bullying Físico?", "Todas las respuestas son correctas", "Dos", "Tres o más", "Uno", true));
            p2.misPreguntas.Add(new Preguntas("¿Los empujones hacen parte del Bullying Físico?", "Sí", "No"));
            p2.Barajar();

        PuntosRetro p3 = new PuntosRetro("El robo o daño intencionados de las pertenencias de las víctimas también ocurre ocasionalmente en el Bullying Físico.");
            p3.misPreguntas.Add(new Preguntas("Cuándo se produce el Bullying Físico ocasionalmente puede presentarse...", "Robo o daño intencionado a las pertenencias de la víctima.", "Chismes difundidos entre los compañeros de clases", "Intimidación y generación de miedo", "Gritos delante de los compañeros", true));
            p3.misPreguntas.Add(new Preguntas("¿En el bullying físico se produce robo intencionado de las pertenencias de las víctimas?", "Verdadero", "Falso"));
            p3.misPreguntas.Add(new Preguntas("¿Se presenta daño a las pertenencias de las víctimas en el Bullying Físico?", "Verdadero", "Falso"));
            p3.Barajar();

        PuntosRetro p4 = new PuntosRetro("Las características de  personas que son víctimas de Bullying generalmente son: timidez, inseguridad, ansiedad, sobreprotegidos por sus padres o complexión débil.");
            p4.misPreguntas.Add(new Preguntas("¿Cual es una caracteristica común en las víctimas del Bullying?", "Timidez e inseguridad", "Complexion fuerte", "Negativa hacia la escuela", "Todas son correctas", true));
            p4.misPreguntas.Add(new Preguntas("¿Las víctimas del Bullying se sienten descuidados por sus padres?", "No", "Sí"));
            p4.misPreguntas.Add(new Preguntas("¿La ansiedad está presente en las víctimas del Bullying?", "Sí", "No"));

        PuntosRetro p5 = new PuntosRetro("Algunas características de los agresores son: Actitud negativa a la escuela, poca empatía, son impulsivos, les cuesta aceptar las normas sociales, poseen conflictos en sus hogares.");
            p5.misPreguntas.Add(new Preguntas("¿Cual es una característica común en los agresores en el Bullying?", "Poseen conflictos en sus hogares", "Son personas timidas", "Poseen baja autoestima", "Ninguna es correcta",true));
            p5.misPreguntas.Add(new Preguntas("¿Los Agresores del Bullying tienen actitud positiva hacia la escuela?", "No", "Sí"));
            p5.misPreguntas.Add(new Preguntas("¿El conflicto familiar puede ser una causa del Bullying ?","Sí","No"));


    



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

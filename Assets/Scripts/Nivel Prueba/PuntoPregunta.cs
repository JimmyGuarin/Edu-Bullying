using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PuntoPregunta : MonoBehaviour
{
    
    public int[] puntosRetro;
    private ArrayList misPreguntas;
    private int preguntaActualIndex;
    private Preguntas preguntaActual;
    private Button[] respuestas;
    public int puntajePreguntaMultiple;
    public int puntajePreguntaDual;
    private int puntajePregunta;
    
    public GameObject[] objetosAnimados;

    [Tooltip("Canvas de las preguntas multiples")]
    public GameObject canvasPreguntaMultiple;
    public Text enunciadoPreguntaMultiple;
    public Button[] respuestasMultiples;
    public GameObject botonCerrarMultiple;
    public Text textoPuntajeMultiple;
    public Text textoRetroAlimentacionMultiple;


    public GameObject canvasPreguntaDual;
    public Text enunciadoPreguntaDual;
    public Button[] respuestasDual;
    public GameObject botonCerrarDual;
    public Text textoPuntajeDual;
    public Text textoRetroAlimentacionDual;

    [Tooltip("Ingrese aquí el texto a mostrar en el presiona F.")]
    public string textoPresionaFPanel;
    public GameObject presionarFPanel;
    

    public bool enColision;


    void Start()
    {
        preguntaActualIndex = 0;
        enColision = false;
        misPreguntas = new ArrayList();

        PuntosRetro pR;
		ManejadorPreguntas puntosRetroAlimentacion =GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>();

        for (int i = 0; i < puntosRetro.Length; i++)
        {
            
            pR = (PuntosRetro)puntosRetroAlimentacion.misPuntosRetro[puntosRetro[i]];

            for (int j = 0; j < pR.misPreguntas.Count; j++)
            {

                misPreguntas.Add(pR.misPreguntas[j]);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        if (enColision){

            if (Input.GetKeyDown("f"))
            {
                Time.timeScale = 0;
                presionarFPanel.SetActive(false);
                Mostrar();
                GetComponent<Collider2D>().enabled = false;
                enColision = false;
            }
        }
    }

	public void activarPuntoPregunta(){
	
		presionarFPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = textoPresionaFPanel;
		presionarFPanel.SetActive(true);
		enColision = true;

	}
    
	public void desactivarPuntoPregunta(){
	
		presionarFPanel.SetActive(false);
		enColision = false;
	}
		

    public void Mostrar()
    {
        preguntaActual = (Preguntas)misPreguntas[preguntaActualIndex];


        if (preguntaActual.IsMultiple)
        {
            enunciadoPreguntaMultiple.text = preguntaActual.Enunciado;
            respuestas = respuestasMultiples;
            canvasPreguntaMultiple.SetActive(true);
            puntajePregunta =puntajePreguntaMultiple;

        }
        else
        {
            enunciadoPreguntaDual.text = preguntaActual.Enunciado;
            respuestas = respuestasDual;
            puntajePregunta = puntajePreguntaDual;
            canvasPreguntaDual.SetActive(true);
        }

        for (int i = 0; i < preguntaActual.Respuestas.Length; i++)
        {

            respuestas[i].transform.GetChild(0).GetComponent<Text>().text = preguntaActual.Respuestas[i];
        }

    }

    //Devuelve el puntajeObtenido con la respuesta
    //0 Si la respuesta es erronea
    public int VerificarRespuesta(Button botonPrecionado)
    {
        //Verde bien, rojo mal
        Color colorRespuesta;

        if (preguntaActual.EsCorrecta(botonPrecionado.transform.GetChild(0).GetComponent<Text>().text))
        {

            botonPrecionado.GetComponent<Image>().color = Color.green;
            textoRetroAlimentacionMultiple.text = "Has respondido Correctamente ésta pregunta";
            textoRetroAlimentacionDual.text = "Has respondido Correctamente ésta pregunta";

        }
        else
        {
            botonPrecionado.GetComponent<Image>().color = Color.red;
            respuestas[preguntaActual.IndexCorreta()].GetComponent<Image>().color = Color.green;
            puntajePregunta=0;
            textoRetroAlimentacionMultiple.text = "Respuesta Erronea";
            textoRetroAlimentacionDual.text = "Respuesta Erronea";


        }

        colorRespuesta = botonPrecionado.GetComponent<Image>().color;

        if (preguntaActual.IsMultiple){

            textoPuntajeMultiple.text = "Puntaje Obtenido: " + puntajePregunta;       
            textoPuntajeMultiple.transform.parent.gameObject.SetActive(true);
            textoPuntajeMultiple.transform.parent.gameObject.GetComponent<Image>().color = colorRespuesta;
            textoRetroAlimentacionMultiple.transform.parent.gameObject.SetActive(true);
            textoRetroAlimentacionMultiple.transform.parent.gameObject.GetComponent<Image>().color = colorRespuesta;
            botonCerrarMultiple.SetActive(true);
        }
        else
        {
            textoPuntajeDual.text = "Puntaje Obtenido: " + puntajePregunta;
            textoPuntajeDual.transform.parent.gameObject.SetActive(true);
            textoPuntajeDual.transform.parent.gameObject.GetComponent<Image>().color = colorRespuesta;
            textoRetroAlimentacionDual.transform.parent.gameObject.SetActive(true);
            textoRetroAlimentacionDual.transform.parent.gameObject.GetComponent<Image>().color = colorRespuesta;
            botonCerrarDual.SetActive(true);

        }

        preguntaActualIndex++;
        if (preguntaActualIndex >= misPreguntas.Count)
            preguntaActualIndex = 0;
        preguntaActual = (Preguntas)misPreguntas[preguntaActualIndex];
        return puntajePregunta;

    }
    
    public void AnimarObjetos(){

        foreach (GameObject g in objetosAnimados)
        {

            g.GetComponent<Animation>().Play();
        }
    }

    public void cualquierCosa()
    {
        Button b=GetComponent<Button>();
        b.onClick.RemoveAllListeners();
        b.onClick.AddListener(() => { AnimarObjetos(); });
    }
}

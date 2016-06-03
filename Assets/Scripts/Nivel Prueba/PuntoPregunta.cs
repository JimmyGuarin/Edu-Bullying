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

    //Sonidos
    private AudioSource[] audios;


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

    public GameObject canvasHijo;
    

    public bool enColision;

    private Animator animator;

    void Start()
    {
        preguntaActualIndex = 0;
        enColision = false;
        misPreguntas = new ArrayList();
        animator = GetComponent<Animator>();
        audios = GameObject.Find("CanvasPreguntas").GetComponents<AudioSource>();
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
                canvasHijo.SetActive(false);
                audios[0].Play();
                Mostrar();
                GetComponent<Collider2D>().enabled = false;
                enColision = false;
            }
        }
    }

	public void activarPuntoPregunta(){

        canvasHijo.SetActive(true);
        canvasHijo.GetComponent<Animator>().SetBool("Salida", false);
        enColision = true;

	}
    
	public void desactivarPuntoPregunta(){

        canvasHijo.GetComponent<Animator>().SetBool("Salida", true);
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
        botonPrecionado.transform.GetChild(0).GetComponent<Text>().color = Color.white;

        if (preguntaActual.EsCorrecta(botonPrecionado.transform.GetChild(0).GetComponent<Text>().text))
        {

            botonPrecionado.GetComponent<Image>().color = Color.green;
            textoRetroAlimentacionMultiple.text= "Respuesta Correcta:    <size=60><color=green>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            textoRetroAlimentacionDual.text= "Respuesta Correcta:    <size=60><color=green>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            audios[1].Play();
        }
        else
        {
            botonPrecionado.GetComponent<Image>().color = Color.red;
            puntajePregunta=0;
            textoRetroAlimentacionMultiple.text = "Respuesta Correcta:    <size=60><color=green>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            textoRetroAlimentacionDual.text = "Respuesta Correcta:    <size=60><color=green>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            audios[2].Play();
        }

        if (preguntaActual.IsMultiple){

            textoPuntajeMultiple.text = "Puntaje Obtenido:    <size=60><color=green>" +puntajePregunta+ "</color></size>";
            textoPuntajeMultiple.transform.parent.gameObject.SetActive(true);
            textoRetroAlimentacionMultiple.transform.parent.gameObject.SetActive(true);
            botonCerrarMultiple.SetActive(true);
        }
        else
        {
            textoPuntajeDual.text = "Puntaje Obtenido:    <size=60><color=green>" + puntajePregunta + "</color></size>";
            textoPuntajeDual.transform.parent.gameObject.SetActive(true);
            textoRetroAlimentacionDual.transform.parent.gameObject.SetActive(true);
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

    public char RespuestaCorrecta(int index)
    {
        switch (index)
        {
            case 0:
                return 'A';
            case 1:
                return 'B';
            case 2:
                return 'C';
            case 3:
                return 'D';

        }
        return 'E';

    }

    
}

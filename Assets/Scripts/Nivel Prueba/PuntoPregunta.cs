using UnityEngine;
using UnityEngine.EventSystems;
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
    public AudioSource audioFondo;


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


   

    void Start()
    {
        preguntaActualIndex = 0;
        enColision = false;
        misPreguntas = new ArrayList();
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoPersonaje>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorColisiones>().sonidosPersonaje[2].Stop();
                HideMouse.SetCursorPos(Screen.width/2,Screen.height/4);
                canvasHijo.SetActive(false);
                audios[0].Play();
                Mostrar();
                GetComponent<Collider2D>().enabled = false;
                enColision = false;
                audioFondo.volume = 0.02f;



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

        Invoke("KeyEventSelectButton", 0.5f);

        if (preguntaActual.IsMultiple)
        {

            enunciadoPreguntaMultiple.text = preguntaActual.Enunciado;
            respuestas = respuestasMultiples;
            canvasPreguntaMultiple.SetActive(true);
            canvasPreguntaMultiple.GetComponent<Animator>().enabled = true;
            canvasPreguntaMultiple.GetComponent<Animator>().SetTrigger("Abrir");
            puntajePregunta =puntajePreguntaMultiple;
          

        }
        else
        {
          
            enunciadoPreguntaDual.text = preguntaActual.Enunciado;
            respuestas = respuestasDual;
            puntajePregunta = puntajePreguntaDual;
            canvasPreguntaDual.SetActive(true);
            canvasPreguntaDual.GetComponent<Animator>().enabled = true;
            canvasPreguntaDual.GetComponent<Animator>().GetComponent<Animator>().SetTrigger("Abrir");
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
            textoRetroAlimentacionMultiple.text= "Respuesta Correcta:    <size=60><color=black>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            textoRetroAlimentacionDual.text= "Respuesta Correcta:    <size=60><color=black>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            audios[1].Play();
           
        }
        else
        {
            if(puntajePreguntaDual>5&&puntajePreguntaMultiple>0)
            {
                puntajePreguntaDual -= 5;
                puntajePreguntaMultiple -= 5;
            }
            else
            {
                puntajePreguntaDual = 5;
                puntajePreguntaMultiple = 5;
            }


            botonPrecionado.GetComponent<Image>().color = Color.red;
            puntajePregunta=0;
            textoRetroAlimentacionMultiple.text = "Respuesta Correcta:    <size=60><color=black>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            textoRetroAlimentacionDual.text = "Respuesta Correcta:    <size=60><color=black>" + RespuestaCorrecta(preguntaActual.IndexCorreta()) + "</color></size>";
            audios[2].Play();
        }

        if (preguntaActual.IsMultiple){

            textoPuntajeMultiple.text = "Puntaje Obtenido:    <size=64><color=black>" +puntajePregunta+ "</color></size>";
            textoPuntajeMultiple.transform.parent.gameObject.SetActive(true);
            textoRetroAlimentacionMultiple.transform.parent.gameObject.SetActive(true);
            botonCerrarMultiple.SetActive(true);
            EventSystem.current.SetSelectedGameObject(botonCerrarMultiple);
        }
        else
        {
            textoPuntajeDual.text = "Puntaje Obtenido:    <size=64><color=black>" + puntajePregunta + "</color></size>";
            textoPuntajeDual.transform.parent.gameObject.SetActive(true);
            textoRetroAlimentacionDual.transform.parent.gameObject.SetActive(true);
            botonCerrarDual.SetActive(true);
            EventSystem.current.SetSelectedGameObject(botonCerrarDual);

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

    
    public void KeyEventSelectButton()
    {
        if (preguntaActual.IsMultiple)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(respuestasMultiples[0].gameObject);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(respuestasDual[0].gameObject);
        }
       
    }
    
}

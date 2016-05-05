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
    public GameObject[] objetosAnimados;

    public GameObject canvasPreguntaMultiple;
    public Text enunciadoPreguntaMultiple;
    public Button[] respuestasMultiples;
    public GameObject botonCerrarMultiple;

    public GameObject canvasPreguntaDual;
    public Text enunciadoPreguntaDual;
    public Button[] respuestasDual;
    public GameObject botonCerrarDual;

    public GameObject presionarFPanel;

    public bool enColision;


    void Start()
    {
        preguntaActualIndex = 0;
        enColision = false;
        misPreguntas = new ArrayList();

        PuntosRetro pR;
        for (int i = 0; i < puntosRetro.Length; i++)
        {

            pR = (PuntosRetro)Camera.main.GetComponent<Bullying>().misPuntosRetro[puntosRetro[i]];

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

    public void OnTriggerStay2D(Collider2D collision)
    {
        presionarFPanel.SetActive(true);
        enColision = true;
    
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

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

        }
        else
        {
            enunciadoPreguntaDual.text = preguntaActual.Enunciado;
            respuestas = respuestasDual;
            canvasPreguntaDual.SetActive(true);
        }

        for (int i = 0; i < preguntaActual.Respuestas.Length; i++)
        {

            respuestas[i].transform.GetChild(0).GetComponent<Text>().text = preguntaActual.Respuestas[i];
        }

    }

    public bool VerificarRespuesta(Button botonPrecionado)
    {
        bool respuesta;

        if (preguntaActual.EsCorrecta(botonPrecionado.transform.GetChild(0).GetComponent<Text>().text))
        {

            botonPrecionado.GetComponent<Image>().color = Color.green;
            respuesta= true;

        }
        else
        {
            botonPrecionado.GetComponent<Image>().color = Color.red;
            respuestas[preguntaActual.IndexCorreta()].GetComponent<Image>().color = Color.green;
            respuesta = false;

        }

        botonCerrarMultiple.SetActive(true);
        botonCerrarDual.SetActive(true);

        preguntaActualIndex++;
        if (preguntaActualIndex >= misPreguntas.Count)
            preguntaActualIndex = 0;
        preguntaActual = (Preguntas)misPreguntas[preguntaActualIndex];
        return respuesta;

    }
    
    public void AnimarObjetos(){

        foreach (GameObject g in objetosAnimados)
        {

            g.GetComponent<Animator>().enabled = true;
        }
    }
}

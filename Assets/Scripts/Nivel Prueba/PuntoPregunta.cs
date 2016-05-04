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

    public GameObject canvasPreguntaMultiple;
    public Text enunciadoPreguntaMultiple;
    public Button [] respuestasMultiples;
   

    public GameObject canvasPreguntaDual;
    public Text enunciadoPreguntaDual;
    public Button [] respuestasDual;
  
   





    void Start() {
        preguntaActualIndex = 0;
        misPreguntas = new ArrayList();

        PuntosRetro pR;
        for(int i = 0; i < puntosRetro.Length; i++){

            pR =(PuntosRetro) Camera.main.GetComponent<Bullying>().misPuntosRetro[puntosRetro[i]];

            for(int j = 0; j < pR.misPreguntas.Count; j++){

                misPreguntas.Add(pR.misPreguntas[j]);
            }
        }
    }

    // Update is called once per frame
    void Update(){

        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyUp("f"))
        {

            Debug.Log("Presiono");


        }
    }

   
    public void Mostrar()
    {
        preguntaActual = (Preguntas)misPreguntas[preguntaActualIndex];
      

        if (preguntaActual.IsMultiple) {
            enunciadoPreguntaMultiple.text = preguntaActual.Enunciado;
            respuestas = respuestasMultiples;

        }
        else {
            enunciadoPreguntaMultiple.text = preguntaActual.Enunciado;
            respuestas = respuestasDual;
        }

        for(int i = 0; i < preguntaActual.Respuestas.Length; i++) {

            respuestas[i].transform.GetChild(0).GetComponent<Text>().text = preguntaActual.Respuestas[i];
        }

    }

    public void VerificarRespuesta(Button botonPrecionado)
    {
        if(preguntaActual.EsCorrecta(botonPrecionado.transform.GetChild(0).GetComponent<Text>().text))  {

            botonPrecionado.GetComponent<Image>().color = Color.green;
        }
        else
        {
            botonPrecionado.GetComponent<Image>().color = Color.red;
            respuestas[preguntaActual.IndexCorreta()].GetComponent<Image>().color = Color.green;
        }

        preguntaActual = (Preguntas)misPreguntas[++preguntaActualIndex];

    }
}

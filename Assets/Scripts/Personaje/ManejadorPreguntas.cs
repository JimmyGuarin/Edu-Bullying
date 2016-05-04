using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManejadorPreguntas : MonoBehaviour
{
    private PuntoPregunta PuntoDePregunta;
    private bool EsCorrecta;

    public Image[] coloresBotones;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PuntoPregunta"))
        {
            PuntoDePregunta = collision.GetComponent<PuntoPregunta>();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
            
    }


    public void VerificarRespuesta(Button boton)
    {
        if (PuntoDePregunta != null)
        {
           EsCorrecta=PuntoDePregunta.VerificarRespuesta(boton);
        }
    }

    public void ManejarTiempo()
    {
        Time.timeScale = 1;
        if (PuntoDePregunta != null)
        {
            if (PuntoDePregunta.GetComponent<Collider2D>() != null)
                PuntoDePregunta.GetComponent<Collider2D>().enabled = true;           
        }
        ResetearCanvas();
        if (EsCorrecta)
        {
            PuntoDePregunta.AnimarObjetos();
            Destroy(PuntoDePregunta);
        }
           
        
    }

    public void ResetearCanvas()
    {
        foreach(Image b in coloresBotones){

            b.color = Color.white;
            b.GetComponent<Button>().interactable = true;
        }
    }
}

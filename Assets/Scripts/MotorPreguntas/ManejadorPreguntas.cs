using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManejadorPreguntas : MonoBehaviour
{
    
    private PuntoPregunta PuntoDePregunta;
    public GameObject bombillas;
    public Image[] coloresBotones;
    public ArrayList misPuntosRetro;
    public Slider BarraConocimiento;
    public Text textoPuntajeTotal;
    public static int puntajeTotal;
    public int puntajePuntoPregunta;
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
           puntajePuntoPregunta=PuntoDePregunta.VerificarRespuesta(boton);
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
        if (puntajePuntoPregunta>0)
        {
            PuntoDePregunta.AnimarObjetos();
            bombillas.SetActive(true);
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


    public void Barajar()
    {
        for (int i = 0; i < misPuntosRetro.Count; i++)
        {
            PuntosRetro temp = (PuntosRetro)misPuntosRetro[i];
            int randomIndex = Random.Range(0, misPuntosRetro.Count);
            misPuntosRetro[i] = misPuntosRetro[randomIndex];
            misPuntosRetro[randomIndex] = temp;

        }
    }

    public void AumentarPuntaje()
    {
        puntajeTotal += puntajePuntoPregunta;
        textoPuntajeTotal.text = ""+puntajeTotal;
        StartCoroutine("AumentarConocimiento");
    }

    IEnumerator AumentarConocimiento()
    {
        int valor = puntajePuntoPregunta;

        while (valor > 0)
        {
            BarraConocimiento.value += 1;
            valor--;
            yield return new WaitForSeconds(0.05f);
        }
        bombillas.SetActive(false);
    }
    
}

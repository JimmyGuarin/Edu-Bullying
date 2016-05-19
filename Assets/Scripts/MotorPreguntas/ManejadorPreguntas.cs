using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManejadorPreguntas : MonoBehaviour
{
	public static ManejadorPreguntas instanciaActiva;

    public RuntimeAnimatorController[] controladoresAnimaciones;

	[HideInInspector]
    public PuntoPregunta PuntoDePregunta;
    public GameObject bombillas;
    public Image[] coloresBotones;
    public ArrayList misPuntosRetro;
    public int puntajePuntoPregunta;
    // Use this for initialization
    void Start()
    {
        instanciaActiva = this; 
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController=controladoresAnimaciones[ControladorHUD.IndexPersonaje];
    }

    // Update is called once per frame
    void Update()
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
            ControladorHUD.instance.aumentarPuntaje(puntajePuntoPregunta, true);
            // bombillas.SetActive(true);
            Destroy(PuntoDePregunta);
            
        }
           
        
    }

    public void ResetearCanvas()
    {
        foreach(Image b in coloresBotones){

            b.color = Color.white;
            b.GetComponent<Button>().interactable = true;
            b.transform.GetChild(0).GetComponent<Text>().color = Color.black;
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

  //  public void AumentPuntaje()
  //  {
		//ControladorHUD.instance.aumentarPuntaje (puntajePuntoPregunta,true);
  //  }

   
    
}

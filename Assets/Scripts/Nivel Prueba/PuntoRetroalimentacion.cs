using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuntoRetroalimentacion : MonoBehaviour
{

    public GameObject canvas;
    
	[HideInInspector]
	public Text textoRetroalimentación;

	[HideInInspector]
	public string textoPunto;

    public int numeroRetroalimentacion;


    // Use this for initialization
    void Start()
    {
        
        canvas.SetActive(false);
        textoRetroalimentación = canvas.transform.FindChild("TextoRetro").GetComponent<Text>();
        PuntosRetro pr=(PuntosRetro)GameObject.FindGameObjectWithTag("Player").GetComponent<ManejadorPreguntas>().misPuntosRetro[numeroRetroalimentacion];
        textoPunto = pr.retroalimentacion;
    }
		
}

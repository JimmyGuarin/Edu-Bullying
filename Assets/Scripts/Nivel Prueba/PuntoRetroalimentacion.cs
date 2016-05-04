using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuntoRetroalimentacion : MonoBehaviour
{

    private GameObject canvas;
    private Text textoRetroalimentación;
    private string textoPunto;

    public int numeroRetroalimentacion;


    // Use this for initialization
    void Start()
    {
        canvas = Camera.main.transform.FindChild("CanvasRetro").gameObject;
        textoRetroalimentación = canvas.transform.FindChild("TextoRetro").GetComponent<Text>();
        PuntosRetro pr=(PuntosRetro) Camera.main.GetComponent<BullyingFisico>().miNivel.puntosRetro[numeroRetroalimentacion];
        textoPunto = pr.retroalimentacion;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        textoRetroalimentación.text = textoPunto;
        canvas.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
}

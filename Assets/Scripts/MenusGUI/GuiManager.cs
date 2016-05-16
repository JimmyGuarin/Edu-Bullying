using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour {


    public static int indexPersonaje=0;

    public GameObject canvasSeleccionarPersonaje;
    public GameObject canvasMenuPrincipal;

    public GameObject imagenCarga;
    AsyncOperation async;

    void Awake(){

        if (indexPersonaje != 0)
        {
            canvasSeleccionarPersonaje.SetActive(false);
            canvasMenuPrincipal.SetActive(true);
        }
    }
   
	// Use this for initialization
	void Start () {

       

	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void cambiarPersonaje(int intPersonaje)
    {
        indexPersonaje = intPersonaje;
    }

    public  void CerrarAplicacion() {

        Application.Quit();
    }

    public void Jugar()
    {
        ControladorHUD.IndexPersonaje = indexPersonaje-1;
        //imagenCarga.SetActive(true);
        StartCoroutine("load");
    }

    IEnumerator load() {

        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        
        yield return async;
        Debug.Log("Loading complete");
    }
   
}

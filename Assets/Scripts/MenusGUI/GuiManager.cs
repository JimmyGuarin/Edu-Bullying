using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour {


    public static int indexPersonaje=0;

    public GameObject canvasSeleccionarPersonaje;
    public GameObject canvasMenuPrincipal;

    public GameObject imagenCarga;
    AsyncOperation async;

    public GameObject bottonCambiarEscena;
    public GameObject textoCargando;

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

     

        if (async != null && async.progress>=0.9f)
        {
         
            textoCargando.SetActive(false);
            bottonCambiarEscena.SetActive(true);

        }

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
        
        imagenCarga.SetActive(true);
        StartCoroutine("load");
    }

    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        textoCargando.SetActive(true);
        yield return async;
    }

    public void ActivateScene()
    {
        ControladorHUD.IndexPersonaje = indexPersonaje - 1;
        async.allowSceneActivation = true;
        
    }

}

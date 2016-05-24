using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour {


    public static int indexPersonaje = 0;

    public GameObject canvasSeleccionarPersonaje;
    public GameObject canvasMenuPrincipal;

    public GameObject imagenCarga;
    AsyncOperation async;

    public GameObject bottonCambiarEscena;
    public GameObject textoCargando;

    public GameObject[] imagenMenuPrincipal;
    

    void Awake(){



        if (indexPersonaje != 0)
        {
            canvasSeleccionarPersonaje.SetActive(false);
            imagenMenuPrincipal[ControladorHUD.IndexPersonaje].SetActive(true);
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
        ControladorHUD.IndexPersonaje = indexPersonaje - 1;
        
    }

    public  void CerrarAplicacion() {

        Application.Quit();
    }

    public void Jugar()
    {
        
        imagenCarga.SetActive(true);
        imagenMenuPrincipal[ControladorHUD.IndexPersonaje].SetActive(false);
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
       if (ControladorHUD.instance!=null)
            ControladorHUD.instance.gameObject.SetActive(true);
 
        async.allowSceneActivation = true;
        
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Presentacion : MonoBehaviour {

    // Use this for initialization
    AsyncOperation async;
    public CanvasGroup fademe;

    void Start () {
        load();
      
	}
	
	// Update is called once per frame
	void Update () {

        if (async != null && async.progress == 0.9f)
        {
            StartCoroutine("activarFameEscena");
        }

    }

    IEnumerator activarFameEscena()
    {
       
        async.allowSceneActivation = true;
        while (!async.isDone)
        {

           // Debug.Log("Entra a corrutina" + async.progress);
            fademe.alpha += Time.deltaTime;
            Fade.alpha = fademe.alpha;

            yield return null;
        }
    }


    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync("SeleccionarPersonaje");
        async.allowSceneActivation = false;
        yield return async;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IniciarSeleccion : MonoBehaviour {


    AsyncOperation async;
    public CanvasGroup fade;
    // Use this for initialization
    void Start () {

        StartCoroutine("load");
        StartCoroutine("activarFame");


        //SceneManager.LoadScene("SeleccionarPersonajes");
    }
	
	// Update is called once per frame
	void Update () {


        if (async != null && async.progress == 0.9f)
        {

           
            async.allowSceneActivation = true;



        }


    }


    IEnumerator load()
    {

        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        yield return async;
    }

    IEnumerator activarFame()
    {
        
        fade.gameObject.SetActive(true);
        fade.alpha = 0.3f;
        while (!async.isDone)
        {
           
            fade.alpha += Time.deltaTime/1.5f;
            yield return null;
        }
       

    }
}

using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{

    public GameObject seleccionPersonje;
    public void Awake()
    {
       
        StartCoroutine("FadeMe");
    }

    // Use this for initialization



    void Start()
    {

    }

    IEnumerator FadeMe()
    {
        CanvasGroup cgrouo = GameObject.Find("Canvas").GetComponent<CanvasGroup>();


        int contador = 0;
        while (cgrouo.alpha > 0)
        {
            cgrouo.alpha -= Time.deltaTime / 2;
            Debug.Log(Time.deltaTime);
            contador++;
            yield return null;

            if(contador ==180)
            {
                seleccionPersonje.SetActive(true);
                seleccionPersonje.GetComponentInChildren<Animator>().enabled = true;
            }
        }
        Debug.Log(contador);

        cgrouo.gameObject.SetActive(false);
       
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

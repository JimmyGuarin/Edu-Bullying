using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{

    public GameObject seleccionPersonje =null;
    public static float alpha = 1f;
    public static bool entradaInicial = true;
    public CanvasGroup cgrouo;
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

        alpha = 1;
        cgrouo.alpha = alpha;
        
        while (cgrouo.alpha > 0)
        {
            cgrouo.alpha -= Time.deltaTime / 2;
            alpha = cgrouo.alpha;
              
            yield return null;

            if(cgrouo.alpha<0.75f&&seleccionPersonje!=null)
            {
                // Debug.Log(GuiManager.indexPersonaje);
                
                if (entradaInicial ==true)
                {
                    Debug.Log("primera vez");
                    seleccionPersonje.SetActive(true);
                    seleccionPersonje.GetComponentInChildren<Animator>().enabled = true;
                    //reacomodarMenu();
                    seleccionPersonje = null;
                    entradaInicial = false;

                }
             }
        }
        //Debug.Log(contador);

        cgrouo.gameObject.SetActive(false);
       
        yield return null;
    }

    public void activarCorrutina()
    {
        StartCoroutine("FadeMe");
    }

    public void reacomodarMenu()
    {


        if(seleccionPersonje!=null)
        {
            Transform arnold = seleccionPersonje.GetComponent<Transform>().GetChild(0).GetChild(0).transform;
            Transform keilly = seleccionPersonje.GetComponent<Transform>().GetChild(0).GetChild(1).transform;
            Transform fredd = seleccionPersonje.GetComponent<Transform>().GetChild(0).GetChild(2).transform;
            Transform fill = seleccionPersonje.GetComponent<Transform>().GetChild(0).GetChild(3).transform;

            arnold.position.Set(-1319f, arnold.position.y, arnold.position.z);
            keilly.position.Set(1328f, keilly.position.y, keilly.position.z);
            fredd.position.Set(-1319f, fredd.position.y, fredd.position.z);
            fill.position.Set(1328f, fill.position.y, fill.position.z);
        }
        
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}

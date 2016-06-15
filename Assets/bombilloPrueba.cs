using UnityEngine;
using System.Collections;

public class bombilloPrueba : MonoBehaviour
{

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {




    }

    public void OnEnable()
    {
        Invoke("Deshabilitar", 3f);
    }    

    void Deshabilitar()
    {

        gameObject.SetActive(false);

    }



}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActivadorMotor : MonoBehaviour {

    // Use this for initialization

    List<GameObject> plataformas = new List<GameObject>();
    Quaternion rotacionInicial;


    bool parar0 = false;
    bool parar1 = false;
    bool parar2 = false;
    bool parar3 = false;
    
    


    void Start () {

        obtenerPlataformas();
        rotacionInicial = plataformas[0].transform.rotation;

        StartCoroutine("secuenciarMovimientoPlataformas");

    }
	
	// Update is called once per frame
	void Update () {
        detener();
    }

    void obtenerPlataformas()
    {
        if (gameObject.transform.GetChildCount()!=0)
        {
           for(int i=0;i<transform.GetChildCount();i++)
            {
                plataformas.Add(transform.GetChild(i).gameObject);
                
            }
        }
    }


    IEnumerator secuenciarMovimientoPlataformas()
    {

        while (true)
        {


            if (plataformas[3].gameObject.GetComponent<Rigidbody2D>().isKinematic == true)
            {
                //Debug.Log("entre");
                parar3 = false;
                plataformas[3].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                plataformas[3].gameObject.GetComponent<HingeJoint2D>().enabled = true;
                yield return new WaitForSeconds(3f);
                parar3 = true;

            }

            if (plataformas[2].gameObject.GetComponent<Rigidbody2D>().isKinematic == true)
            {

                parar2 = false;
                plataformas[2].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                plataformas[2].gameObject.GetComponent<HingeJoint2D>().enabled = true;
                yield return new WaitForSeconds(3f);
                parar2 = true;

            }
            if (plataformas[1].gameObject.GetComponent<Rigidbody2D>().isKinematic == true)
            {

                parar1 = false;
                plataformas[1].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                plataformas[1].gameObject.GetComponent<HingeJoint2D>().enabled = true;
                yield return new WaitForSeconds(3f);
                parar1 = true;
            }

            if (plataformas[0].gameObject.GetComponent<Rigidbody2D>().isKinematic == true)
            {

                parar0 = false;
                plataformas[0].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                plataformas[0].gameObject.GetComponent<HingeJoint2D>().enabled = true;
                yield return new WaitForSeconds(3f);
                parar0 = true;
            }
        }

      }


    void detener()
    {
        if(parar1 ==true && rotacionInicial == plataformas[1].gameObject.transform.rotation)
        {
            plataformas[1].gameObject.GetComponent<HingeJoint2D>().enabled = false;
            plataformas[1].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if(parar2 ==true && rotacionInicial == plataformas[2].gameObject.transform.rotation)
        {
            plataformas[2].gameObject.GetComponent<HingeJoint2D>().enabled = false;
            plataformas[2].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if(parar3 ==true && rotacionInicial == plataformas[3].gameObject.transform.rotation)
        {
            plataformas[3].gameObject.GetComponent<HingeJoint2D>().enabled = false;
            plataformas[3].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        if (parar0 == true && rotacionInicial == plataformas[0].gameObject.transform.rotation)
        {
            plataformas[0].gameObject.GetComponent<HingeJoint2D>().enabled = false;
            plataformas[0].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }

    }
}

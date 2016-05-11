using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class Enemigo : MonoBehaviour
{

    public GameObject presionarFPanel;
    public GameObject canvasConversacion;
    public MaquinaEstadosConver mq;
    public bool enColision;

    // Use this for initialization
    void Start()
    {

        enColision = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (enColision)
        {

            if (Input.GetKeyDown("f"))
            {
                Time.timeScale = 0;
                presionarFPanel.SetActive(false);
                canvasConversacion.SetActive(true);
                mq.Moldear();
                GetComponent<Collider2D>().enabled = false;
                enColision = false;
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {

        presionarFPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text ="Para hablar con "+gameObject.name+" y convencerlo"+
            "de dejar el Bullying presiona F";
        presionarFPanel.SetActive(true);
        enColision = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        presionarFPanel.SetActive(false);
        enColision = false;
    }
}

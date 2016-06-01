using UnityEngine;
using System.Collections;

public class Laboratorio : MonoBehaviour
{

    private MovimientoPersonaje mp;
    public float escalaMax;
    public float escalaMin;
    public float tasaCrecimiento;
    public float fuerzaSaltoGrande = 30f;
    public float velocidadGrande = 10f;

    private bool crecer;

    // Use this for initialization
    void Start()
    {

        mp = GetComponent<MovimientoPersonaje>();
        crecer = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (crecer)
        {


            //mp.escala -= (tasaCrecimiento / 2) * Time.deltaTime;
            if (mp.escala < escalaMax)
            {

            }
            mp.escala += tasaCrecimiento;
            Debug.Log(mp.escala);
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("ColisionGrande") && Mathf.Abs(mp.escala) <= escalaMax)
        {

            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x - (tasaCrecimiento * 2 * Time.deltaTime), transform.localScale.y + (tasaCrecimiento * 2 * Time.deltaTime), 1);
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + (tasaCrecimiento * 2 * Time.deltaTime), transform.localScale.y + (tasaCrecimiento * 2 * Time.deltaTime), 1);
            }
            mp.escala += tasaCrecimiento * 2 * Time.deltaTime;
            mp.velocidad = velocidadGrande;
            mp.fuerzaSalto = fuerzaSaltoGrande;
            mp.radioValidacion = (float)((0.45 * mp.escala) / 0.2);
        }


        if (collision.tag.Equals("Destructor"))
        {
            Debug.Log("Entra");
            mp.escala = 0.2f;
            mp.velocidad = 8;
            mp.fuerzaSalto = 25;
            transform.localScale = new Vector3(0.2f, 0.2f, 1);
            mp.radioValidacion = 0.45f;
        }


        if (collision.name.Equals("ColisionPequeña") && Mathf.Abs(mp.escala) >= escalaMin)
        {

            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x + (tasaCrecimiento * 4 * Time.deltaTime), transform.localScale.y - (tasaCrecimiento * 4 * Time.deltaTime), 1);
            else
                transform.localScale = new Vector3(transform.localScale.x - (tasaCrecimiento * 4 * Time.deltaTime), transform.localScale.y - (tasaCrecimiento * 4 * Time.deltaTime), 1);
            mp.escala -= tasaCrecimiento * 4 * Time.deltaTime;
            mp.velocidad = 8;
            mp.fuerzaSalto = 25;
            mp.radioValidacion = 0.45f;

        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("ColisionPequeña"))
        {

            mp.escala = escalaMin;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class AnclandoPersonaje : MonoBehaviour
{



    //Hace hijo al personaje de la plataforma en el momento en que entra en colision con ella
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformasMov")
        {
            gameObject.transform.SetParent(collision.gameObject.transform);

        }

        if (collision.gameObject.tag == "Trampolin")
        {
            //GetComponent<PlatformerCharacter2D>().m_JumpForce = 0f;
            Debug.Log(GetComponent<PlatformerCharacter2D>().m_JumpForce);
        }


    }
    //Elimina el padre del personje.
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformasMov")
        {
            gameObject.transform.parent = null;
        }
        

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        
    }
}

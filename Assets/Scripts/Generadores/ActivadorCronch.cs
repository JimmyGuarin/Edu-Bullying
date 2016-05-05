using UnityEngine;
using System.Collections;


public class ActivadorCronch : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_Anim.SetBool("enColision", true);
        Debug.Log("EstoyColisionando");

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_Anim.SetBool("Crouch", false);
    }
}

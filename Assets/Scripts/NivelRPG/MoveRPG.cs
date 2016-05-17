using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoveRPG : MonoBehaviour
{


    // Normal Movements Variables
    private float walkSpeed;
    private float curSpeed;
    private GameObject canvasNiveles;
    private bool enColision;
    public string nombreNivel;

    void Start()
    {

        nombreNivel = "";
        enColision = false;
       canvasNiveles= GameObject.Find("Canvas");
        curSpeed = (float)(2);


    }

    public void Update()
    {
        if (enColision && Input.GetKeyDown("f"))
        {
            SceneManager.LoadSceneAsync(nombreNivel);
        }
    }

    void FixedUpdate()
    {

        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") == 0)
        {


            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxisRaw("Horizontal") * curSpeed, 1), 0);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Lerp(0, Input.GetAxisRaw("Vertical") * curSpeed, 1));
        }

        if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) || (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Patio"))
        {
            enColision = true;
        }

        if (enColision)
        {
            nombreNivel = collision.name;
            canvasNiveles.transform.FindChild(nombreNivel).gameObject.SetActive(true);          
        }
           
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (enColision)
        {
            enColision = false;
            canvasNiveles.transform.FindChild(collision.name).gameObject.SetActive(false);
        }
       
    }
}
using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour
{

    public float fuerzaSalto = 15f;
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private bool tocaPiso;
    private Animator anim;
    public LayerMask capaPiso;
    public float radioValidacion;
    public Transform validadorPiso;
    public float escala = 0.2f;
    public AudioSource[] sonidos;

    // Use this for initialization
    void Start()
    {

        tocaPiso = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("Estado", 0);
        sonidos = GetComponents<AudioSource>();
    }

    void FixedUpdate()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        //tocaPiso = Physics2D.OverlapCircle(validadorPiso.position, radioValidacion, capaPiso);
        tocaPiso = Physics2D.OverlapArea(new Vector2(validadorPiso.position.x - radioValidacion, validadorPiso.position.y + (radioValidacion / 8)), new Vector2(validadorPiso.position.x + radioValidacion, validadorPiso.position.y - (radioValidacion / 8)), capaPiso, 0);
        

        if (tocaPiso)
        {
            anim.SetInteger("Estado", 0);
            

        }

        if(tocaPiso&&Input.GetAxis("Horizontal")==0&& Input.GetAxis("Vertical") == 0)
        {
            sonidos[2].Stop();
        }

        if(tocaPiso==false)
        {
            if (sonidos[2].isPlaying == true)
            {
                sonidos[2].Stop();
            }
            
           
           
               
        }




        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);
            rb.transform.localScale = new Vector3(-escala, escala, 1f);
            if (tocaPiso) { 
                anim.SetInteger("Estado", 1);
                if (sonidos[2].isPlaying == true)
                {

                }
                else
                    sonidos[2].Play();
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {


            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);
            rb.transform.localScale = new Vector3(escala, escala, 1f);
            if (tocaPiso)
            {
                anim.SetInteger("Estado", 1);
                if(sonidos[2].isPlaying ==true)
                {

                }
                else
                sonidos[2].Play();
                
            }
                
        }

        if (Input.GetKey(KeyCode.UpArrow) && (tocaPiso))
        {


            anim.enabled = false;
            anim.enabled = true;
            anim.SetInteger("Estado", 2);
            // if (tocaPiso)
            if (!sonidos[3].isPlaying)
                sonidos[3].Play();
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);

        }



    }



    void OnCollisionEnter2D(Collision2D collider)
    {




        if (collider.transform.tag.Equals("PlataformasMov"))
        {

            transform.parent = collider.transform;

        }




    }




    void OnCollisionExit2D(Collision2D collider)
    {

        if (collider.transform.tag.Equals("PlataformasMov"))
        {

            transform.parent = null;
        }



    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(validadorPiso.position, new Vector3(radioValidacion, radioValidacion / 8, 1));
    //}
}
using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour {

	public float fuerzaSalto=15f;
	public float velocidad = 5f;
	private Rigidbody2D rb;
	private bool tocaPiso;
	private Animator anim;
	public LayerMask capaPiso;
	public float radioValidacion;
	public Transform validadorPiso;
    public float escala=0.2f;

    // Use this for initialization
    void Start () {

        tocaPiso = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetInteger ("Estado", 0);
    }

    void FixedUpdate()
    {
        
        tocaPiso = Physics2D.OverlapCircle(validadorPiso.position, radioValidacion, capaPiso);


    }

    // Update is called once per frame
    void Update () {

        if (tocaPiso)
        {
            anim.SetInteger("Estado", 0);
        }

       
    

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);
            rb.transform.localScale = new Vector3(-escala, escala, 1f);
            if (tocaPiso)
                anim.SetInteger("Estado", 1);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {


            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);
            rb.transform.localScale = new Vector3(escala, escala, 1f);
            if (tocaPiso)
                anim.SetInteger("Estado", 1);
        }
        
        if (Input.GetKey(KeyCode.UpArrow)&&(tocaPiso))
        {
                
              
                    anim.enabled = false;
                    anim.enabled = true;
                    anim.SetInteger("Estado", 2);
                    if(tocaPiso)
                        rb.velocity = new Vector2(rb.velocity.x,fuerzaSalto);
                    tocaPiso = false;
            
               
        }

  
    }

    

    void OnCollisionEnter2D(Collision2D collider){


        

		if (collider.transform.tag.Equals ("PlataformasMov")) {
		
			transform.parent = collider.transform;
       
		}

       


    }

   


        void OnCollisionExit2D(Collision2D collider){

		if (collider.transform.tag.Equals ("PlataformasMov")) {

			transform.parent = null;
		}

       

    }
}

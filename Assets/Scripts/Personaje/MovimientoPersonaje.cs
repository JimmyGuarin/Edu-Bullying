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


    // Use this for initialization
    void Start () {


		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetInteger ("Estado", 0);
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {

			rb.velocity = new Vector2 (Input.GetAxis("Horizontal")*velocidad, rb.velocity.y);
			rb.transform.localScale = new Vector3 (-0.25f,0.25f,1f);
			if(tocaPiso)
				anim.SetInteger ("Estado", 1);

		}

		if (Input.GetKey (KeyCode.RightArrow)) {


			rb.velocity = new Vector2 (Input.GetAxis("Horizontal")*velocidad, rb.velocity.y);
			rb.transform.localScale = new Vector3 (0.25f,0.25f,1f);
			if(tocaPiso)
				anim.SetInteger ("Estado", 1);
		}

		if (Input.GetKey(KeyCode.UpArrow)&&tocaPiso) {


			rb.velocity = new Vector2 (rb.velocity.x,fuerzaSalto);
			anim.SetInteger ("Estado", 2);
		}
        
    }

	void FixedUpdate(){

		tocaPiso = Physics2D.OverlapCircle (validadorPiso.position, radioValidacion, capaPiso);
		if(tocaPiso)
			anim.SetInteger ("Estado", 0);
	


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

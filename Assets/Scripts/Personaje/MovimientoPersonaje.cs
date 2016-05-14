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


        
    }

	void FixedUpdate(){

		tocaPiso = Physics2D.OverlapCircle (validadorPiso.position, radioValidacion, capaPiso);
		if(tocaPiso)
			anim.SetInteger ("Estado", 0);

	
		if (Input.GetKey (KeyCode.LeftArrow)) {

			rb.velocity = new Vector2 (-velocidad, rb.velocity.y);
			rb.transform.localScale = new Vector3 (-0.25f,0.25f,1f);
			anim.SetInteger ("Estado", 1);
		
		}
	
		if (Input.GetKey (KeyCode.RightArrow)) {

			rb.velocity = new Vector2 (velocidad, rb.velocity.y);
			rb.transform.localScale = new Vector3 (0.25f,0.25f,1f);
			anim.SetInteger ("Estado", 1);
		}

		if (Input.GetKey (KeyCode.UpArrow)&&tocaPiso) {

			rb.velocity = new Vector2 (rb.velocity.x,fuerzaSalto);
			anim.SetInteger ("Estado", 2);
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    Vector3 move;
    float h, v;
    [SerializeField]
    private float _radius;
    [SerializeField]
    LayerMask interactable;
    [SerializeField]
    Vector2 playerlimit;
    [SerializeField]
    Equipmanager equipmanager;
    Animator anim;
    AudioSource aud;

    void Start () {
        equipmanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Equipmanager>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveCharacter();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactcheck())
            {
                PlayerInteraction();
                Debug.Log("kere mama ke kvoro, jinish paisi");
            }
            else
            {
                if (!equipmanager.SlotEmptyChecker())
                {

                }
                //putting down if i have item
            }
                
        }
	}
    void MoveCharacter()
    {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        move = new Vector3(h, v, 0).normalized;
        transform.position = transform.position + move * speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -playerlimit.x, playerlimit.x), Mathf.Clamp(transform.position.y, -playerlimit.y, playerlimit.y), transform.position.z);


        anim.SetFloat("SpeedX",  ( h*speed));
        anim.SetFloat("SpeedY", (v*speed));
    }

    bool interactcheck()
    {
        if (Physics2D.OverlapCircle(transform.position, _radius, interactable))
        {
            
            return true;


        }


        return false;
    }

    void PlayerInteraction()
    {
        Collider2D other = Physics2D.OverlapCircle(transform.position, _radius, interactable);
        Interactable pickable = other.GetComponent<Interactable>();
        if (pickable != null)
        {
            if (!aud.isPlaying)
            {
                aud.Play();
            }
            pickable.Interact();
        }
       


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);

    }
}

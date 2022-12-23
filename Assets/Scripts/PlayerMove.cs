using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    

    public static PlayerMove instance = null;
    

    public float speed;
    public Vector3 vector;
    public Vector3 prevVector = Vector3.zero;

    public float Bspeed;
    private float BspeedActivate;

    public float pixelwalk;
    public float Nowpixelwalk;

    public bool stop = true;
    private bool runsteop = false;

    public Animator animator;
    public BoxCollider2D boxcolider;

    public LayerMask layermask;

    public AudioClip defaultWalk;
    public AudioClip grassWalk;

    public AudioSource walkingSound;

     public MapChange mapchange;

    GameObject instanceplayer;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
                 
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if (UIManager.instance.isuiOn == true)
                {
                    stop = false;
                    StartCoroutine("WalkCoroutine");
                }
            }

        }
    }

    public void StopMove()
    {
        StopCoroutine("WalkCoroutine");
        animator.SetBool("Move", false);
        prevVector = vector;
        stop = true;
        
    }

    public void ResumeMove()
    {
        if (Nowpixelwalk != 0)
        {
            StartCoroutine("WalkCoroutine");
        }        
        stop = true;
    }

    IEnumerator WalkCoroutine()
    {
        while(Input.GetAxisRaw("Vertical")!=0 || Input.GetAxisRaw("Horizontal")!=0 || prevVector != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                BspeedActivate = Bspeed;
                runsteop = true;
            }
            else
            {
                BspeedActivate = 0;
                runsteop = false;
            }           

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
            if (vector.x != 0)
                vector.y = 0;
            else if (vector.y != 0)
                vector.x = 0;
            
            if(prevVector != Vector3.zero)
                vector = prevVector;

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);


            RaycastHit2D hit;

            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * speed * pixelwalk, vector.y * speed * pixelwalk);

            boxcolider.enabled = false;
            hit = Physics2D.Linecast(start, end, layermask);
            boxcolider.enabled = true;

            if (hit.transform != null)
                break;


            animator.SetBool("Move", true);

            while (Nowpixelwalk < pixelwalk)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + BspeedActivate), 0, 0);


                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * (speed + BspeedActivate), 0);
                }
                if (runsteop)
                {
                    Nowpixelwalk++;
                }
                Nowpixelwalk++;
                yield return new WaitForSeconds(0.01f);

               
                if(Nowpixelwalk%20==0/*&&ran==0*/)
                {
                    walkingSound.clip = defaultWalk;
                    
                    walkingSound.Play();
                }
                
            }


            float x = Mathf.Floor(transform.position.x);
            float y = Mathf.Floor(transform.position.y);
            transform.position = new Vector2(x + 0.5f, y + 0.5f);

          

            Nowpixelwalk = 0;
            prevVector = Vector3.zero;
        }
        animator.SetBool("Move", false);
        stop = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mapchange = collision.GetComponent<MapChange>();
        instance.StopMove();
        StartCoroutine("Enter");
        //StartCoroutine(UIManager.instance.FadeIn());
        //SceneExecutor.instance.SceneChange(mapchange);
        // AudioManager.instance.BgmPlay();
    }

    public IEnumerator Enter()
    {
        StartCoroutine(UIManager.instance.FadeIn(instance));
        while (UIManager.instance.isfaded)
        { 
            yield return null;
        }
        //yield return new WaitForSeconds(1.2f);
        
        SceneExecutor.instance.SceneChange(mapchange);
       
        Destroy(gameObject);
        
        
    }
}

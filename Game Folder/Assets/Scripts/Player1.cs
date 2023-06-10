using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player1 : MonoBehaviour
{
    [SerializeField] AudioClip sfxJump, sfxDeath;
    [SerializeField] float jumpForce = 100f;

    AudioSource audioSource;
    Animator anim;
    Rigidbody rb;
    bool jump = false;
    Vector2 deathHit = new Vector2(-120, 40);

    void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStart();
                anim.Play("Jump");
                rb.useGravity = true;
                jump = true;
                audioSource.PlayOneShot(sfxJump);
            }
        }
    }

    void FixedUpdate()
    {
        if(jump) 
        {
            jump = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            rb.AddForce(deathHit, ForceMode.Impulse);
            rb.AddTorque(deathHit, ForceMode.Impulse);
            rb.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }
    }
}

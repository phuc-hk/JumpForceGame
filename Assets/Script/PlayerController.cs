using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAni;
    public ParticleSystem explosionPartical;
    public ParticleSystem dirtplatterPartical;
    private AudioSource audioSource;
    public AudioClip jumpAudio;
    public AudioClip crashAudio;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAni.SetTrigger("Jump_trig");
            dirtplatterPartical.Stop();
            audioSource.PlayOneShot(jumpAudio);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGameOver)
        {
            isOnGround = true;
            dirtplatterPartical.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            isGameOver = true;
            playerAni.SetBool("Death_b", true);
            playerAni.SetInteger("DeathType_int", 1);
            explosionPartical.Play();
            dirtplatterPartical.Stop();
            audioSource.PlayOneShot(crashAudio);
        }
    }
}

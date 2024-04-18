using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    Rigidbody playerRb;
    AudioSource playerAudio;

    [SerializeField]float playerForce;
    [SerializeField] float gravityModifier;

    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem fireworkParticle;
    [SerializeField] AudioClip bombSound;
    [SerializeField] AudioClip moneySound;
    [SerializeField] AudioClip jumpSound;

    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector2.up * playerForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            fireworkParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1);
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            Debug.Log("Game Over");
            explosionParticle.Play();
            gameOver = true;
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(bombSound, 1);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}

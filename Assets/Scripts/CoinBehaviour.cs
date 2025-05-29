using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [Tooltip("Collect effect to play when player collects coin")]
    public GameObject collectEffect;

    [Tooltip("How long to wait before destroying object")]
    public float waitTime = 2.0f;

    [Tooltip("Coin's mesh renderer")]
    public MeshRenderer coinMR;

    [Tooltip("Coin's sound stuff")]
    public AudioSource audioSource;
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // First check if we collided with the player
        if (other.gameObject.GetComponent<PlayerBehaviour>())
        {
            //Instantiate(collectEffect, this.gameObject.transform.position, Quaternion.identity);

            // Call the function, DestroyCoin after
            // waitTime has passed
            Invoke("DestroyCoin", waitTime);

            // Disable coin's meshrenderer
            coinMR.enabled = false;

            // play explosion sound
            audioSource.pitch = 1;
            audioSource.PlayOneShot(collectSound);
        }
    }

    void DestroyCoin()
    {
        Destroy(this.gameObject);
    }
}

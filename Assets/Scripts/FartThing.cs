using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartThing : MonoBehaviour
{
    [Tooltip("Fart's sound stuff")]
    public AudioSource audioSource;
    public AudioClip fartSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(fartSound);

        Invoke("BYEBYE", 1f);
    }

    void BYEBYE()
    {
        Destroy(this.gameObject);
    }
}

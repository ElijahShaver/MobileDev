using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("How long to wait before restarting the game")]
    public float waitTime = 2.0f;

    [Tooltip("Explosion effect to play when tapped")]
    public GameObject explosion;

    [Tooltip("Explosion effect to play when player dies")]
    public GameObject explosionEffect;

    [Tooltip("Death effect to play when player dies")]
    public GameObject deathEffect;

    [Tooltip("Obstacle's mesh renderer")]
    public MeshRenderer obstacleMR;

    [Tooltip("Obstacle's sound stuff")]
    public AudioSource audioSource;
    public AudioClip explosionSound;

    /// <summary>
    /// If the object is tapped, we spawn an explosion and
    /// destroy this object
    /// </summary>
    public void PlayerTouch()
    {
        if (explosion != null)
        {
            var particles = Instantiate(explosion,
            transform.position,
            Quaternion.identity);
            Destroy(particles, 1.0f);
        }

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // First check if we collided with the player
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            Vector3 deathPos = collision.gameObject.transform.position;

            // instantiate explosions
            Instantiate(explosionEffect, this.gameObject.transform.position, Quaternion.identity);
            Instantiate(deathEffect, deathPos, Quaternion.identity);

            // Destroy the player
            Destroy(collision.gameObject);

            // Call the function ResetGame after
            // waitTime has passed
            Invoke("ResetGame", waitTime);

            // Disable obstacle's meshrenderer
            obstacleMR.enabled = false;

            // play explosion sound
            audioSource.PlayOneShot(explosionSound);
        }
    }

    /// <summary>
    /// Will restart the currently loaded level
    /// </summary>
    private void ResetGame()
    {
        // Get the current level's name
        string sceneName = SceneManager.GetActiveScene().name;
        // Restarts the current level
        SceneManager.LoadScene(sceneName);
    }
}

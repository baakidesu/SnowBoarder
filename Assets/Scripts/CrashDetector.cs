using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float delayTime = 2f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;

    private bool hasCrashed= false;
   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.tag == "Ground"&& hasCrashed == false)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableMove();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayTime);
        }
    }

   void ReloadScene()
   {
       SceneManager.LoadScene(0);
   }
   
}

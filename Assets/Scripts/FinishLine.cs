using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayTime = 2f;
    [SerializeField] private ParticleSystem finishEffect;
   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.tag == "Player")
        {
            finishEffect.Play();
           GetComponent<AudioSource>().Play(); 
            Invoke("ReloadScene",delayTime);
        }
   }

   void ReloadScene()
   {
       SceneManager.LoadScene(0);
   }
}

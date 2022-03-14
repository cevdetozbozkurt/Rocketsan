using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;   

    //[SerializeField] ParticleSystem successParticles; 
    //[SerializeField] ParticleSystem crashParticles; bu ikisi successParticles.Play(); olarak çalışmadı aşağıdaki gibi çalıştı

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning){ return; }
        switch(other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GameObject.Find("Success Particles").GetComponent<ParticleSystem>().Play();
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GameObject.Find("Explosion Particles").GetComponent<ParticleSystem>().Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int next_level_index = currentSceneIndex + 1;
        if(next_level_index == SceneManager.sceneCountInBuildSettings)
        {
            next_level_index = 0;
        }
        SceneManager.LoadScene(next_level_index);
    }
}

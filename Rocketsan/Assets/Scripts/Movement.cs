using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    AudioSource rocket_audio;
    ParticleSystem boost;
    ParticleSystem rightBoost;
    ParticleSystem leftBoost;

  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocket_audio = GetComponent<AudioSource>();
        boost = GameObject.Find("Rocket Jet Particles").GetComponent<ParticleSystem>();
        leftBoost = GameObject.FindGameObjectWithTag("Left boost").GetComponent<ParticleSystem>();
        rightBoost = GameObject.FindGameObjectWithTag("Right boost").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!rocket_audio.isPlaying)
        {
            rocket_audio.PlayOneShot(mainEngine);

        }
        if (!boost.isPlaying)
        {
            boost.Play();
        }
    }

    void StopThrusting()
    {
        rocket_audio.Stop();
        boost.Stop();
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!rightBoost.isPlaying)
        {
            rightBoost.Play();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!leftBoost.isPlaying)
        {
            leftBoost.Play();
        }
    }

    void StopRotating()
    {
        rightBoost.Stop();
        leftBoost.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

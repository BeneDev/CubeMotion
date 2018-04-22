using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    #region Properties



    #endregion

    #region Fields

    PlayerInput input;
    Rigidbody rb;
    Camera cam;
    CameraShake camShake;

    Vector3 direction;
    [SerializeField] float veloCap;
    [SerializeField] float speed;
    [SerializeField] float boostAmount;
    [SerializeField] float rotationSpeed;
    [SerializeField] float shakingVelo = 25f;
    float stretchamount;
    float startTime;

    [SerializeField] float squashDurationOnImpact = 0.5f;

    bool bJustCollided = false;

    [Header("ParticleEffects"), SerializeField] ParticleSystem windChannel;

    #endregion

    #region Unity Messages

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        camShake = cam.GetComponent<CameraShake>();
    }

    void Start()
    {
		
    }

    void Update()
    {
		
    }

    private void FixedUpdate()
    {
        ReadInput();
        ShakeWhenFast();
        if (!bJustCollided)
        {
            stretchamount = (100 + rb.velocity.magnitude) / 100f;
            SquashAndStretch(stretchamount);
        }
        else
        {
            if(Time.realtimeSinceStartup >= startTime + squashDurationOnImpact)
            {
                bJustCollided = false;
                rb.velocity = -transform.forward * 10f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (startTime < Time.realtimeSinceStartup - 1.5f)
        {
            float squashAmount = (80f - rb.velocity.magnitude * 5f) / 100f;
            SquashAndStretch(squashAmount);
            bJustCollided = true;
            startTime = Time.realtimeSinceStartup;
            camShake.shakeAmount = 0.7f;
            camShake.shakeDuration = 0.3f;
        }
    }

    #endregion

    #region Private Methods

    private void ReadInput()
    {
        if (!bJustCollided)
        {
            direction.x = input.Horizontal;
            direction.z = input.Vertical;

            if (input.Boost > 0f)
            {
                if (rb.velocity.magnitude < veloCap * 2)
                {
                    rb.velocity += direction * (speed + (boostAmount * input.Boost)) * Time.fixedDeltaTime;
                }
            }
            else
            {
                if (rb.velocity.magnitude < veloCap)
                {
                    rb.velocity += direction * speed * Time.fixedDeltaTime;
                }
            }

            if (input.Horizontal != 0 || input.Vertical != 0)
            {
                Quaternion targetRotation = new Quaternion();
                targetRotation.SetLookRotation(direction);

                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }

    private void ShakeWhenFast()
    {
        if(rb.velocity.magnitude > shakingVelo)
        {
            camShake.shakeAmount = rb.velocity.magnitude / 200f;
            camShake.shakeDuration = 0.1f;

            if(windChannel && !windChannel.isPlaying)
            {
                windChannel.Play();
            }
        }
        else
        {
            if(windChannel && windChannel.isPlaying)
            {
                windChannel.Stop();
            }
        }
    }

    // Squashes (when under 100) or stretches (when over 100) the object
    private void SquashAndStretch(float percentage)
    {
        transform.localScale = new Vector3(1f * (2f - percentage), 1f, 1f * percentage);
    }

    #endregion
}

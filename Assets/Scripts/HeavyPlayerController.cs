using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class HeavyPlayerController : MonoBehaviour {

    PlayerInput input;
    Rigidbody rb;
    Camera cam;
    CameraShake camShake;

    [SerializeField] float speed;
    private Vector3 direction;
    [SerializeField] float veloCap;
    [SerializeField] float rotationSpeed;
    [SerializeField] float shakeDurationWhenFlippingOver = 0.2f;
    [SerializeField] ParticleSystem smokeImpact;

    float startTime;

    bool bJustCollided = false;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        camShake = cam.GetComponent<CameraShake>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(bJustCollided)
        {
            if(Time.realtimeSinceStartup > startTime + 1.2f)
            {
                bJustCollided = false;
            }
        }
	}

    private void FixedUpdate()
    {
        if (GameManager.Instance.activePlayer == transform.gameObject)
        {
            ReadInput();
        }
    }

    private void ReadInput()
    {
        direction.x = input.Horizontal;
        direction.z = input.Vertical;


        if (rb.velocity.magnitude < veloCap && input.AddForce)
        {
            rb.velocity += direction * speed * Time.fixedDeltaTime;
        }

        if (input.Horizontal != 0 || input.Vertical != 0)
        {
            Quaternion targetRotation = new Quaternion();
            targetRotation.SetLookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bJustCollided)
        {
            camShake.shakeAmount = 0.3f;
            camShake.shakeDuration = shakeDurationWhenFlippingOver;
            bJustCollided = true;
            startTime = Time.realtimeSinceStartup;
            if(smokeImpact && !smokeImpact.isPlaying)
            {
                smokeImpact.Play();
            }
        }
    }

}

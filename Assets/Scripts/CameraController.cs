using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Properties



    #endregion

    #region Fields

    private GameObject player;

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 12f;

    #endregion

    #region Unity Messages

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 newPos = player.transform.position;
        newPos.y = 0f;
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        if(GameManager.Instance.Dimensions == 3)
        {
            Quaternion newRot = player.transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Private Methods

	

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Properties

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    #endregion

    #region Fields

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 12f;

    #endregion

    #region Unity Messages

    private void Awake()
    {
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 newPos = GameManager.Instance.activePlayer.transform.position;
        newPos.y = 0f;
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        //Quaternion newRot = GameManager.Instance.activePlayer.transform.rotation;
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Private Methods

	

    #endregion
}

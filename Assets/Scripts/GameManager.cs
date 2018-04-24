using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Properties

    public int Dimensions
    {
        get
        {
            return dimensions;
        }
    }

    #endregion

    #region Fields

    public static GameManager Instance;


    public GameObject activePlayer;
    [SerializeField] int dimensions = 2;

    #endregion

    #region Unity Messages

    private void Awake()
    {
		if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        activePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
		// If the player pushes a button, search for a gameobject with the player tag which is not the current
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Private Methods

	

    #endregion
}

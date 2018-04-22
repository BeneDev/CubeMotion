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
		
    }

    void Update()
    {
		
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Private Methods

	

    #endregion
}

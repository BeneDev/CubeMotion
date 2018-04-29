using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Properties

    #endregion

    #region Fields

    public static GameManager Instance;


    public GameObject activePlayer;

    private GameObject[] players;
    int playerIndex;

    bool bSwitchInUse = false;

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
        playerIndex = 0;
    }

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        activePlayer = players[playerIndex];
    }

    void Update()
    {
        if (Input.GetAxisRaw("SwitchPlayer") != 0)
        {
            if (bSwitchInUse == false)
            {
                bSwitchInUse = true;
                if (playerIndex < players.Length - 1)
                {
                    playerIndex++;
                }
                else
                {
                    playerIndex = 0;
                }
                activePlayer = players[playerIndex]; 
            }
        }
        if (Input.GetAxisRaw("SwitchPlayer") == 0)
        {
            bSwitchInUse = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Private Methods

	

    #endregion
}

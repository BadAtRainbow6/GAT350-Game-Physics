using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPos;
    public Quaternion playerRot;

    // this is the initial values upon starting a new game
    // is only ever called once per game
    public GameData()
    {
        playerPos = new Vector3(0, 1, 0);
        playerRot = Quaternion.identity;
    }
}

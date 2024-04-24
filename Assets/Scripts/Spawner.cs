using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] KeyCode spawnKey;

    void Update()
    {
        if(Input.GetKeyDown(spawnKey))
        {
            Instantiate(prefab, transform);
        }
    }
}

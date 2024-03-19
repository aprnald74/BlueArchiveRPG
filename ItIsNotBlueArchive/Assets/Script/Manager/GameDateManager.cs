using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDateManager : MonoBehaviour
{

    public static GameDateManager Instance = null;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    
}

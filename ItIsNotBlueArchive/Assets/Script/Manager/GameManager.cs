using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;
    
    public Canvas popUp;
    
    private bool created = false;
    private int sceneIndex;
    public int SceneIndex { get { return sceneIndex; } set { sceneIndex = value; } }
    public bool IsPopHide  { get { return created; } }

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }

        sceneIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (created) {
                PopUpHide();
            } else {
                popUp.gameObject.SetActive(true);
                created = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }

    public void PopUpHide()
    {
        popUp.gameObject.SetActive(false);
        created = false;
    }

    public void Previous()
    {
        if (sceneIndex == 0 || sceneIndex == 1) {
            //Application.Quit();
            Debug.Log("게임 종료");
        }
    }
}

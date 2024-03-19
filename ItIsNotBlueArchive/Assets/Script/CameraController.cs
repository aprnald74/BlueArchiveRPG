using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    
    public static CameraController Instance = null;
    
    public GameObject player;
    public Image black;
    private Color _color;
    private Vector3 _dir;
    private Vector3 _moveVector;
    
    public float cameraSpeed = 0.5f;
    private float _changeSpeed;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        _dir = player.transform.position - this.transform.position;
        _moveVector = new Vector3(_dir.x * cameraSpeed * Time.deltaTime, _dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(_moveVector);
    }

    public IEnumerator ChangePlayer(GameObject changeCr)
    {
        _color = black.color;   
        while (black.color.a > 1)
        {
            _color.a = _color.a + (Time.deltaTime * _changeSpeed);
            black.color = _color;
        }
        
        player = changeCr;
        
        yield return new WaitForSeconds(1f);

        while (black.color.a < 0)
        {
            _color.a = _color.a - (Time.deltaTime * _changeSpeed);
            black.color = _color;
        }
    }
}

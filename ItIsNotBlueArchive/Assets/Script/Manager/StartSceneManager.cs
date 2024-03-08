using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{

    public Image startLogo;
    public TextMeshProUGUI startText;

    private float pingPongValue;
    private float fadeSpeed = 0.5f;

    private Color _startLoge;
    private Color _startText;

    void Awake()
    {
        startLogo = GameObject.Find("StartButton").GetComponent<Image>();
        startText = GameObject.Find("StartText").GetComponent<TextMeshProUGUI>();

        _startLoge = startLogo.color;
        _startText = startText.color;
    }
    
    void Update()
    {
        pingPongValue = Mathf.PingPong(Time.time * fadeSpeed, 1.0f);
        
        _startLoge.a = Mathf.SmoothStep(0.2f, 1.0f, pingPongValue);
        _startText.a = _startLoge.a;

        startLogo.color = _startLoge;
        startText.color = _startText;

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) {
                if (GameManager.Instance.IsPopHide)
                {
                    GameManager.Instance.PopUpHide();
                } else {
                    GameManager.Instance.SceneIndex = 1;
                    SceneManager.LoadScene("GameScene");
                }
            }
        }
    }
}

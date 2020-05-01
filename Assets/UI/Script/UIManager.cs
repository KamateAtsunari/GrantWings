using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image bullet = null;
    [SerializeField]
    private Image missile = null;
    //　タイマー表示用テキスト
    [SerializeField]
    private Text timerText = null;
    [SerializeField]
    private Text scoreText = null;


    //　前のUpdateの時の秒数
    private float oldSeconds;
    private int minute;
    private float seconds;
    private int weponNum = 0;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (weponNum == 0)
            {
                bullet.color = new Color(0.0f, 0.35f, 0.0f);
                missile.color = new Color(0.0f, 0.85f, 0.0f);
                weponNum = 1;
            }
            else
            {
                bullet.color = new Color(0.0f, 0.85f, 0.0f);
                missile.color = new Color(0.0f, 0.35f, 0.0f);
                weponNum = 0;
            }
        }
        TimeManager();
        
    }
    public void TimeManager()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:"+score.ToString("00000");
        if(score >= 2000)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}

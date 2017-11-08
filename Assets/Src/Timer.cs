using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Score score;
    public Text timer;
    [SerializeField]
    private float countdown = 60;
    private bool isShowResult = true;
    [SerializeField]
    private GameObject pnlResult;
	
	// Update is called once per frame
	void Update () {
        if(countdown >= 0)
        {
            countdown -= Time.deltaTime;
            timer.text = countdown.ToString("0");
        }
        else
        {
            Destroy(timer);
            Debug.Log(score.score);
            if (isShowResult)
            {
                showResult(pnlResult);
                isShowResult = false;
                Time.timeScale = 0;
                Cursor.visible = true;
            }
        }
        
	}

    public void showResult(GameObject panel)
    {
        panel.SetActive(true);
    }
}

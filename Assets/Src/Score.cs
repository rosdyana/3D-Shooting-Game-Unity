using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public PlayerShoot ps;
    public Text scoreText;
    [SerializeField]
    private int point = 50;
    public int score = 0;
    [SerializeField]
    private int reducepoint = 25;

    private void Start()
    {
        scoreText.text = "Score : 0";
    }
    // Update is called once per frame
    void Update () {
        if (ps.addScore)
        {
            score += point;
            scoreText.text = "Score : "+score.ToString();
            ps.addScore = false;
        }
        else if (ps.reduceScore)
        {
            score -= reducepoint;
            scoreText.text = "Score : " + score.ToString();
            ps.reduceScore = false;
        }

	}
}

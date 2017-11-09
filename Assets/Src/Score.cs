using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public PlayerShoot ps;
    public Text scoreText;
    [SerializeField]
    private int point = 50;
    public int score = 0;

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

	}
}

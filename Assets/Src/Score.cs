using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public PlayerShoot ps;
    public Text scoreText;
    [SerializeField]
    private int point = 50;
	
	// Update is called once per frame
	void Update () {
        if (ps.hitme)
            scoreText.text += point.ToString();
	}
}

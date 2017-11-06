using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timer;
    [SerializeField]
    private float countdown = 60;
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        timer.text = countdown.ToString("0");
	}
}

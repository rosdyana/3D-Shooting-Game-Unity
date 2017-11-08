using UnityEngine;
using System.Collections;

public class soundMgr : MonoBehaviour {

    public void playSound(AudioSource audio)
    {
        audio.Play();
    }

    public void stopSound(AudioSource audio)
    {
        audio.Stop();
    }

    public void pauseSound(AudioSource audio)
    {
        audio.Pause();
    }

    public void unPauseSound(AudioSource audio)
    {
        audio.UnPause();
    }

}

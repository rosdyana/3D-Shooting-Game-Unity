using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadScene(int idxLevel)
    {
        StartCoroutine(LoadAsynchornously(idxLevel));
    }

    public void openAbout(GameObject panel)
    {
        panel.SetActive(true);
    }

    IEnumerator LoadAsynchornously (int sceneIdx)
    {
        yield return new WaitForSeconds(1);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIdx);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}

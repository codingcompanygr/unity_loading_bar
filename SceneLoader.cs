using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;

    public void LevelLoading (int scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(int scene)
    {
        AsyncOperation ops = SceneManager.LoadSceneAsync(scene);

        loadingScreen.SetActive(true);

        while(ops.isDone == false)
        {
            float progress = Mathf.Clamp01(ops.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}

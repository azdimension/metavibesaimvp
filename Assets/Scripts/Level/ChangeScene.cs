using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    private bool canFade;
    private bool canClear;
    private float currentFadeProgress = 0f;
    [SerializeField] List<GameObject> FadeImages;

    public void Start()
    {
        StartCoroutine(ClearScreenScene());
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSceneFade(string sceneName)
    {
        StartCoroutine(FadeScene(sceneName));
    }

    IEnumerator FadeScene(string sceneName)
    {
        canFade = true;
        canClear = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator ClearScreenScene()
    {
        yield return new WaitForSeconds(0.5f);
        canClear = true;
    }

    void DisableAllRays()
    {

    }

    private void Update()
    {
        if (canFade == true)
        {
            currentFadeProgress -= Time.deltaTime * 100;
            foreach (GameObject images in FadeImages)
            {
                for (int i = 0; i < images.transform.childCount; ++i)
                {
                    Image currentImage = images.transform.GetChild(i).GetComponent<Image>();
                    Color fadeAlpha = currentImage.color;
                    fadeAlpha.a = 1 - (currentFadeProgress / 100f);
                    currentImage.color = fadeAlpha;
                }

            }

        }

        if (canClear & currentFadeProgress < 100f)
        {
            currentFadeProgress += Time.deltaTime * 60;
            foreach (GameObject images in FadeImages)
            {
                for (int i = 0; i < images.transform.childCount; ++i)
                {
                    Image currentImage = images.transform.GetChild(i).GetComponent<Image>();
                    Color fadeAlpha = currentImage.color;
                    fadeAlpha.a = 1 - (currentFadeProgress / 100f);
                    currentImage.color = fadeAlpha;
                }

            }

        }
        else
        {
            canClear = false;
        }


    }
}

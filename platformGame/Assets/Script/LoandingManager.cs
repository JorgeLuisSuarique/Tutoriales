using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoandingManager : MonoBehaviour
{
    [SerializeField]
    private string sceneLoad;
    [SerializeField]
    private Text porcenText;
    [SerializeField]
    private Image proImagen;

	void Start ()
    {
        StartCoroutine(LoadScene());
	}

    IEnumerator LoadScene()
    {
        AsyncOperation loading;
        loading = SceneManager.LoadSceneAsync(sceneLoad,LoadSceneMode.Single);
        loading.allowSceneActivation = false;
        while (loading.progress < 0.9f)
        {
            porcenText.text = string.Format("{0}%", loading.progress * 100);
            proImagen.fillAmount = loading.progress;
            yield return null;
        }
        porcenText.text = "100%";
        proImagen.fillAmount = 1;
        loading.allowSceneActivation = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public SoundService soundService;

   public void LoadScene(string sceneToLoad)
    {
        soundService.PlaySoundEffects(SoundType.BUTTON_CLICK);
        StartCoroutine(LoadSceneDelayed(sceneToLoad));
    }
    IEnumerator LoadSceneDelayed(string sceneToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void RestartLevel()
    {
        soundService.PlaySoundEffects(SoundType.BUTTON_CLICK);
        StartCoroutine(RestartSceneDelayed());
    }

    IEnumerator RestartSceneDelayed()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

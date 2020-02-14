using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    public static bool IsSceneNameValid(string name, string name2)
    {
        //if (name != name2)
        //    return false;
        return true;
    }

    public static IEnumerator ChangeScene(string newSceneName, string oldSceneName, Action action)
    {
        yield return new WaitForSeconds(2f);

        if (IsSceneNameValid(newSceneName, oldSceneName))
        {
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        }

        UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(newSceneName));

        if (IsSceneNameValid(oldSceneName, newSceneName)
            && !string.IsNullOrEmpty(newSceneName))
        {
            yield return new WaitForEndOfFrame();
            //SceneManager.UnloadScene(oldSceneName);
        }

        yield return new WaitForSeconds(1f);

        action();
    }

    public static IEnumerator UnloadCurrentScene(Action action)
    {
        yield return new WaitForSeconds(1f);
        yield return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        yield return new WaitForSeconds(1f);
        action();
    }
}

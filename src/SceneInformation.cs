using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInformation
{
    public static string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}

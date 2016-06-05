using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

[InitializeOnLoad]
public class AutosaveOnRun
{
    static AutosaveOnRun()
    {
        EditorApplication.playmodeStateChanged = () =>
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                
                Debug.Log("Auto-Saving scene before entering Play mode: " + EditorSceneManager.GetActiveScene());

                //EditorApplication.SaveScene();
                EditorSceneManager.SaveOpenScenes();

                EditorApplication.SaveAssets();
            }
        };
    }
}
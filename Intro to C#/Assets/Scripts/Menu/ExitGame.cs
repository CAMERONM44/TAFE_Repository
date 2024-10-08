using UnityEditor;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}

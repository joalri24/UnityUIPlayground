using UnityEngine;
using UnityEditor;

public class ClickableMatrix : EditorWindow
{

    #region ----------------------- Attributes -----------------------
    #endregion ----------------------- -----------------------

    #region ----------------------- Methods -----------------------
    #endregion ----------------------- -----------------------

    /// <summary>
    /// Open the window when the menu item is clicked.
    /// </summary>
    [MenuItem("Window/Clickable matrix")]
    public static void ShowWindow()
    {
        GetWindow<ClickableMatrix>();
    }

    /// <summary>
    /// The Window code goes here.
    /// </summary>
    private void OnGUI()
    {
        GUILayout.Box("New box");
    }


}

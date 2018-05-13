using UnityEditor;
using UnityEngine;

public class MinSizeWindow : EditorWindow
{
    #region --------------- Methods ---------------

    [MenuItem("Window/MinSizeWindow")]
    public static void OpenWindow()
    {
        MinSizeWindow window = (MinSizeWindow)GetWindow(typeof(MinSizeWindow));
        window.minSize = new Vector2(400f,400f);

    }
    #endregion

}

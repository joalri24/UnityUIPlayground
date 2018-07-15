using UnityEditor;
using UnityEngine;

public class InstantiatePrefab : EditorWindow
{

    #region ------------------ Private attributes ------------------

    /// <summary>
    /// The prefab to instantiate
    /// </summary>
    private GameObject prefab;

    /// <summary>
    /// Instance of this window.
    /// </summary>
    static private InstantiatePrefab window;

    #endregion 
    // -----------------------------------------------------

    #region ------------------ Regular Methods ------------------

    /// <summary>
    /// Opens the Window when the corresponding Menu Item is clicked.
    /// </summary>
    [MenuItem("Window/Instantiate prefab")]
    private static void OpenWindow()
    {
        window = (InstantiatePrefab)GetWindow(typeof(InstantiatePrefab));
        window.Show();
    }

    /// <summary>
    /// Draws the GUI. Is called approximately once per frame.
    /// </summary>
    private void OnGUI()
    {
        #region -- Prefab Horizontal --
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab: ");
        prefab = (GameObject)EditorGUILayout.ObjectField(prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();
        #endregion
        

        #region -- Help Boxes and Button Save --

        if (prefab == null)
        {
            EditorGUILayout.HelpBox("A prefab is required.", MessageType.Warning);
        }
        else if (GUILayout.Button("Place on scene", GUILayout.Height(30)))
        {
            //window.Close();
            PlaceObject(prefab);
        }
        #endregion
    }
    #endregion


    #region ------------------ Auxilar methods ------------------

    /// <summary>
    /// Instantiates an object from the prefab given and places it on the scene.
    /// The new object is placed in the 0,0,0 position.
    /// </summary>
    /// <param name="prefab">Prefab to instantiate</param>
    private void PlaceObject(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    #endregion
}

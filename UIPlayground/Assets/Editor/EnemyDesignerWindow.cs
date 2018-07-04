using Types;
using UnityEditor;
using UnityEngine;

public class EnemyDesignerWindow : EditorWindow
{

    #region ------------------ Private attributes ------------------

    private Texture2D headerSectionTexture;
    private Texture2D mageSectionTexture;
    private Texture2D warriorSectionTexture;
    private Texture2D rogueSectionTexture;
    private Texture2D mageIconTexture;

    private Color headerSectionColor =new Color(13f/255, 32f/255, 44f/255);

    private Rect headerSection;
    private Rect mageSection;
    private Rect warriorSection;
    private Rect rogueSection;
    private Rect mageIconSection;

    //private GUIStyle textStyle;

    private GUISkin skin;

    private static MageData mageData;
    private static WarriorData warriorData;
    private static RougeData rogueData;

    private float iconSize = 30f;

    #endregion


    #region ------------------ Public Properties ------------------

    public static MageData MageInfo{ get { return mageData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }
    public static RougeData RogueInfo { get { return rogueData; } }

    #endregion

    #region ------------------ Methods ------------------

    /// <summary>
    /// Opens the Window when the corresponding Menu Item is clicked.
    /// </summary>
    [MenuItem("Window/Enemy Designer")]
    private static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600, 200);
        window.Show();
    }

    /// <summary>
    /// Similar to Start() or Awake().
    /// </summary>
    private void OnEnable()
    {
        //textStyle = new GUIStyle();
        //textStyle.normal.textColor = Color.white;
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("GuiStyles/EnemyDesignerSkin");
    }

    public void InitData()
    {
        mageData = (MageData) CreateInstance(typeof(MageData));
        warriorData = (WarriorData)CreateInstance(typeof(WarriorData));
        rogueData = (RougeData)CreateInstance(typeof(RougeData));

    }

    /// <summary>
    /// Initializes all Texture2D values.
    /// </summary>
    private void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("icons/editor_mage");
        rogueSectionTexture = Resources.Load<Texture2D>("icons/editor_rogue");
        warriorSectionTexture = Resources.Load<Texture2D>("icons/editor_warrior");

        mageIconTexture = Resources.Load<Texture2D>("icons/editor_mageIcon");
    }

    /// <summary>
    /// Similar to Update methods.
    /// Not called once per frame: called 1 or ore times per interaction.
    /// </summary>
    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRogueSettings();
    }

    /// <summary>
    /// Defines Rect values and paints Textures based on those Rects
    /// </summary>
    private void DrawLayouts()
    {
        headerSection.y = 0;
        headerSection.x = 0;
        headerSection.width = position.width;
        headerSection.height = 50;

        mageSection.y = 50;
        mageSection.x = 0;
        mageSection.width = position.width / 3f;
        mageSection.height = position.height - 50;

        mageIconSection.x = (mageSection.x + mageSection.width / 2f) - iconSize / 2 ;
        mageIconSection.y = mageSection.y + 8;
        mageIconSection.width = iconSize;
        mageIconSection.height = iconSize;

        rogueSection.y = 50;
        rogueSection.x = position.width / 3f;
        rogueSection.width = position.width / 3f;
        rogueSection.height = position.height - 50;

        warriorSection.y = 50;
        warriorSection.x = 2 * position.width / 3f;
        warriorSection.width = position.width / 3f;
        warriorSection.height = position.height - 50;


        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(mageIconSection, mageIconTexture);


    }

    /// <summary>
    /// Draws content of the header.
    /// </summary>
    private void DrawHeader()
    {
        #region Area(headerSection)
        GUILayout.BeginArea(headerSection);

        //GUILayout.Label("Enemy Designer", textStyle);
        GUILayout.Label("Enemy Designer", skin.GetStyle("H1"));

        GUILayout.EndArea();
        #endregion
    }

    /// <summary>
    /// Draws content of the Mage Settings section.
    /// </summary>
    private void DrawMageSettings()
    {
        #region --- Area(mageSection) ---
        GUILayout.BeginArea(mageSection);

        GUILayout.Space(iconSize + 8f);

        GUILayout.Label("Mage", skin.GetStyle("MageH"));

        #region -- Damage type Horizontal --
        GUILayout.BeginHorizontal();
        GUILayout.Label("Damage Type: ", skin.GetStyle("MageInput"));
        mageData.dmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        GUILayout.EndHorizontal();
        #endregion

        #region -- Weapon type Horizontal --
        GUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type: ", skin.GetStyle("MageInput"));
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        GUILayout.EndHorizontal();
        #endregion

        #region -- Button Create --
        if(GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingType.Mage);
        }
        #endregion

        GUILayout.EndArea();
        #endregion
    }

    /// <summary>
    /// Draws content of the Warrior Settings section.
    /// </summary>
    private void DrawWarriorSettings()
    {
        #region Area(warriorSection)
        GUILayout.BeginArea(warriorSection);

        GUILayout.Label("Warrior", skin.GetStyle("WarriorH"));

        #region Class type Horizontal
        GUILayout.BeginHorizontal();
        GUILayout.Label("Class Type: ", skin.GetStyle("WarriorInput"));
        warriorData.classType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        GUILayout.EndHorizontal();
        #endregion

        #region Weapon type Horizontal
        GUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type: ", skin.GetStyle("WarriorInput"));
        warriorData.wpnType = (WarrirorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        GUILayout.EndHorizontal();
        #endregion

        #region -- Button Create --
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingType.Warrior);
        }
        #endregion

        GUILayout.EndArea();
        #endregion
    }

    /// <summary>
    /// Draws content of the Rogue Settings section.
    /// </summary>
    private void DrawRogueSettings()
    {
        #region Area(RogueSection)
        GUILayout.BeginArea(rogueSection);

        GUILayout.Label("Rogue", skin.GetStyle("RogueH"));

        #region Weapon type Horizontal
        GUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type: ", skin.GetStyle("RogueInput"));
        rogueData.wpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.wpnType);
        GUILayout.EndHorizontal();
        #endregion

        #region Strategy type Horizontal
        GUILayout.BeginHorizontal();
        GUILayout.Label("Strategy Type: ", skin.GetStyle("RogueInput"));
        rogueData.strategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.strategyType);
        GUILayout.EndHorizontal();
        #endregion

        #region -- Button Create --
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingType.Rogue);
        }
        #endregion

        GUILayout.EndArea();
        #endregion
    }

    #endregion


    public class GeneralSettings : EditorWindow
    {
        public enum SettingType
        {
            Mage,
            Warrior,
            Rogue
        }

        static SettingType dataSettings;
        static GeneralSettings window;

        public static void OpenWindow(SettingType setting)
        {
            dataSettings = setting;
            window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
            window.minSize = new Vector2(250f, 200f);
            window.Show();
        }

        private void OnGUI()
        {
            switch(dataSettings)
            {
                case SettingType.Mage:
                    DrawSettings(MageInfo);
                    break;

                case SettingType.Warrior:
                    DrawSettings(WarriorInfo);
                    break;

                case SettingType.Rogue:
                    DrawSettings(RogueInfo);
                    break;

                default:
                    break;

            }
        }

        private void DrawSettings(CharacterData charData )
        {
            #region -- Prefab Horizontal --
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Prefab: ");
            charData.prefab = (GameObject) EditorGUILayout.ObjectField(charData.prefab, typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region -- Max Health Horizontal --
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Max Health: ");
            charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region -- Max Energy Horizontal --
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Max Energy: ");
            charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region -- Power Horizontal--
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Power: ");
            charData.power = EditorGUILayout.Slider(charData.power, 0, 100);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region -- % Critical chance Horizontal --
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("% Critical chance: ");
            charData.critChance = EditorGUILayout.Slider(charData.critChance, 0, charData.power);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region -- Name Horizontal --
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Name: ");
            charData.name = EditorGUILayout.TextField(charData.name);
            charData.characterName = charData.name;
            EditorGUILayout.EndHorizontal();
            #endregion

            #region -- Help Boxes and Button Save --

            if (charData.prefab == null)
            {
                EditorGUILayout.HelpBox("This unit need a [Prefab] before it can be saved.", MessageType.Warning);
            }
            else if(string.IsNullOrEmpty(charData.name))
            {
                EditorGUILayout.HelpBox("This unit need a [Name] before it can be saved.", MessageType.Warning);
            }
            else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
            {
                SaveCharacterData();
                window.Close();
            }
            #endregion
        }



        private void SaveCharacterData()
        {
            string prefabPath; // path to the new prefab
            string newPrefabPath = "Assets/Prefabs/characters/";
            string dataPath = "Assets/Resources/CharacterData/data/";

            switch (dataSettings)
            {
                case SettingType.Mage:
                    #region case: Mage
                    // Create de .asset file
                    dataPath += "Mage/" + EnemyDesignerWindow.MageInfo.name + ".asset";
                    AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                    newPrefabPath += "Mages/" + EnemyDesignerWindow.MageInfo.name + ".prefab";
                    // Get prefab path
                    prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.prefab);
                    AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

                    if (!magePrefab.GetComponent<Mage>())
                        magePrefab.AddComponent(typeof(Mage));
                    magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.MageInfo;
                    break;
                    #endregion

                case SettingType.Warrior:
                    #region case: Warrior
                    // Create de .asset file
                    dataPath += "Warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".asset";
                    AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                    newPrefabPath += "Warriors/" + EnemyDesignerWindow.WarriorInfo.name + ".prefab";
                    // Get prefab path
                    prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.prefab);
                    AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

                    if (!warriorPrefab.GetComponent<Warrior>())
                        warriorPrefab.AddComponent(typeof(Warrior));
                    warriorPrefab.GetComponent<Warrior>().warriorData = EnemyDesignerWindow.WarriorInfo;
                    break;
                #endregion

                case SettingType.Rogue:
                    #region case: Rogue
                    // Create de .asset file
                    dataPath += "Rogue/" + EnemyDesignerWindow.RogueInfo.name + ".asset";
                    AssetDatabase.CreateAsset(EnemyDesignerWindow.RogueInfo, dataPath);

                    newPrefabPath += "Rogues/" + EnemyDesignerWindow.RogueInfo.name + ".prefab";
                    // Get prefab path
                    prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RogueInfo.prefab);
                    AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                    GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

                    if (!roguePrefab.GetComponent<Rouge>())
                        roguePrefab.AddComponent(typeof(Rouge));
                    roguePrefab.GetComponent<Rouge>().rogueData = EnemyDesignerWindow.RogueInfo;
                    break;
                #endregion

                default:
                    break;
            }
        }
    }

}

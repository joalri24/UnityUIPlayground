using UnityEngine;

public class CharacterData : ScriptableObject
{

    #region Public attributes

    public GameObject prefab;
    public float maxHealth;
    public float maxEnergy;
    public float critChance;
    public float power;
    public string characterName;

    #endregion
}

using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
public class RougeData : CharacterData
{
    public RogueWpnType wpnType;
    public RogueStrategyType strategyType;
}

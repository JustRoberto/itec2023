using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmojiScriptableObject", menuName = "ScriptableObjects/EmojiData", order = 1)]
public class EmojiScriptableObject : ScriptableObject
{
    public string Name;
    public string ID;
    [TextAreaAttribute]
    public string Description;
    public string Type;
    public Sprite Sprite;

    public int BaseHealth;
    public int BaseAttack;

    public int AbilityBaseDamage;
    public int AbilityBaseBoost;

}

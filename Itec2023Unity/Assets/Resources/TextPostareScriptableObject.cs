using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextPostare", menuName = "ScriptableObjects/TextPostare", order = 1)]
public class TextPostareScriptableObject : ScriptableObject
{
    [TextAreaAttribute]
    public string Text;

    public List<string> PerfectMatch;
    public List<string> GoodMatch;
    public List<string> BadMatch;
    public List<string> HorribleMatch;


    public string GetMatchType(string emojiName)
    {
        if (PerfectMatch.Contains(emojiName.ToLower()))
            return "Perfect";
        else if (GoodMatch.Contains(emojiName.ToLower()))
            return "Good";
        else if (BadMatch.Contains(emojiName.ToLower()))
            return "Bad";
        else if (HorribleMatch.Contains(emojiName.ToLower()))
            return "Horrible";
        else return "Neutral";
    }
}

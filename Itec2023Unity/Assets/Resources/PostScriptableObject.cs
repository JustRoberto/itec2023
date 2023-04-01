using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PostObject", menuName = "ScriptableObjects/Post", order = 1)]
public class PostScriptableObject : ScriptableObject
{
    [TextAreaAttribute]
    public string Text;
    public Sprite Image;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ImageScriptableObject", menuName = "ScriptableObjects/ImagePostare", order = 2)]
public class ImagePostareScriptableObject  : ScriptableObject
{
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

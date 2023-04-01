using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<EmojiScriptableObject> emojis;
    public Transform parent;
    public GameObject emojiprefab;
    void Start()
    {

    }
    public void Add(EmojiScriptableObject emoji)
    {
       var em = Instantiate(emojiprefab, parent);
        em.GetComponent<EmojiController>().data = emoji;
        emojis.Add(emoji);
    }
}

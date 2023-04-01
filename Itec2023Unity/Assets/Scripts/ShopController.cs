using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    List<EmojiScriptableObject> emojisInStock;
    List<EmojiScriptableObject> availableEmojis; //ass data
    public GameObject EmojiPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //get all types of Emoji
        availableEmojis = new List<EmojiScriptableObject>();
        emojisInStock = new List<EmojiScriptableObject>();
        var allEmoji = Resources.LoadAll("Emojis", typeof(EmojiScriptableObject));
        foreach (EmojiScriptableObject e in allEmoji)
        {
            Debug.Log(e.Name);
            availableEmojis.Add(e);
        }
        //Initially Load 5
         RollShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void RollShop()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, availableEmojis.Count );
            emojisInStock.Add(availableEmojis[rand]);
            GameObject em = Instantiate(EmojiPrefab, this.transform);
            em.GetComponent<EmojiController>().data = availableEmojis[rand];
        }
    }
}
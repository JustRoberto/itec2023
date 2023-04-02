using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public void AddToPlayerDeckFromShop(EmojiScriptableObject emoji)
    {
        var em = Instantiate(emojiprefab, parent);
        em.GetComponent<EmojiController>().data = emoji;
        em.GetComponent<EmojiController>().CopyValuesFromData();
        //em.GetComponent<EmojiController>().Attack = Attack;
        //em.GetComponent<EmojiController>().Health = Health;
        em.GetComponent<EmojiController>().RefreshStats();
}
    public void InsertEnemy(EmojiScriptableObject emoji)
    {

        var em = Instantiate(emojiprefab, parent);
        em.GetComponent<EmojiController>().data = emoji;
        em.GetComponent<EmojiController>().CopyValuesFromData();
        emojis.Add(emoji);
    }
    public void InsertEmojiINBattle(GameObject emoji)
    {

        var em = Instantiate(emoji, parent);
        Debug.Log(emoji.GetComponent<EmojiController>().Attack);
        Debug.Log(em.GetComponent<EmojiController>().Attack);
        //em.GetComponent<EmojiController>().data = emoji;
        //em.GetComponent<EmojiController>().Attack = Attack;
        //em.GetComponent<EmojiController>().Health = Health;
        em.GetComponent<EmojiController>().RefreshStats();
        //emojis.Add(emoji.GetComponent<EmojiController>().data);
    }

    public void Shuffle()
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child);
        }

        for (int i = 0; i < children.Count; i++)
        {
            int randomIndex = Random.Range(i, children.Count);
            Transform temp = children[i];
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        foreach (Transform child in children)
        {
            child.SetSiblingIndex(Random.Range(0, children.Count));
        }
    }
    public List<GameObject> getTeam()
    {
        var list = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {

            list.Add(child.gameObject);

        }
        return list;
    }

public void EmptyDeck()
{
    foreach (Transform child in parent.transform)
    {
        Destroy(child.gameObject);
    }
}
}

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
    public void Add(EmojiScriptableObject emoji)
    {
        var em = Instantiate(emojiprefab, parent);
        em.GetComponent<EmojiController>().data = emoji;
        emojis.Add(emoji);
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
        foreach (Transform child in transform)
        {
            if (child.name == "Content")
            {
                foreach (Transform child1 in child.transform)
                {
                    list.Add(child1.gameObject);
                }
            }
            
        }
        return list;
    }
}

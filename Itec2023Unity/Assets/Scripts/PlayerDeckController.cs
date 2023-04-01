using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckController : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> emojis;

    void Start()
    {
        foreach (Transform child in transform)
        {
            emojis.Add(child.gameObject);
        }
    }

}

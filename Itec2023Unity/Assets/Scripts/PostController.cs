using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    public List<PostScriptableObject> AvailablePost;
    public TextMeshProUGUI  textMesh;
    public Image Image;
    // Start is called before the first frame update
    void Awake()
    {
        
        var texts = Resources.LoadAll("Posts", typeof(PostScriptableObject));
        foreach (var t in texts)
        {
            AvailablePost.Add(t as PostScriptableObject);
        }


        int randomNum = Random.Range(0, AvailablePost.Count);
        textMesh.text = AvailablePost[randomNum].Text;
        Image.sprite = AvailablePost[randomNum].Image;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    public List<TextPostareScriptableObject> AvailableTexts;
    public List<ImagePostareScriptableObject> AvailableImages;
    public TextMeshProUGUI  textMesh;
    public Image Image;
    // Start is called before the first frame update
    void Awake()
    {
        
        var texts = Resources.LoadAll("Texts", typeof(TextPostareScriptableObject));
        var images = Resources.LoadAll("Images", typeof(ImagePostareScriptableObject));
        foreach (var t in texts)
        {
            AvailableTexts.Add(t as TextPostareScriptableObject);
        }
        foreach (var i in images)
        {
            AvailableImages.Add(i as ImagePostareScriptableObject);
        }

        int randomNum = Random.Range(0, AvailableTexts.Count);
        textMesh.text = AvailableTexts[randomNum].Text;
        randomNum = Random.Range(0, AvailableImages.Count);
        Image.sprite = AvailableImages[randomNum].Image;
    }

}

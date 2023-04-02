using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class DescriptionPopUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float popupDuration = 1f;
    public string popupText = "Object Description";

    private bool isHovering = false;
    private float hoverTime = 0f;
    private GameObject popupObject;
    private Text popupTextComponent;
    public GameObject PopUP;

    private void Start()
    {
        popupObject = Instantiate(PopUP,this.transform);
        popupObject.transform.localPosition = new Vector3(0,150,0);
     
        //popupTextComponent = popupObject.AddComponent<Text>();
        //popupTextComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        //popupTextComponent.color = Color.white;
        //popupTextComponent.alignment = TextAnchor.MiddleCenter;
        //popupTextComponent.rectTransform.sizeDelta = new Vector2(200f, 50f);

        popupObject.SetActive(false);
    }

    private void Update()
    {
        if (isHovering)
        {
            hoverTime += Time.deltaTime;

            if (hoverTime >= popupDuration)
            {
                ShowPopup();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        hoverTime = 0f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        hoverTime = 0f;
        HidePopup();
    }

    private void ShowPopup()
    {
        string desc = this.gameObject.GetComponent<EmojiController>().data.Description; 
        string name = this.gameObject.GetComponent<EmojiController>().data.Name;
        popupObject.GetComponentInChildren<TextMeshProUGUI>().text = $"{name}: \n Ability: {desc} \n Costs 3 Likes";
        popupObject.SetActive(true);
    }

    private void HidePopup()
    {
        popupObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmojiController : MonoBehaviour
{
    public EmojiScriptableObject data;
    public Image Image;
    public TextMeshProUGUI AttackValue;
    public TextMeshProUGUI HealthValue;

    public int Health;
    public int Attack;


    public object Gameobject { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Image.sprite = data.Sprite;
        Health = data.BaseHealth;
        Attack = data.BaseAttack;
        RefreshStats();
    }

  public void Damage(int dmg)
    {
        Health -= dmg; // - resistances mby
        RefreshStats();
    }
    public void RefreshStats()
    {
        AttackValue.text = Attack.ToString();
        HealthValue.text = Health.ToString();
    }
    public void Buy()
    {
        if (this.transform.parent.gameObject.name == "Shop")
        {
            if (GameManager.instance.money >= 3)
            {
                GameManager.instance.playerDeck.Add(this.data);
                GameManager.instance.money -= 3;
                GameManager.instance.moneyText.text = GameManager.instance.money.ToString();
                Destroy(this.gameObject);
            }
        }
    }
}

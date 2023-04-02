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
    public GameObject UpgradeButton;

    public int Health;
    public int Attack;


    public object Gameobject { get; private set; }

    // Start is called before the first frame update

    public void Start()
    {
        if (GameManager.instance.InShop == false || this.transform.parent.gameObject.name == "Shop")
        {
            UpgradeButton.SetActive(false);
        }
    }

   public void CopyValuesFromData()
    {
        Image.sprite = data.Sprite;
        Health = data.BaseHealth;
        Attack = data.BaseAttack;
        RefreshStats();
    }
   public void Upgrade ()
    {
        if (GameManager.instance.money >= 3)
        {
            Attack += 2;
            RefreshStats();
            GameManager.instance.money -= 4;
            GameManager.instance.moneyText.text = GameManager.instance.money.ToString();
            UpgradeButton.SetActive(false);
        }
    }
  public void Damage(int dmg)
    {
        
        Health -= dmg; // - resistances mby
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
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
                GameManager.instance.playerDeck.AddToPlayerDeckFromShop(this.data);
                GameManager.instance.money -= 3;
                GameManager.instance.moneyText.text = GameManager.instance.money.ToString();
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScreenController screen;
    public PlayerDeckController playerDeck;
    public PlayerDeckController playerAttackDeck;
    public PlayerDeckController enemyAttackDeck;
    public ShopController shop;
    public SoundController SoundController;

    public List<GameObject> playerTeam;
    public List<GameObject> enemyTeam;
    public TextMeshProUGUI moneyText;
    public int money= 10;
    private void Awake()
    {
        money = 10;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Ready()
    {
       foreach(EmojiScriptableObject emoji in playerDeck.emojis)
        {
            
            playerAttackDeck.Add(emoji);
            

        }
        var availableEmojis = new List<EmojiScriptableObject>();
        var allEmoji = Resources.LoadAll("Emojis", typeof(EmojiScriptableObject));
        foreach (EmojiScriptableObject e in allEmoji)
        {
            availableEmojis.Add(e);
        }
        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, availableEmojis.Count);
            enemyAttackDeck.Add(availableEmojis[rand]);

        }
    }

    public void Shuffle(List<PlayerDeckController> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
    public void StartBattle()
    {
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();

    }

    public void Fight()
    {
        GameManager.instance.SoundController.PlayRandomSound();
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();
        CheckIfWin();
        try
        {
            playerTeam.Last().GetComponent<EmojiController>().Damage(enemyTeam.Last().GetComponent<EmojiController>().Attack);
            enemyTeam.Last().GetComponent<EmojiController>().Damage(playerTeam.Last().GetComponent<EmojiController>().Attack);
        }
        catch(System.Exception e)
        {

        }
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();


    }

    public void CheckIfWin() {
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();


        if (!playerTeam.Any() && !enemyTeam.Any() ) // Draw
        {
            money += 11;
            moneyText.text = money.ToString();

            playerDeck.EmptyDeck();
            screen.StartMovingReverse();

            playerAttackDeck.EmptyDeck();
            enemyAttackDeck.EmptyDeck();
            playerDeck.emojis.Clear();
            shop.RollShop();
        }
        else if(playerTeam.Any() && !enemyTeam.Any()) //Castig
        {
            money += playerTeam.Count + 11;
            moneyText.text = money.ToString();

            playerDeck.EmptyDeck();
            screen.StartMovingReverse();

            playerAttackDeck.EmptyDeck();
            enemyAttackDeck.EmptyDeck();
            playerDeck.emojis.Clear();
            shop.RollShop();

        }
        else if (!playerTeam.Any() && enemyTeam.Any()) // Lose
        {
            money += 11;
            moneyText.text = money.ToString();

            playerDeck.EmptyDeck();
            screen.StartMovingReverse();
            enemyAttackDeck.EmptyDeck();

            playerAttackDeck.EmptyDeck();
            enemyAttackDeck.EmptyDeck();
            playerDeck.emojis.Clear();
            shop.RollShop();
        }
    }
}
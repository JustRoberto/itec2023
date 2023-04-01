using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerDeckController playerDeck;
    public PlayerDeckController playerAttackDeck;
    public PlayerDeckController enemyAttackDeck;

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
            enemyAttackDeck.Add(emoji);
            enemyAttackDeck.Shuffle();
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
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();
        foreach (var item in enemyTeam)
        {
            Debug.Log(item.name);
        }
        playerTeam.Last().GetComponent<EmojiController>().Damage(enemyTeam.Last().GetComponent<EmojiController>().Attack);
        enemyTeam.Last().GetComponent<EmojiController>().Damage(playerTeam.Last().GetComponent<EmojiController>().Attack);
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();
    }

}
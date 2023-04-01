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
        playerTeam.Last().GetComponent<EmojiController>().Damage(1);
        enemyTeam.Last().GetComponent<EmojiController>().Damage(1);
        playerTeam = playerAttackDeck.getTeam();
        enemyTeam = enemyAttackDeck.getTeam();
    }

}
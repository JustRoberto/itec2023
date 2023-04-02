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

    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileHeight = 5f;

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
        ShakeObject(this.gameObject, 0.2f, 3);

    }
  
    public void FireProjectile(Vector2 startPos, Vector2 endPos)
    {
        GameObject projectile = Instantiate(projectilePrefab, startPos, Quaternion.identity);
        Image projectileImage = projectile.GetComponent<Image>();
        float distance = Vector2.Distance(startPos, endPos);
        float travelTime = distance / projectileSpeed;
        Vector2 midPoint = (startPos + endPos) / 2f;
        midPoint.y += projectileHeight;
        projectile.transform.SetParent(GameObject.Find("Canvas").transform);
        projectile.transform.SetAsLastSibling();

        StartCoroutine(MoveProjectile(projectile.transform, midPoint, travelTime / 2f));
        StartCoroutine(MoveProjectile(projectile.transform, endPos, travelTime / 2f, travelTime / 2f));

        float angle = Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg;
        projectileImage.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private IEnumerator MoveProjectile(Transform projectileTransform, Vector2 targetPos, float time, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float timer = 0f;
        Vector2 startPos = projectileTransform.position;

        while (timer < time)
        {
            timer += Time.deltaTime;
            float t = timer / time;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            projectileTransform.position = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        projectileTransform.position = targetPos;
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

    public void ShakeObject(GameObject objToShake, float duration, float intensity)
    {
        StartCoroutine(DoShakeObject(objToShake, duration, intensity));
    }

    private IEnumerator DoShakeObject(GameObject objToShake, float duration, float intensity)
    {
        Vector3 originalPos = objToShake.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * intensity;
            float y = Random.Range(-1f, 1f) * intensity;
            objToShake.transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objToShake.transform.position = originalPos;
    }
}

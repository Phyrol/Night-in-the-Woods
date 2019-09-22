using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform healthTransform;
    private float storedY;
    private float minXVal;
    private float maxXVal;
    private int currentHP;
    public int maxHP;
    public Text healthText;
    public Image healthChange;
    public float healthBarFix;

    public Text coinText;
    private int currentCoins;

    private int CurrentHP
    {
        get {return currentHP;}
      set{currentHP = value;
            HandleHealth();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBarFix = 2.2f;
        storedY = healthTransform.position.y;
        maxXVal = healthTransform.position.x;
        minXVal = healthTransform.position.x - healthTransform.rect.width * healthBarFix;
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP == 0)
        {

        }
    }

    private void HandleHealth()
    {
        healthText.text = "Health: " + currentHP;

        float currentXValue = MapValues(currentHP, 0, maxHP, minXVal, maxXVal);
        healthTransform.position = new Vector3(currentXValue, storedY);

        if (currentHP > maxHP / 2)
        {
            healthChange.color = new Color32((byte)MapValues(currentHP, maxHP / 2, maxHP, 255, 0), 255, 0, 255);
        }
        else
        {
            healthChange.color = new Color32(255, (byte)MapValues(currentHP, 0, maxHP / 2, 0, 255), 0, 255);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Heart"))
        {
            if (currentHP < maxHP)
            {
                CurrentHP += 10;
                Destroy(collider.gameObject);
                FindObjectOfType<AudioManager>().Play("Heart Sound");
            }
        }
        else if (collider.gameObject.tag.Equals("Coin"))
        {
            currentCoins += 1;
            coinText.text = "" + currentCoins;
            Destroy(collider.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin Sound");

        }
        else if (collider.gameObject.tag.Equals("Jewel"))
        {
            currentCoins += 10;
            coinText.text = "" + currentCoins;
            Destroy(collider.gameObject);
            FindObjectOfType<AudioManager>().Play("Jewel Sound");

        }
        else if (collider.gameObject.tag.Equals("Key"))
        {
            Destroy(collider.gameObject);
            FindObjectOfType<AudioManager>().Play("Key Sound");

        }
        else if (collider.gameObject.tag.Equals("Fire"))
        {
            CurrentHP -= 2;
        }
        else if (collider.gameObject.tag.Equals("KillZone"))
        {
                CurrentHP = 0;
        }

    }

    /*
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "heart 1")
        {
            Debug.Log("Getting Health!!");
            if (currentHP <= maxHP)
            {
                CurrentHP += 10;
                Destroy(collider.gameObject);
            }
        }
        else if (collider.name == "spikesLarge")
        {
            Debug.Log("Taking Damage!!");
            if (currentHP > 0)
            {
                CurrentHP -= 10;
                Destroy(collider.gameObject);
            }

        }
        else if (collider.name == "coin")
        {
            currentCoins += 1;
            coinText.text = "" + currentCoins;
            Destroy(collider.gameObject);

        }
        else if (collider.name == "jewel 1")
        {
            currentCoins += 10;
            coinText.text = "" + currentCoins;
            Destroy(collider.gameObject);

        }
    }
    */

    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}

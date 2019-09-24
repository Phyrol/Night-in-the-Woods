using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public RectTransform healthTransform;
    private float storedY;
    private float minXVal;
    private float maxXVal;
    public int currentHP;
    public int maxHP;
    public Text healthText;
    public Image healthChange;
    public float healthBarFix;

    public Text coinText;
    private int currentCoins;

    public int CurrentHP
    {
        get
        {
            return currentHP;
        }
        set
        {
            currentHP = value;
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

    }

    private void takeDamage(int value)
    {
        CurrentHP -= value;
        if(currentHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                FindObjectOfType<AudioManager>().Play("Heart");
                CurrentHP += 10;
                Destroy(collider.gameObject);
            }
        }
        else if (collider.gameObject.tag.Equals("Coin"))
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            currentCoins += 1;
            coinText.text = "" + currentCoins;
            Destroy(collider.gameObject);

        }
        else if (collider.gameObject.tag.Equals("Jewel"))
        {
            FindObjectOfType<AudioManager>().Play("Jewel");
            currentCoins += 10;
            coinText.text = "" + currentCoins;
            Destroy(collider.gameObject);

        }
        else if (collider.gameObject.tag.Equals("KillZone"))
        {
            if (currentHP < maxHP)
            {
                FindObjectOfType<AudioManager>().Play("Damage");
                takeDamage(200);
            }
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

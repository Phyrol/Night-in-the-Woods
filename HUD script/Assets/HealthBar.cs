using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public RectTransform healthBar;
    private float storedY;
    private float minXVal;
    private float maxXVal;
    private int currentHP;
    public int maxHP;
    public Text healthText;
    public Image visualHealth;
    public float cooldown;
    private bool onCD;

    private int CurrentHP
    {
        get { return currentHP;}
        set { currentHP = value;
            HealthUpdate();
        }
    }
    // initialize all variables
    void Start()
    {
        storedY = healthBar.position.y;
        maxXVal = healthBar.position.x;
        minXVal = healthBar.position.x - healthBar.rect.width;
        currentHP = maxHP;
        onCD = false;
    }

    IEnumerator CoolDownDamage()
    {
        onCD = true;
        yield return new WaitForSeconds(cooldown);
        onCD = false;
    }

    private void HealthUpdate()
    {
        healthText.text = "Health: " + currentHP;
        float currentXVal = MapValues(currentHP, 0, maxHP, minXVal, maxXVal);
        healthBar.position = new Vector3(currentXVal, storedY);

        // more than 50% HP
        if (currentHP > maxHP / 2)
        {
            visualHealth.color = new Color32((byte)MapValues(currentHP, maxHP/2, maxHP, 255,0), 255,0,255);
        }
        else
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHP, 0, maxHP / 2, 0, 255), 0, 255);
        }
    }

    private float MapValues(float x, float Inmin, float Inmax, float outMin, float outMax)
    {
            return (x - Inmin) * (outMax - outMin) / (Inmax - Inmin) + outMin;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    [SerializeField] private int maxhealth = 10;
    [SerializeField] private int hitstun = 120;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sR;
    [SerializeField] private bool sG;
    [SerializeField] private TextMeshProUGUI txt;
    private AudioController ac;
    public bool ow = false;
    public int health = 0;
    private int hsRunner = 0;

    private CheckPointManager cpm;


    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        cpm = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<CheckPointManager>();
        ac = GameObject.FindGameObjectWithTag("prefabManager").GetComponent<AudioController>();
        updateHealth();
    }

    private void invokedActivity()
    {
        if (hsRunner >= 0)
        {
            hsRunner--;
        }
        else
        {
            anim.Play("Idle");
        }

    }
    public void addHealth(int inc)
    {
        health += inc;
        health = Mathf.Clamp(health, 0, maxhealth);
        anim.Play("Heal");
        updateHealth();
    }
    public void removeHealth(int inc) {
        if (hsRunner <= 0)
        {
            ow = true;
            health -= inc;
            hsRunner = hitstun;
            anim.Play("Hurt");
            updateHealth();
            ac.playHurting();
        }

        if (health <= 0)
            Death();
        ow = false;

    }

    private void Death()
    {
        health = maxhealth;

        if (cpm.Checks[cpm.Checks.Count - 1] == gameObject)
            gameObject.transform.position = new Vector3(26.25f, 1, 5.5f);
        else
            gameObject.transform.position = cpm.Checks[cpm.Checks.Count-1].transform.position;
        updateHealth();
    }

    private void updateHealth()
    {
        txt.text = "Hp " + health.ToString() + "/" + maxhealth.ToString();
    }
}

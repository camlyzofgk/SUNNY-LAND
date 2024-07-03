using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class move : MonoBehaviour
{
    float vertical;
    float horizontal;
    float speed;
    Rigidbody2D rb;
    public float jumpPower = 10f;
    Animator anm;
    Vector2 look;
    public GameObject bulletPrefab;
    int health;
    int maxHealth = 5;
    bool isInvincible = false;
    float invincibleTime = 1;
    float invicibleTimmer;
    Vector2 startPos;
    public int sceneIndex; //Số thứ tự màn chơi
    bool hasKey = false;



    void Start()
    {
        startPos = transform.position;
        health = maxHealth;
        speed = 10.0f;
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
        look = new Vector2(1, 0);
        
        GameConfig.GetInstance().player = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateController();
        UpdateAnimation();
        CallNPC();
        HeathUI.GetInstance().Change(health);
        

    }
    void CallNPC()
    {
        // Xác nhận player đứng bên cạch NPC
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, look, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NPC character = hit.collider.GetComponent<NPC>();
            if (character != null)
            {
                character.DisplayDialog();// Hiển thị chatbox
            }
            // Chuyển màn chơi
            if(Input.GetKeyDown(KeyCode.X))
            {
                LevelManager.instance.LoadScene(sceneIndex);
            }
        }

    }


    void Jump()
    {
        if (!isOnGround())
        {
            return;
        }
        Sound.getInstance().PlayJump();
        rb.velocity = new Vector2(rb.velocity.x,jumpPower);

    }


    void UpdateController()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (!Mathf.Approximately(rb.velocity.x, 0.0f))
        {
            look = new Vector2(rb.velocity.x, 0);
            look.Normalize();
        }
        if (Input.GetKeyDown(KeyCode.C) && GameConfig.GetInstance().UseStar())
        {
            Launch();
        }
        if (isInvincible)
            invicibleTimmer -= Time.deltaTime;
        if (invicibleTimmer < 0)
            isInvincible = false;
    }

    void UpdateAnimation()
    {

        anm.SetFloat("lookx", look.x);
        anm.SetFloat("looky", 0);
        anm.SetFloat("vx", rb.velocity.x);
        anm.SetFloat("vy", rb.velocity.y);
    }


    void Launch()
    {
        Sound.getInstance().PlayShoot();
        GameObject bulletObject = Instantiate(bulletPrefab, rb.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Launch(look, 500);
    }


    bool isOnGround()
    {
        bool mid = Physics2D.Raycast(rb.position + Vector2.left, Vector2.down, 1.9f, LayerMask.GetMask("Ground"));
        bool left = Physics2D.Raycast(rb.position, Vector2.down, 1.9f, LayerMask.GetMask("Ground"));
        bool right = Physics2D.Raycast(rb.position + Vector2.right, Vector2.down, 1.9f, LayerMask.GetMask("Ground"));
        return mid || left || right;
    }


    public void ChangeHealth(int h)
    {
        if(h > 0)
        {
            health = Mathf.Clamp(health + h, 0, 100);
            
        }
        else
        {
            if (isInvincible)
                return;
            anm.SetTrigger("hurt");
            Sound.getInstance().PlayHurt();
            health = Mathf.Clamp(health + h, 0, 100);
            isInvincible = true;
            invicibleTimmer = invincibleTime;
            rb.velocity = new Vector2(0,0);
        }
        PlayerDied(); // Nếu hết máu hiện màn hình
    }

    private void PlayerDied()
    {
        if(health <= 0) 
        {
            LevelManager.instance.GameOver();
        }
    }



    public int getCurrentHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }


    public Vector2 getOffset()
    {
        return rb.position - startPos;
    }


    public bool isHasKey()
    {
        return hasKey;
    }


    public void getKey()
    {
        hasKey = true;
    }


    public void useKey() 
    {
        hasKey = false;
    }


}

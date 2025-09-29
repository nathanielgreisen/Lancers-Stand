using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack Animation")]
    public Sprite attackSpriteRight1;  // First attack frame (right-facing)
    public Sprite attackSpriteRight2;  // Second attack frame (right-facing)
    public Sprite attackSpriteRight3;  // Third attack frame (right-facing)

    public Sprite attackSpriteLeft1;   // First attack frame (left-facing)
    public Sprite attackSpriteLeft2;   // Second attack frame (left-facing)
    public Sprite attackSpriteLeft3;   // Third attack frame (left-facing)

    private Sprite idleSprite; 
    public float attackAnimationDuration = 1f; // Total seconds for animation sequence

    public GameObject spriteHolder;
    private SpriteRenderer spriteRenderer;

    private bool facingRight = true;

    void Start()
    {
        spriteRenderer = spriteHolder.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Update facing direction based on last movement 
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0) { facingRight = true; }
        else if (horizontal < 0) { facingRight = false; }

        if (Input.GetKeyDown(GlobalVariables.attackKey) && !GlobalVariables.isAttacking)
        {
            idleSprite = spriteRenderer.sprite;
            StartAttackAnimation();
        }
    }

    public void StartAttackAnimation()
    {
        GlobalVariables.isAttacking = true;
        StartCoroutine(AttackAnimationSequence());
    }

    private System.Collections.IEnumerator AttackAnimationSequence()
    {
        // 1 -> 2 -> 3 -> 2 -> 1 pattern = 4 transitions
        float frameDuration = attackAnimationDuration / 4f;

        Sprite s1 = facingRight ? attackSpriteRight1 : attackSpriteLeft1;
        Sprite s2 = facingRight ? attackSpriteRight2 : attackSpriteLeft2;
        Sprite s3 = facingRight ? attackSpriteRight3 : attackSpriteLeft3;

        GlobalVariables.isDamaging = true;

        // 1 -> 2
        spriteRenderer.sprite = s1;
        yield return new WaitForSeconds(frameDuration);

        // 2 -> 3
        spriteRenderer.sprite = s2;
        yield return new WaitForSeconds(frameDuration);

        // 3
        spriteRenderer.sprite = s3;
        yield return new WaitForSeconds(frameDuration);

        GlobalVariables.isDamaging = false;

        // 3 -> 2
        spriteRenderer.sprite = s2;
        yield return new WaitForSeconds(frameDuration);

        // 2 -> 1
        spriteRenderer.sprite = idleSprite;
        yield return new WaitForSeconds(frameDuration);

        GlobalVariables.isAttacking = false;
    }
}
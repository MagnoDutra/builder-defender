using UnityEngine;

public class SpritePosition : MonoBehaviour
{
    private bool runOnce;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -5f);

        if (runOnce)
        {
            Destroy(this);
        }
    }
}

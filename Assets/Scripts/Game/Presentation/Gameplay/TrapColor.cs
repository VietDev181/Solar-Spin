using UnityEngine;

public class TrapColor : MonoBehaviour
{
    public ColorType colorType;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite whiteSprite;
    [SerializeField] private Sprite yellowSprite;

    public void SetColor(ColorType type)
    {
        colorType = type;

        switch (type)
        {
            case ColorType.Blue:
                spriteRenderer.sprite = blueSprite;
                break;

            case ColorType.Red:
                spriteRenderer.sprite = redSprite;
                break;

            case ColorType.White:
                spriteRenderer.sprite = whiteSprite;
                break;

            case ColorType.Yellow:
                spriteRenderer.sprite = yellowSprite;
                break;
        }
    }
}
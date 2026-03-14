using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public ColorType colorType;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] colorSprites; 
    // 0 Blue
    // 1 Red
    // 2 White
    // 3 Yellow

    private void Start()
    {
        RandomColor();
    }

    public void SetColor(ColorType type)
    {
        colorType = type;
        spriteRenderer.sprite = colorSprites[(int)type];
    }

    public void RandomColor()
    {
        ColorType randomColor = (ColorType)Random.Range(0, colorSprites.Length);
        SetColor(randomColor);
    }
}
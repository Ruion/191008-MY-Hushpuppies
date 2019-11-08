using UnityEngine;

public class ShoeSpawnManager : MonoBehaviour
{
    public Sprite[] shoeSprites;
    int spawnIndex = 0;

    public void SpawnShoe(SpriteRenderer spriteRend)
    {
        spriteRend.sprite = shoeSprites[spawnIndex % shoeSprites.Length];

        spawnIndex++;
    }
}

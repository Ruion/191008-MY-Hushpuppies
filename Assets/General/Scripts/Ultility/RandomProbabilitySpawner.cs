using UnityEngine;

public class RandomProbabilitySpawner : MonoBehaviour
{
    public SpriteChangerRandom prefab;
    public bool spawnOnEnable = true;

    [Range(0f, 1f)]
    public float spawnProbability = .5f;

    public void OnEnable()
    {
       if(spawnOnEnable) Spawn();
    }

    public void Spawn()
    {
        float horizontalPos = Random.Range(-3.2f, 3.2f);
        float verticalPos = 2f;
        Vector2 position = new Vector2(transform.position.x + horizontalPos, transform.position.y + verticalPos);

        if (Random.value <= spawnProbability) Instantiate(prefab, position, prefab.transform.rotation);
    }
}

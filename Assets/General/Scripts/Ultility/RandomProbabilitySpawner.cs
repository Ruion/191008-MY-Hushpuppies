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
        if (Random.value <= spawnProbability) Instantiate(prefab, transform);
    }
}

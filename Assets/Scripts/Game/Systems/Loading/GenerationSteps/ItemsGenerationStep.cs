using UnityEngine;
using UnityTools.Extentions;

public class ItemsGenerationStep : GenerationStep
{
    public override void Invoke()
    {
        SpawnWeapons();
    }

    private void SpawnWeapons()
    {
        foreach (var room in rooms)
        {
            if (Random.Range(0, 1f) > 0.5f)
            {
                var clone = Object.Instantiate(level.enemy, room.position, Quaternion.identity);
                level.enemyes.Add(clone);
            }
        }
        Object.Instantiate(level.weapon, rooms.GetRandom().position, Quaternion.identity);
    }
}

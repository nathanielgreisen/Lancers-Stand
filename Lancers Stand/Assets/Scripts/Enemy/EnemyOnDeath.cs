using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyOnDeath : MonoBehaviour
{

    public string deathEvent;

    public void TriggerDeath()
    {
        switch (deathEvent)
        {
            case "USCTrojanBoss":
                USCTrojanBossDeathEvent();
                break;
            case "Heart":
                SpawnHeart();
                break;
        }
    }

    private void USCTrojanBossDeathEvent()
    {
        GameObject middleTilemapObj = GameObject.Find("Middle");
        Tilemap middleTilemap = middleTilemapObj.GetComponent<Tilemap>();

        GameObject backTilemapObj = GameObject.Find("Back");
        Tilemap backTilemap = backTilemapObj.GetComponent<Tilemap>();

        Vector3Int[] tilesToErase = new Vector3Int[]
        {
            // Row 34
            new Vector3Int(-30, 34, 0), new Vector3Int(-29, 34, 0), new Vector3Int(-28, 34, 0),
            new Vector3Int(-27, 34, 0), new Vector3Int(-26, 34, 0), new Vector3Int(-25, 34, 0),
            new Vector3Int(-24, 34, 0),
            
            // Row 33
            new Vector3Int(-30, 33, 0), new Vector3Int(-29, 33, 0), new Vector3Int(-28, 33, 0),
            new Vector3Int(-27, 33, 0), new Vector3Int(-26, 33, 0), new Vector3Int(-25, 33, 0),
            new Vector3Int(-24, 33, 0)
        };

        // Erase the specified tiles
        foreach (Vector3Int tilePosition in tilesToErase)
        {
            middleTilemap.SetTile(tilePosition, null);
            backTilemap.SetTile(tilePosition, null);
        }

        Debug.Log("USC Trojan Boss defeated! Erased " + (tilesToErase.Length + (tilesToErase.Length / 2)) + " tiles");
    }

    private void SpawnHeart()
    {
        // chance to spawn a heart
        if (Random.value < 0.33f || GlobalVariables.currentScene == "Tutorial")
        {
            GameObject heartObject = new GameObject("HeartItem");
            heartObject.transform.localScale = new Vector3(3f, 3f, 1f);
            heartObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

            SpriteRenderer spriteRenderer = heartObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Misc/heart");

            CircleCollider2D circleCollider = heartObject.AddComponent<CircleCollider2D>();
            circleCollider.isTrigger = true;
            circleCollider.offset = new Vector2(-0.005f, 0.02f);
            circleCollider.radius = 0.3f;

            heartObject.AddComponent<HeartItem>();

            Debug.Log("Heart spawned at enemy death location");
        } 
    }
}

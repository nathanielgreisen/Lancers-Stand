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
            case "GCUAntelopeBoss":
                GCUAntelopeBossDeathEvent();
                break;
            case "CPPMustangBoss":
                CPPMustangBossDeathEvent();
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

    private void GCUAntelopeBossDeathEvent()
    {
        GameObject middleTilemapObj = GameObject.Find("Middle");
        Tilemap middleTilemap = middleTilemapObj.GetComponent<Tilemap>();

        GameObject backTilemapObj = GameObject.Find("Back");
        Tilemap backTilemap = backTilemapObj.GetComponent<Tilemap>();

        Vector3Int[] tilesToErase = new Vector3Int[]
        {
            // Row 32
            new Vector3Int(-15, 32, 0), new Vector3Int(-14, 32, 0), new Vector3Int(-13, 32, 0),
            new Vector3Int(-12, 32, 0), new Vector3Int(-11, 32, 0), new Vector3Int(-10, 32, 0),
            new Vector3Int(-9, 32, 0), new Vector3Int(-8, 32, 0), new Vector3Int(-7, 32, 0),
            new Vector3Int(-6, 32, 0), new Vector3Int(-5, 32, 0),
            
            // Row 31
            new Vector3Int(-15, 31, 0), new Vector3Int(-14, 31, 0), new Vector3Int(-13, 31, 0),
            new Vector3Int(-12, 31, 0), new Vector3Int(-11, 31, 0), new Vector3Int(-10, 31, 0),
            new Vector3Int(-9, 31, 0), new Vector3Int(-8, 31, 0), new Vector3Int(-7, 31, 0),
            new Vector3Int(-6, 31, 0), new Vector3Int(-5, 31, 0)
        };

        // Erase the specified tiles
        foreach (Vector3Int tilePosition in tilesToErase)
        {
            middleTilemap.SetTile(tilePosition, null);
            backTilemap.SetTile(tilePosition, null);
        }

        Debug.Log("GCU Antelope Boss defeated! Erased " + (tilesToErase.Length + (tilesToErase.Length / 2)) + " tiles");
    }
    
    private void CPPMustangBossDeathEvent()
    {
        GameObject middleTilemapObj = GameObject.Find("Middle");
        Tilemap middleTilemap = middleTilemapObj.GetComponent<Tilemap>();

        Vector3Int[] tilesToErase = new Vector3Int[]
        {
            // x=-57, Row -2
            new Vector3Int(-57, -2, 0),
            
            // x=-57, Row -3
            new Vector3Int(-57, -3, 0)
        };

        foreach (Vector3Int tilePosition in tilesToErase)
        {
            middleTilemap.SetTile(tilePosition, null);
        }

        Debug.Log("CPP Mustang Boss defeated! Erased " + tilesToErase.Length + " tiles");
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

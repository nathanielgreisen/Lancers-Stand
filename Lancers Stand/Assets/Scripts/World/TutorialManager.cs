using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TutorialManager : MonoBehaviour
{

    public GameObject moveLeft;
    public GameObject moveRight;
    public GameObject jump;
    public GameObject attack;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Image leftIM = moveLeft.GetComponent<Image>();
        Image rightIM = moveRight.GetComponent<Image>();
        Image jumpIM = jump.GetComponent<Image>();
        Image attackIM = attack.GetComponent<Image>();

        leftIM.sprite = Resources.Load<Sprite>("Sprites/LetterIcons/" + GlobalVariables.leftKey.ToString());
        rightIM.sprite = Resources.Load<Sprite>("Sprites/LetterIcons/" + GlobalVariables.rightKey.ToString());
        jumpIM.sprite = Resources.Load<Sprite>("Sprites/LetterIcons/" + GlobalVariables.jumpKey.ToString());
        attackIM.sprite = Resources.Load<Sprite>("Sprites/LetterIcons/" + GlobalVariables.attackKey.ToString());

        // Adjust widths based on key sizes
        AdjustKeyWidths();
    }

    void AdjustKeyWidths()
    {
        // Check each key and adjust the corresponding GameObject width
        AdjustGameObjectWidth(moveLeft, GlobalVariables.leftKey.ToString());
        AdjustGameObjectWidth(moveRight, GlobalVariables.rightKey.ToString());
        AdjustGameObjectWidth(jump, GlobalVariables.jumpKey.ToString());
        AdjustGameObjectWidth(attack, GlobalVariables.attackKey.ToString());
    }

    void AdjustGameObjectWidth(GameObject gameObject, string keyName)
    {
        // Check if the key is in the largeKeys array
        bool isLargeKey = GlobalVariables.largeKeys.Contains(keyName);
        
        // Get the RectTransform component to adjust width
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        Vector2 sizeDelta = rectTransform.sizeDelta;
        sizeDelta.x = isLargeKey ? 2.1f : 0.7f;
        rectTransform.sizeDelta = sizeDelta;
    }
}

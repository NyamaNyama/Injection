using UnityEngine;

public class OnOff : MonoBehaviour
{
    public void ChangeActive(GameObject gameObj)
    {
        gameObj.SetActive(!gameObj.activeSelf);
    }
}

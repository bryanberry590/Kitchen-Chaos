using UnityEngine;
using UnityEngine.Serialization;

public class SelectedCounterVisual : MonoBehaviour
{

    [FormerlySerializedAs("clearCounter")] [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObject;
    
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
        // e.selectedCounter    
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject g in visualGameObject)
        {
            g.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject g in visualGameObject)
        {
            g.SetActive(false);
        }    
    }
    
    
    
    
}

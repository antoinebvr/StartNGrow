using UnityEngine;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour
{
    public Text messageText;
    public Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(ClosePopup);
    }
  // GameObject Pop;
    public void ShowPopup()
    {
        gameObject.SetActive(true);
    }

    private void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}

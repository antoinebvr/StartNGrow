using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GreyInfobulle : MonoBehaviour
{   
    public RectTransform infobulle;
    public TextMeshProUGUI text;

    void Start()
    {
        infobulle.GetComponent<Image>().color =  new Vector4(255, 255, 255, 0);
        text.color = new Vector4(255, 255, 255, 0);
    }

    public void Update()
    {
        infobulle.transform.position = Input.mousePosition;
    }
}

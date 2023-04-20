using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Slideshow : MonoBehaviour
{
    public Sprite[] images; // Les images à afficher
    public Image imageContainer; // Le conteneur d'image
    public float intervalDuration = 3.0f; // La durée de chaque intervalle (en secondes)
    private int currentIndex = 0; // L'index de l'image courante
    private float timer = 0.0f; // Le compteur de temps

    public int x = 1;

    public GameObject canvasCloseUp;

    public MonthTurn monthTurn;

    void Start()
    {
        // Affiche la première image
        ShowImage(currentIndex);
        gameObject.GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
    }

    void Update()
    {
        // Incrémente le compteur de temps
        timer += Time.deltaTime;

        // Si le temps d'intervalle est écoulé, affiche l'image suivante
        if(x<35)
        {

            if (timer >= intervalDuration)
            {
                x++;
                currentIndex = (currentIndex + 1) % images.Length;
                ShowImage(currentIndex);
                timer = 0.0f;
            }
        }
        if(x == 35)
        {
            gameObject.SetActive(false);
            monthTurn.StartAnimCoroutine();
            monthTurn.ShowRoundNumber();
        }

        if (x == 19)
        {
            canvasCloseUp.SetActive(false);
        }

    }

    // Affiche l'image d'index spécifié
    void ShowImage(int index)
    {
        imageContainer.sprite = images[index];
    }

    // Permet de modifier la durée de chaque intervalle
    public void SetIntervalDuration(float duration)
    {
        intervalDuration = duration;
    }
}

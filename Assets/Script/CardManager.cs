using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    // liste de cartes pour chaque couleur, les cartes sont des boutons
    public List<Button> greenCards = new List<Button>();
    public List<Button> redCards = new List<Button>();
    public List<Button> blueCards = new List<Button>();
    public List<Button> yellowCards = new List<Button>();

    // tableau de positions qu'utilisent les cartes pour se déployer
    public RectTransform[] cardSlots;

    // attributs pour l'animation des cartes
    public float drawSpeed = 0.25f;
    public float drawBackSpeed = 0.25f;

    // tableau de boolean qui vérifie quelle catégorie de carte est déployée
    public bool[] cardsShown = new bool[4];

    // vérifie si un click a déjà été fait, empêche les bugs liés au spamclick
    public bool canClick = true;

    //  attributs des cartes, pour vérifier que quand une catégorie est déployée elle soit devant celle qui est en train de se ranger
    public Canvas greenCanvas;
    public Canvas redCanvas;
    public Canvas blueCanvas;
    public Canvas yellowCanvas;

    private void Start()
    {
        cardsShown[0] = false;
        cardsShown[1] = false;
        cardsShown[2] = false;
        cardsShown[3] = false;

        // positionne les cartes hors de l'écran de jeu au lancement
        foreach (Button greenCard in greenCards)
        {
            greenCard.GetComponent<Button>();
            greenCard.transform.position = new Vector2(960f, -200f);
        }

        foreach (Button redCard in redCards)
        {
            redCard.GetComponent<Button>();
            redCard.transform.position = new Vector2(960f, -200f);
        }

        foreach (Button blueCard in blueCards)
        {
            blueCard.GetComponent<Button>();
            blueCard.transform.position = new Vector2(960f, -200f);
        }

        foreach (Button yellowCard in yellowCards)
        {
            yellowCard.GetComponent<Button>();
            yellowCard.transform.position = new Vector2(960f, -200f);
        }
    }

    // Vérifie que l'animation se termine avant de permettre de re cliquer, empêche le spam click qui peut faire bug
    IEnumerator WaitTweenEnding()
    {
        canClick = false;
        yield return new WaitForSeconds(0.5f);
        canClick = true;
    }
    public void GreenCard()
    {
        if (cardsShown[0] == false && canClick == true)
        {
            DrawGreenCard();
        }

        else if (cardsShown[0] == true && canClick == true)
        {
            DrawBackGreenCard();
        }
    }
    public void RedCard()
    {
        if (cardsShown[1] == false && canClick == true)
        {
            DrawRedCard();
        }

        else if (cardsShown[1] == true && canClick == true)
        {
            DrawBackRedCard();
        }
    }
    public void BlueCard()
    {
        if (cardsShown[2] == false && canClick == true)
        {
            DrawBlueCard();
        }

        else if (cardsShown[2] == true && canClick == true)
        {
            DrawBackBlueCard();
        }
    }
    public void YellowCard()
    {
        if (cardsShown[3] == false && canClick == true)
        {
            DrawYellowCard();
        }

        else if (cardsShown[3] == true && canClick == true)
        {
            DrawBackYellowCard();
        }
    }
    public void DrawGreenCard()
    {
        // vérifie que les cartes aient la bonne taille
        greenCards[0].transform.DOScaleX(1, 0);
        greenCards[1].transform.DOScaleX(1, 0);
        // vérifie la position en Z des cartes
        greenCanvas.sortingOrder = 1;
        cardsShown[0] = true;
        // animations des cartes : monte vers le haut -> split vers les emplacements de cartes définis
        greenCards[0].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            greenCards[0].transform.DOMove(cardSlots[2].transform.position, drawSpeed, false);
        });
        greenCards[1].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            greenCards[1].transform.DOMove(cardSlots[3].transform.position, drawSpeed, false);
        });
        // empêche l'utilisateur de reclicker pour ne pas décaller l'animation
        canClick = false;
        StartCoroutine("WaitTweenEnding");
    }
    public void DrawBackGreenCard()
    {
        // réduit la taille des cartes au rangement de la catégorie
        greenCards[0].transform.DOScaleX(0,0.1f);
        greenCards[1].transform.DOScaleX(0,0.1f);
        greenCanvas.sortingOrder = 0;
        cardsShown[0] = false;
        greenCards[0].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
        {
            greenCards[0].transform.DOMoveY(-200, drawBackSpeed, false);
        });
        greenCards[1].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
        {
            greenCards[1].transform.DOMoveY(-200, drawBackSpeed, false);
        });
        canClick = true;
        StartCoroutine("WaitTweenEnding");
    }
    public CardMenu menu;
    public void DrawRedCard()
    {
        redCards[0].transform.DOScaleX(1, 0);
        redCards[1].transform.DOScaleX(1, 0);
        redCanvas.sortingOrder = 1;
        cardsShown[1] = true;
        
        redCards[0].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            redCards[0].transform.DOMove(cardSlots[2].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        redCards[1].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            redCards[1].transform.DOMove(cardSlots[3].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        canClick = true;
        StartCoroutine("WaitTweenEnding");
    }
    public void DrawBackRedCard()
    {
        redCards[0].transform.DOScaleX(0,0.1f);
        redCards[1].transform.DOScaleX(0,0.1f);
        redCanvas.sortingOrder = 0;
        cardsShown[1] = false;

        redCards[0].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
        {
            redCards[0].transform.DOMoveY(-200, drawBackSpeed, false);
            menu.SelectCard();
        });
        redCards[1].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
        {
            redCards[1].transform.DOMoveY(-200, drawBackSpeed, false);
            menu.SelectCard();
        });
        canClick = true;
        StartCoroutine("WaitTweenEnding");
    }
    public void DrawBlueCard()
    {
        blueCards[0].transform.DOScaleX(1, 0);
        blueCards[1].transform.DOScaleX(1, 0);
        blueCards[2].transform.DOScaleX(1, 0);
        blueCards[3].transform.DOScaleX(1, 0);
        blueCards[4].transform.DOScaleX(1, 0);
        blueCanvas.sortingOrder = 1;
        cardsShown[2] = true;

        blueCards[0].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            blueCards[0].transform.DOMove(cardSlots[0].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        blueCards[1].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            blueCards[1].transform.DOMove(cardSlots[1].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        blueCards[2].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            blueCards[2].transform.DOMove(cardSlots[2].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        blueCards[3].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            blueCards[3].transform.DOMove(cardSlots[3].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        blueCards[4].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            blueCards[4].transform.DOMove(cardSlots[4].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        canClick = false;
        StartCoroutine("WaitTweenEnding");
    }
    public void DrawBackBlueCard()
    {
        blueCards[0].transform.DOScaleX(0,0.1f);
        blueCards[1].transform.DOScaleX(0,0.1f);
        blueCards[2].transform.DOScaleX(0,0.1f);
        blueCards[3].transform.DOScaleX(0,0.1f);
        blueCards[4].transform.DOScaleX(0,0.1f);
        blueCanvas.sortingOrder = 0;
        cardsShown[2] = false;

        blueCards[0].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        blueCards[0].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        blueCards[1].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        blueCards[1].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        blueCards[2].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        blueCards[2].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        blueCards[3].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        blueCards[3].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        blueCards[4].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        blueCards[4].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        canClick = true;
        StartCoroutine("WaitTweenEnding");
    }
    public void DrawYellowCard()
    {
        yellowCards[0].transform.DOScaleX(1, 0);
        yellowCards[1].transform.DOScaleX(1, 0);
        yellowCards[2].transform.DOScaleX(1, 0);
        yellowCards[3].transform.DOScaleX(1, 0);
        yellowCards[4].transform.DOScaleX(1, 0);
        yellowCards[5].transform.DOScaleX(1, 0);
        yellowCanvas.sortingOrder = 1;
        cardsShown[3] = true;

        yellowCards[0].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            yellowCards[0].transform.DOMove(cardSlots[0].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        yellowCards[1].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            yellowCards[1].transform.DOMove(cardSlots[1].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        yellowCards[2].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            yellowCards[2].transform.DOMove(cardSlots[2].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        yellowCards[3].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            yellowCards[3].transform.DOMove(cardSlots[3].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        yellowCards[4].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            yellowCards[4].transform.DOMove(cardSlots[4].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        yellowCards[5].transform.DOMoveY(297, drawSpeed, false).OnComplete(() =>
        {
            yellowCards[5].transform.DOMove(cardSlots[5].transform.position, drawSpeed, false);
            menu.SelectCard();
        });
        canClick = false;
        StartCoroutine("WaitTweenEnding");
    }
    public void DrawBackYellowCard()
    {
        yellowCards[0].transform.DOScaleX(0,0.1f);
        yellowCards[1].transform.DOScaleX(0,0.1f);
        yellowCards[2].transform.DOScaleX(0,0.1f);
        yellowCards[3].transform.DOScaleX(0,0.1f);
        yellowCards[4].transform.DOScaleX(0,0.1f);
        yellowCards[5].transform.DOScaleX(0,0.1f);
        yellowCanvas.sortingOrder = 0;
        cardsShown[3] = false;

        yellowCards[0].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        yellowCards[0].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        yellowCards[1].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        yellowCards[1].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        yellowCards[2].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        yellowCards[2].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        yellowCards[3].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        yellowCards[3].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        yellowCards[4].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        yellowCards[4].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        yellowCards[5].transform.DOMoveX(960, drawBackSpeed, false).OnComplete(() =>
    {
        yellowCards[5].transform.DOMoveY(-200, drawBackSpeed, false);
        menu.SelectCard();
    });
        canClick = true;
        StartCoroutine("WaitTweenEnding");
    }
}

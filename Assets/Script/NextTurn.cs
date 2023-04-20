using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextTurn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CashFlow CashTurn;
    public MonthTurn MonthTurn;
    public void TurnNext()
    {
     
            // if (Input.GetMouseButtonDown(0))
            //  {
            MonthTurn.MonthValue++;
            CashTurn.money = CashTurn.MoneyTemporaire;
            //}
        

    }

}

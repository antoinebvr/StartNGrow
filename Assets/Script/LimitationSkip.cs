using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitationSkip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public CardMenu[] Limit;
    public CashFlow Cash;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Limite()
    {
        Limit[Cash.verifid-1].CardLimit();     
    }
}

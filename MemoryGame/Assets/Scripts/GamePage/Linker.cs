using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    private static Linker s_instance;
    public static Linker Instance
    {
        get
        {
            if (s_instance == null)
                s_instance = FindObjectOfType<Linker>();
            return s_instance;
        }
    }

    public CardsPoolModel CardsPoolModel;
    public CardModel CardModel;
    public ScoreModel ScoreModel;
    public TimerModel TimerModel;
    public PopupController PopupController;
}

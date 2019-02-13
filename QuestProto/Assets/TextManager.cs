using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    string[] AllText = new string[] {
        "TESTI TESTI TESTI TESTI TESTI TESTI TESTI TESTI\n" +
        "TESTI TESTI TESTI TESTI",                              //000
        "Tämä On tarkoitettu testi\n" +
        "käyttöä varten",                                       //001
        "Tie Haarautuu!\n" +
        "Valitsetko vaarallisen vai turvallisen reitin?",       //002
        "Tapaat maantiekauppiaan!\n" +
        "Hän tarjoaa sinulle uutta kiiltävää miekkaa.",         //003
        "Tie tulli!\n" +
        "Voit yrittää keplutella vartialta ilmaisen pääsyn."    //004

    };


    public string GetText(int index)
    {
        return AllText[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextControl : MonoBehaviour
{

    public TMP_Text FRText;
    public TMP_Text FLText;
    public TMP_Text RRText;
    public TMP_Text RLText;

    public TMP_Text DMM1;
    public TMP_Text DMM2;

    public AllLegControl alc;

    public CrawlWalk cw;

    public DummyControl dmc;
    void Update()
    {
        FRText.text = ("FR J0 to end " + alc.FRED.transform.localPosition);
        FLText.text = ("FL J0 to end " + alc.FLED.transform.localPosition);
        RRText.text = ("RR J0 to end " + alc.RRED.transform.localPosition);
        RLText.text = ("RL J0 to end " + alc.RLED.transform.localPosition);

        DMM1.text = ("DM1 " + dmc.DM1ED.transform.localPosition);
        DMM2.text = ("DM2 " + dmc.DM2ED.transform.localPosition);
    }
}

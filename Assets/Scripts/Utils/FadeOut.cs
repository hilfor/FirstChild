using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public Image m_FadeImage;
    public AnimationCurve m_FadeCurve;
    public Color m_FadeToColor;
    public float m_timer = 1;

    private float _timeCounter = 0;


    void Update()
    {
        if (_timeCounter < m_timer)
        {
            Color imageColor = m_FadeImage.color;
            float lerpBy = m_FadeCurve.Evaluate(_timeCounter / m_timer);

            Debug.Log("Lerp color by:" + lerpBy);
            m_FadeImage.color = Color.Lerp(imageColor, m_FadeToColor, lerpBy);
            _timeCounter += Time.deltaTime;
        }
    }
}

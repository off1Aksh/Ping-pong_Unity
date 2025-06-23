using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float kecepatan;
    public string axisHorizontal;
    public string axisVertical;
    public float batasKiri;
    public float batasKanan;
    public float batasAtas;
    public float batasBawah;

    void Update()
    {
        float gerakHorizontal = Input.GetAxis(axisHorizontal) * kecepatan * Time.deltaTime;
        float gerakVertical = Input.GetAxis(axisVertical) * kecepatan * Time.deltaTime;

        float nextPosX = transform.position.x + gerakHorizontal;
        float nextPosY = transform.position.y + gerakVertical;

        if (nextPosX > batasKanan || nextPosX < batasKiri)
        {
            gerakHorizontal = 0;
        }
        if (nextPosY > batasAtas || nextPosY < batasBawah)
        {
            gerakVertical = 0;
        }

        transform.Translate(gerakHorizontal, gerakVertical, 0);
    }
}

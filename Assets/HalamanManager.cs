using UnityEngine;
using UnityEngine.SceneManagement;
public class HalamanManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MulaiPermainan()
    {
        SceneManager.LoadScene("play");
    }
    public void CreditScene()
    {
        SceneManager.LoadScene("anggota");
    }

    public void KeluarPermainan()
    {
        SceneManager.LoadScene("exit");
    }

    public void KembaliPermainan()
    {
        SceneManager.LoadScene("home");
    }
}

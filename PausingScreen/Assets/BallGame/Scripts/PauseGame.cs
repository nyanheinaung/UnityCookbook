using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject qPanel;
    public GameObject qSlider;
    public GameObject qLabel;
    public bool expensiveQualitySettings = true;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = isPaused;
        Slider slider = GetComponent<Slider>();
        slider.maxValue = QualitySettings.names.Length;
        slider.value = QualitySettings.GetQualityLevel();
        qPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            SetPause();
        }
    }

    private void SetPause() {
        float timeScale = !isPaused ? 1f : 0f;
        Time.timeScale = timeScale;
        Cursor.visible = isPaused;
        GetComponent<MouseLook>().enabled = !isPaused;
        qPanel.SetActive(isPaused);
    }

    public void SetQuality(float qs) {
        int qsi = Mathf.RoundToInt(qs);
        QualitySettings.SetQualityLevel(qsi);
        Text label = qLabel.GetComponent<Text>();
        label.text = QualitySettings.names[qsi];

    }
}

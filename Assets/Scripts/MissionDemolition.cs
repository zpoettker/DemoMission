using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Set in Inspector")]
    public Text uitLevel;
    public Text uitShots;
    public Text uitButton;
    public Vector3 castlePos;
    public GameObject[] castles;
    public Text uitStars;
    public Text uitFinalStars;
    public GameObject gameOverPanel;

    [Header("Set Dynamically")]
    public int totalStars;
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";

    void Start()
    {
        S = this;

        level = 0;
        levelMax = castles.Length;
        gameOverPanel.SetActive(false);
        StartLevel();
    }

    void StartLevel()
    {
        if (castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        uitStars.text = StarString(0);
        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    string StarString(int filled)
    {
        string s = "";
        for (int i = 0; i < 3; i++)
        {
            s += (i < filled) ? "★" : "☆";
        }
        return s;
    }

    void Update()
    {
        UpdateGUI();

        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
            StartCoroutine(AwardStars());
        }
    }

    IEnumerator AwardStars()
    {
        int stars = 1;
        if (shotsTaken == 1)
        {
            stars++;
        }
        if (Goal.cleanShot)
        {
            stars++;
        }
        totalStars += stars;

        yield return new WaitForSeconds(0.5f);
        for (int i = 1; i <= stars; i++)
        {
            uitStars.text = StarString(i);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);

        if (level == levelMax - 1)
        {
            GameOver();
        }
        else
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        level++;
        StartLevel();
    }

    void GameOver()
    {
        uitFinalStars.text = "You earned " + totalStars + " out of " + (levelMax * 3) + " stars!";
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        gameOverPanel.SetActive(false);
        level = 0;
        totalStars = 0;
        StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}

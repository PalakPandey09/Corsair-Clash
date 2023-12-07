using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AIDemoController: MonoBehaviour {
   private static AIDemoController instance;

   private Button startBattelBtn;
   public float idleTime;
   private float timer = 0f;
   private Vector3 lastMousePosition;
   public bool isIdle;
   private bool isAI;
   private bool chooseLeft;

   private void Awake() {
      DontDestroyOnLoad(this);

      if(instance == null) {
         instance = this;
         DontDestroyOnLoad(this.gameObject);
      }
      else if(instance != this) {
         Destroy(this.gameObject);
      }
   }

   void Start() {
      SceneManager.sceneLoaded += handleSceneChange;
      handleSceneChange(SceneManager.GetActiveScene(), LoadSceneMode.Single);
      isIdle = false;
      isAI = false;
      chooseLeft = true;
   }

   private void Update() {
      if(Input.anyKey || Input.anyKeyDown || Input.mousePosition != lastMousePosition) {
         timer = 0f;
         isIdle = false;
      }
      else {
         if(!isAI) {
            timer += Time.deltaTime;

            if(timer >= idleTime) {
               isIdle = true;
               timer = 0f;
               SceneManager.LoadScene("start menu");
            }
         }
      }

      lastMousePosition = Input.mousePosition;

      if(isIdle) {
         isAI = true;
      }
      else {
         isAI = false;
      }

      if(SceneManager.GetActiveScene().name == "OverworldMap"
         || SceneManager.GetActiveScene().name == "BattleOne"
         || SceneManager.GetActiveScene().name == "CrabFight") {
         if(isAI && startBattelBtn.gameObject.activeSelf) {
            startBattelBtn.onClick.Invoke();
         }
      }
   }

   private void handleSceneChange(Scene newScene, LoadSceneMode loadMode) {
      if(isAI) {
         switch(newScene.name) {
         case "start menu":
            StartCoroutine(delayClickStartBtn());
            break;
         case "OverworldMap":
            startBattelBtn = GameObject.FindGameObjectWithTag("StartBattleBtn").GetComponent<Button>();
            startBattelBtn.gameObject.SetActive(false);
            closeNavigation();
            StartCoroutine(controlPlayer());
            break;
         case "BattleOne":
            StopAllCoroutines();
            var canvas = GameObject.FindGameObjectWithTag("Canvas");
            startBattelBtn = canvas.transform.GetChild(1).GetComponent<Button>();
            StartCoroutine(placePlayerUnit());
            break;
         case "OverworldMapPostBattle":
            startBattelBtn = GameObject.FindGameObjectWithTag("StartBattleBtn").GetComponent<Button>();
            startBattelBtn.gameObject.SetActive(false);
            StartCoroutine(controlPlayer());
            break;
         case "CrabFight":
            StopAllCoroutines();
            canvas = GameObject.FindGameObjectWithTag("Canvas");
            startBattelBtn = canvas.transform.GetChild(1).GetComponent<Button>();
            StartCoroutine(placePlayerUnit());
            break;
         case "postcrabfinalscene":
            StopAllCoroutines();
            StartCoroutine(chooseFinalSelection());
            break;
         }
      }
   }

   private void clickStartBtn() {
      var startBtn = GameObject.FindGameObjectWithTag("StartBtn").GetComponent<Button>();
      startBtn.onClick.Invoke();
   }

   private IEnumerator delayClickStartBtn() {
      yield return new WaitForSeconds(2);
      clickStartBtn();
   }

   private void closeNavigation() {
      var navPanel = GameObject.FindGameObjectWithTag("NavigationPanel");
      navPanel.gameObject.SetActive(false);
   }

   private IEnumerator controlPlayer() {
      var shipChild = GameObject.FindGameObjectWithTag("PlayerControl").transform.GetChild(0);
      for(int i = 0; i < 9; i++) {
         shipChild.localEulerAngles += new Vector3(0, 0, -10);
         yield return new WaitForSeconds(0.1f);
      }
      yield return new WaitForSeconds(0.5f);

      var playerShip = GameObject.FindGameObjectWithTag("PlayerControl");
      Vector3 screenRight = new Vector3(Screen.width, Screen.height / 2, 0);

      while(playerShip.transform.position.x < screenRight.x) {
         playerShip.transform.Translate(new Vector3(
            Camera.main.ScreenToWorldPoint(screenRight).x,
            playerShip.transform.position.y,
            0).normalized * 0.1f);

         yield return new WaitForSeconds(0.1f);

      }
   }

   private IEnumerator placePlayerUnit() {
      var playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
      var emptySlots = GameObject.FindGameObjectsWithTag("PlayerEmptySpace");
      var index = 0;
      for(; index < playerUnits.Length; index++) {
         yield return new WaitForSeconds(0.5f);
         playerUnits[index].transform.position = emptySlots[index].transform.position;
      }
   }

   private IEnumerator chooseFinalSelection() {
      yield return new WaitForSeconds(5);
      Button btn;
      if(chooseLeft) {
         btn = GameObject.FindGameObjectWithTag("CommandeerBtn").GetComponent<Button>();
         chooseLeft = false;
         btn.onClick.Invoke();
      }
      else {
         btn = GameObject.FindGameObjectWithTag("SinkBtn").GetComponent<Button>();
         chooseLeft = true;
         btn.onClick.Invoke();
      }

      btn.onClick.Invoke();
      yield return new WaitForSeconds(5);

      SceneManager.LoadScene("start menu");
   }
}
﻿#region License
// ====================================================
// Project Porcupine Copyright(C) 2016 Team Porcupine
// This program comes with ABSOLUTELY NO WARRANTY; This is free software, 
// and you are welcome to redistribute it under certain conditions; See 
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxManager : MonoBehaviour
{
    // This will just keep a reference to all the dialog boxes since there inactive on start you cant find them.
    public MenuController mc;
    public DialogBoxJobList dialogBoxJobList;
    public DialogBoxLoadGame dialogBoxLoadGame;
    public DialogBoxSaveGame dialogBoxSaveGame;
    public DialogBoxOptions dialogBoxOptions;
    public DialogBoxSettings dialogBoxSettings;
    public DialogBoxTrade dialogBoxTrade;
    public DialogBoxAreYouSure dialogBoxAreYouSure;
    public DialogBoxQuests dialogBoxQuests;

    public void Awake()
    {
        GameObject controllers = GameObject.Find("Dialog Boxes");
        GameObject tempGoObj;

        mc = GameObject.Find("Dialog Boxes").GetComponent<MenuController>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_SaveFile"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Save File";
        dialogBoxSaveGame = tempGoObj.GetComponent<DialogBoxSaveGame>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_LoadFile"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Load File";
        dialogBoxLoadGame = tempGoObj.GetComponent<DialogBoxLoadGame>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_Options"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Options";
        dialogBoxOptions = tempGoObj.GetComponent<DialogBoxOptions>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_Settings"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Settings";
        dialogBoxSettings = tempGoObj.GetComponent<DialogBoxSettings>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_Trade"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Trade";
        dialogBoxTrade = tempGoObj.GetComponent<DialogBoxTrade>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_JobList"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Job List";
        dialogBoxJobList = tempGoObj.GetComponent<DialogBoxJobList>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_AreYouSure"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Are You Sure";
        dialogBoxAreYouSure = tempGoObj.GetComponent<DialogBoxAreYouSure>();

        tempGoObj = (GameObject)Instantiate(Resources.Load("UI/DB_Quests"), controllers.transform.position, controllers.transform.rotation, controllers.transform);
        tempGoObj.name = "Quests";
        dialogBoxQuests = tempGoObj.GetComponent<DialogBoxQuests>();
        AddQuestList();
    }

    // Temporary location until we have a proper code-driven UI
    private void AddQuestList()
    {
        Transform layoutRoot = GameObject.Find("Dialog Boxes").transform.parent.GetComponent<Transform>();
        GameObject go = (GameObject)Instantiate(Resources.Load("UI/QuestsMainScreenBox"), layoutRoot.transform);
        go.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -55, 0);

        Toggle pinButton = CreatePinQuestButton();

        pinButton.onValueChanged.AddListener(go.SetActive);
    }

    private Toggle CreatePinQuestButton()
    {
        GameObject buttonQuestGameObject = (GameObject)Instantiate(Resources.Load("UI/PinToggleButton"), this.gameObject.transform);
        buttonQuestGameObject.name = "ToggleQuestPinButton";
        buttonQuestGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -30, 0);
        return buttonQuestGameObject.GetComponent<Toggle>();
    }
}
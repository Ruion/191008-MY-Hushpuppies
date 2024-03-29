﻿using System.Data;
using UnityEngine;
using DataBank;
using TMPro;
using System.Data.Common;

public class SqliteController : GameSettingEntity
{
    public Transform list;
    public GameObject prefab;

    public GameObject errorRetrieveHandler;
    public TextMeshProUGUI errorRetrieveHandlerText;

    IDataReader reader;

    [ContextMenu("ShowAll")]
    void OnEnable()
    {

        UniversalUserDB userDb = FindObjectOfType<UniversalUserDB>();

        try { reader = userDb.GetAllData(); }
        catch(DbException ex) { errorRetrieveHandler.SetActive(true); errorRetrieveHandlerText.text = ex.Message; }

        while (reader.Read())
        {
            UserEntity entity = new UserEntity();
            entity.name = reader[1].ToString();
            entity.email = reader[2].ToString();
            entity.contact = reader[3].ToString();
            entity.game_score = reader[4].ToString();
            entity.created_at = reader[5].ToString();
            entity.is_submitted = reader[6].ToString();

            GameObject newR = Instantiate(prefab, list);
            TextMeshProUGUI text = newR.GetComponent<TextMeshProUGUI>();
            text.text = reader[0].ToString();

            TextMeshProUGUI nameT = newR.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            nameT.text = entity.name;

            TextMeshProUGUI emailT = newR.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            emailT.text = entity.email;

            TextMeshProUGUI contactT = newR.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            contactT.text = entity.contact;

            TextMeshProUGUI scoreT = newR.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            scoreT.text = entity.game_score;

            TextMeshProUGUI registerT = newR.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
            registerT.text = entity.created_at;

            TextMeshProUGUI syncT = newR.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
            syncT.text = entity.is_submitted;

        }

    }

    private void OnDisable()
    {
        foreach(Transform child in list)
        {
            Destroy(child.gameObject);
        }
    }

}

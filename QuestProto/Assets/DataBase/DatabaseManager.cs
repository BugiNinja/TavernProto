using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DatabaseManager : MonoBehaviour
{
    private string conn;

    

    void Start()
    {

        //string path = Application.dataPath + "/StreamingAssets";
        //conn = "URI=file:" + Application.dataPath + "/chinook.db";
        //conn = "URI=file:" + Application.streamingAssetsPath + "/Tavern.s3db";

        if (Application.platform != RuntimePlatform.Android)
        {
            conn = "URI=file:" + Application.streamingAssetsPath + "/Tavern.s3db";

        }

        else
        {
            conn = Application.persistentDataPath + "/Tavern.s3db";

            Debug.Log(Application.persistentDataPath);
            if (!System.IO.File.Exists(conn))
            {
                //dataText.text = "CONNECT: " + conn;
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "Tavern.s3db");

                while (!load.isDone) { }

                System.IO.File.WriteAllBytes(conn, load.bytes);
            }
            conn = "URI=file:" + conn;

        }

        GetData();

    }


    public void GetData()
    {
        using (IDbConnection dbConnection = new SqliteConnection(conn))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT Story " + "FROM Story WHERE ID=1";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Story = reader.GetString(0);
                        Debug.Log(Story);
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }
    public void UpdateHeroSave(HeroStats hero)
    {
        using (IDbConnection dbConnection = new SqliteConnection(conn))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE S_Hero SET EXP ="+hero.TotalEXP()+" WHERE ID ="+hero.id;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }
    public void GetHeroSave(HeroStats hero)
    {
        using (IDbConnection dbConnection = new SqliteConnection(conn))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT  *" + "FROM S_Hero WHERE ID="+hero.id;
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hero.exp = reader.GetInt32(1);
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }
}

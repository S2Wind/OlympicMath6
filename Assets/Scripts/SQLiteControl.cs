﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;


public class SQLiteControl : MonoBehaviour
{
    void Start()
    {
		// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "QuestionCSDD";

		// Open connection
		SqliteConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Create table
		SqliteCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";

		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

		// Insert values in table
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
		cmnd.ExecuteNonQuery();

		//Read and print all values in table
		SqliteCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query = "SELECT * FROM my_table";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
		{
			Debug.Log("id: " + reader[0].ToString());
			Debug.Log("val: " + reader[1].ToString());
		}

		// Close connection
		dbcon.Close();

	}
}
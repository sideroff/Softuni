//I use regions so I could collapse blocks of code :)

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _00_Initial_Setup
{
    class Program
    {
        static void Main()
        {
            string connectionString =
                "Data Source=(local)\\SQLEXPRESS;Initial Catalog=master;"
                + "Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                String dbName = "MinionsDB";

                #region createDatabase

                cmd.CommandText = "CREATE DATABASE " + dbName;
                cmd.ExecuteNonQuery();

                #endregion

                #region createTables

                connection.ChangeDatabase(dbName);
                cmd.CommandText = "CREATE TABLE Countries(" +
                                  "Id INT NOT NULL IDENTITY(1,1)," +
                                  "[Name] NVARCHAR(50)," +
                                  "CONSTRAINT PK_Countries_Id PRIMARY KEY (Id))";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE Towns(" +
                                  "Id INT NOT NULL IDENTITY(1,1)," +
                                  "[Name] NVARCHAR(50)," +
                                  "CountryId INT NOT NULL," +
                                  "CONSTRAINT PK_Towns_Id PRIMARY KEY(Id)," +
                                  "CONSTRAINT FK_Towns_CountryId_Countries_Id FOREIGN KEY(CountryId) REFERENCES Countries(Id))";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE [Minions](" +
                                  "Id INT NOT NULL IDENTITY(1,1), " +
                                  "[Name] NVARCHAR(50), " +
                                  "Age INT, " +
                                  "TownId INT, " +
                                  "CONSTRAINT PK_Minions_Id PRIMARY KEY(Id), " +
                                  "CONSTRAINT FK_Minions_TownId_Towns_Id FOREIGN KEY(TownId) REFERENCES Towns(Id))";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE Villains(" +
                                  "Id INT NOT NULL IDENTITY(1,1)," +
                                  "[Name] NVARCHAR(50)," +
                                  "[EvilFactor] NVARCHAR(10)," +
                                  "CONSTRAINT PK_Villains_Id PRIMARY KEY(Id)," +
                                  "CONSTRAINT CHK_Villains_EvilFactor CHECK(EvilFactor IN (\'good\',\'bad\',\'evil\',\'super evil\')))";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE Minions_Villains(" +
                                  "MinionId INT NOT NULL," +
                                  "VillainId INT NOT NULL," +
                                  "CONSTRAINT PK_MinionsVillains_MinionId_VillainId PRIMARY KEY(MinionId,VillainId)," +
                                  "CONSTRAINT FK_MinionsVillains_MinionId FOREIGN KEY(MinionId) REFERENCES Minions(Id)," +
                                  "CONSTRAINT FK_MinionsVillains_VillainId FOREIGN KEY(VillainId) REFERENCES Villains(Id))";
                cmd.ExecuteNonQuery();

                #endregion

                #region fillTables

                connection.ChangeDatabase(dbName);
                cmd.CommandText = "INSERT INTO Countries(Name) VALUES(\'Bulgaria\'),(\'Germany\'),(\'Romania\'),(\'Hungary\'),(\'Russia\')" +
                    "INSERT INTO Towns([Name],CountryId) VALUES(\'Sofia\',1),(\'Plovdiv\',2),(\'Varna\',3),(\'Burgas\',4),(\'Qmbol\',5)" +
                    "INSERT INTO Minions([Name],Age,TownId) VALUES(\'Gosho\',18,1),(\'Pesho\',19,2),(\'Stamat\',20,3),(\'Cecka\',21,4),(\'Pecka\',22,5)" +
                    "INSERT INTO Villains([Name],EvilFactor) VALUES(\'Icko\',\'good\'),(\'Picko\',\'bad\'),(\'Spicko\',\'evil\'),(\'Gicko\',\'super evil\'),(\'Cicko\',\'good\')" +
                    "INSERT INTO Minions_Villains(MinionId,VillainId) VALUES(1,1),(2,2),(3,3),(4,4),(5,5),(1,2),(2,3),(3,4),(4,5),(5,1),(1,3),(1,4),(2,1),(3,5),(5,3)";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


                #endregion

                #region 2. Get Villains’ Names
                cmd.CommandText = "SELECT v.Name, COUNT(mv.MinionId) FROM Villains v " +
                                  "INNER JOIN Minions_Villains mv " +
                                  "ON v.Id = mv.VillainId " +
                                  "GROUP BY v.Name " +
                                  "HAVING COUNT(mv.MinionId) > 3 " +
                                  "ORDER BY COUNT(mv.MinionId) DESC ";
                Console.WriteLine("2. Get Villains’ Names" + Environment.NewLine +
                                    cmd.ExecuteScalar() + Environment.NewLine);
                #endregion

                #region 3. Get Minion Names
                Console.WriteLine("Get all minions surving villian with ID(1-5):");
                Int32 villainId = Int32.Parse(Console.ReadLine());
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT m.Name,m.Age FROM Minions m " +
                                  "INNER JOIN Minions_Villains mv " +
                                  "ON m.Id = mv.MinionId AND mv.VillainId = @villainId";
                cmd.Parameters.AddWithValue("@villainId", villainId);
                Console.WriteLine("3. Get Minion Names" + Environment.NewLine +
                                    cmd.ExecuteScalar() + Environment.NewLine);
                #endregion

                #region 4. Add Minion
                connection.ChangeDatabase(dbName);
                cmd.Parameters.Clear();

                Console.WriteLine("4.Add Minion");
                Console.WriteLine("Supply minion data in format:<string name> <int age> <string townName>-<string villainName1> <string villainName2>...");
                string data = Console.ReadLine();
                string[] splitted = data.Split('-');
                string[] minionData = splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] villains = splitted[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string getTownId = "SELECT TOP 1 t.Id FROM Towns t WHERE t.Name LIKE @townName";
                cmd.CommandText = getTownId;
                cmd.Parameters.AddWithValue("@townName", minionData[2]);

                Int32 townId = 0;
                try
                {
                    townId = Int32.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception e) when (e is SqlException || e is NullReferenceException)
                {
                    cmd.CommandText = "INSERT INTO Towns(Name) VALUES(@townName)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = getTownId;
                    townId = Int32.Parse(cmd.ExecuteScalar().ToString());
                    Console.WriteLine("Town " + minionData[2] + " was added to the database.");
                }

                string getMinionId = "SELECT TOP 1 m.Id FROM Minions m WHERE m.Name LIKE @minionName AND m.Age = @minionAge"
                cmd.CommandText = getMinionId;
                cmd.Parameters.AddWithValue("@minionName", minionData[0]);
                cmd.Parameters.AddWithValue("@minionAge", Int32.Parse(minionData[1]));

                Int32 minionId = 0;
                try
                {
                    minionId = Int32.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception e) when (e is SqlException || e is NullReferenceException)
                {
                    cmd.CommandText = "INSERT INTO Minions(Name,age) VALUES(@minionName,@minionAge)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT TOP 1 t.Id FROM Towns t WHERE t.Name LIKE @townName";
                    minionId = Int32.Parse(cmd.ExecuteScalar().ToString());
                    Console.WriteLine("Minion with name-age " + minionData[0] + "-" + minionData[1] + " was added to the database.");
                }

                string addServant = "INSERT INTO Minions_Villains(MinionId,VillainId) VALUES(@minionId,@villainId)";
                string getVillainId = "SELECT TOP 1 v.Id FROM Villains v WHERE v.Name LIKE @villainName";
                string insertVillain = "INSERT INTO Villains(Name,EvilFactor) VALUES(@villainName,'evil')";

                cmd.Parameters.AddWithValue("@villainName", "");
                cmd.Parameters.AddWithValue("@villainId", -1);
                cmd.Parameters.AddWithValue("@minionId", minionId);

                foreach (string villainName in villains)
                {

                    cmd.Parameters["@villainName"].Value = villainName;
                    cmd.CommandText = getVillainId;

                    Int32 villainID = -1;
                    try
                    {
                        villainID = Int32.Parse(cmd.ExecuteScalar().ToString());
                    }
                    catch (Exception e) when (e is SqlException || e is NullReferenceException)
                    {
                        cmd.CommandText = insertVillain;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = getVillainId;
                        villainID = Int32.Parse(cmd.ExecuteScalar().ToString());
                        cmd.Parameters["@villainId"].Value = villainID;
                    }

                    cmd.CommandText = addServant;
                    cmd.Parameters["@villainId"].Value = villainID;
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Successfully added {0} to be minion of {1}", minionData[0], String.Join(", ", villains));


                SqlDataReader reader = null;
                #endregion

                #region 5. Change Town Names Casing
                connection.ChangeDatabase(dbName);
                Console.WriteLine("Capitalise all towns in country(Bulgaria,Germany,Romania,Hungary,Russia): ");
                String countryName = Console.ReadLine();
                cmd.CommandText = "SELECT t.Id, t.Name " +
                                  "FROM Towns t " +
                                  "INNER JOIN Countries c " +
                                  "ON t.CountryId = c.Id AND c.Name LIKE @countryName";
                cmd.Parameters.AddWithValue("@countryName", countryName);
                reader = cmd.ExecuteReader();
                List<String> townNames = new List<string>();
                while (reader.Read())
                {
                    string newName = reader["Name"].ToString().ToUpper();
                    townNames.Add(newName);
                    cmd.Parameters.AddWithValue("@capitalisedName", newName);
                    cmd.Parameters.AddWithValue("@townId", Int32.Parse(reader["Id"].ToString()));
                    cmd.CommandText = "UPDATE Towns " +
                                      "SET Name = @capitalisedName" +
                                      "WHERE Towns.Id =@townId";
                }
                Console.WriteLine(townNames.Count + " town names were affected.");
                Console.WriteLine("[" + String.Join(", ", townNames) + "]");

                #endregion

                #region 6. *Remove Villain 
                connection.ChangeDatabase(dbName);
                cmd.Parameters.Clear();
                Console.WriteLine("Release all minions from & remove villain with id(1-5): ");
                Console.WriteLine("im not catching exeptions so be in range please");
                Int32 vilId = Int32.Parse(Console.ReadLine());
                cmd.CommandText = "DELETE FROM Minions_Villains WHERE VillainId = @VillainId";
                cmd.Parameters.AddWithValue("@VillainId", vilId);

                int affected = cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM Villains WHERE Id = @VillainId";
                int deletedVillain = cmd.ExecuteNonQuery();

                if (deletedVillain > 0)
                {
                    Console.WriteLine("Villain was deleted " +
                                      "{0} minions released",affected);
                }


                #endregion

                #region 7. Print All Minion Names
                connection.ChangeDatabase(dbName);
                cmd.CommandText = "SELECT m.Name " +
                                  "FROM Minions m " +
                                  "ORDER BY m.Id ASC";
                reader = cmd.ExecuteReader();
                List<String> minionNames = new List<string>();
                while (reader.Read())
                {
                    minionNames.Add(reader["Name"].ToString());
                }
                for (int i = 0; i < minionNames.Count / 2; i++)
                {
                    Console.WriteLine(minionNames[i]);
                    Console.WriteLine(minionNames[minionNames.Count - i - 1]);
                }
                if (minionNames.Count % 2 != 0)
                {
                    Console.WriteLine(minionNames[minionNames.Count / 2]);
                }
                #endregion

                #region 8. Increase Minions Age

                Console.WriteLine("Capitalise names and increment age to minions with id(<int id1> <int id2>...):");
                Int32[] ids = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
                connection.ChangeDatabase(dbName);
                cmd.CommandText = "UPDATE Minions " +
                                  "SET [Name] = UPPER(LEFT([Name],1))+SUBSTRING([Name],2,LEN([Name])), " +
                                  "Age +=1 " +
                                  "WHERE Id IN (" + String.Join(", ", ids) + ")";
                cmd.ExecuteNonQuery();

                #endregion

                #region 9. Increase Age Stored Procedure 
                //CREATE PROCEDURE usp_GetOlder(@MinionId INT)
                //AS
                //BEGIN
                //    UPDATE Minions
                //    SET Age += 1
                //    WHERE Id = @MinionId
                //END

                cmd.Parameters.Clear();
                Console.WriteLine("Increment age of minion with ID(1-5): ");
                Int32 mId = Int32.Parse(Console.ReadLine());
                connection.ChangeDatabase(dbName);
                cmd.CommandText = "EXECUTE usp_GetOlder @minionId";
                cmd.Parameters.AddWithValue("@minionId", mId);
                cmd.ExecuteNonQuery();

                #endregion
            }
        }
    }
}

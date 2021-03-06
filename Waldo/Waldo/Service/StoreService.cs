﻿using Waldo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Waldo.Service
{
    public class StoreService
    {

        public List<Store> GetStores()
        {
            //Create a list of Store objects
            List<Store> lsStores = new List<Store>();

            //Establish connection to our SQL Database, selects all stores from the table, and allows us to read what is returned
            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Stores");
            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            //If any information is returned by the Store table, a store object is created with the information
            //from the database columns and added to the list
            if (reader != null)
            {
                Store s = null;

                while (reader.Read())
                {
                    s = new Store();
                    s.Name = reader["Name"].ToString();
                    s.Latitude = reader["Latitude"].ToString();
                    s.Longitude = reader["Longitude"].ToString();
                    s.Address = reader["Address"].ToString();
                    s.MasksRequired = reader["ReqMasks"].ToString();

                    s.Masks = reader["Masks"].ToString();
                    s.Gloves = reader["Gloves"].ToString();
                    s.HandSanitizer = reader["HandSanitizer"].ToString();
                    s.PaperTowels = reader["PaperTowels"].ToString();
                    s.ToiletPaper = reader["ToiletPaper"].ToString();
                    s.LiquidSoap = reader["LiquidSoap"].ToString();
                    s.BarSoap = reader["BarSoap"].ToString();
                    s.CleaningWipes = reader["CleaningWipes"].ToString();
                    s.AerosolDisinfectant = reader["AerosolDisinfectants"].ToString();
                    s.Bleach = reader["Bleach"].ToString();
                    s.FlushableWipes = reader["FlushableWipes"].ToString();
                    s.Tissues = reader["Tissues"].ToString();
                    s.Diapers = reader["Diapers"].ToString();
                    s.WaterFilters = reader["WaterFilters"].ToString();
                    s.ColdRemedies = reader["ColdRemedies"].ToString();
                    s.CoughRemedies = reader["CoughRemedies"].ToString();
                    s.RubbingAlcohol = reader["RubbingAlcohol"].ToString();
                    s.Antiseptic = reader["Antiseptic"].ToString();
                    s.Thermometer = reader["Thermometer"].ToString();
                    s.FirstAidKit = reader["FirstAidKit"].ToString();
                    s.WaterBottles = reader["WaterBottles"].ToString();
                    s.Eggs = reader["Eggs"].ToString();
                    s.Milk = reader["Milk"].ToString();
                    s.Bread = reader["Bread"].ToString();
                    s.Beef = reader["Beef"].ToString();
                    s.Chicken = reader["Chicken"].ToString();
                    s.Pork = reader["Pork"].ToString();
                    s.Yeast = reader["Yeast"].ToString();
                    s.ReportedBy = reader["ReportedBy"].ToString();
                    s.Timestamp = reader["Timestamp"].ToString();

                    lsStores.Add(s);
                }
            }

            //The connection to the database is closed and the list of stores is returned
            db.Close();

            return lsStores;
        }

        public Store GetStore(int StoreId)
        {
            //Establish connection to our SQL Database, selects the store with the id variable from the store table, and allows us to read what is returned
            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Stores WHERE StoreId = @StoreId");
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@StoreId", DbType = System.Data.DbType.Int32, Value = StoreId });
            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            //If a store is returned by the table, its information from the columns is recorded, the database connection is closed, and the store is returned
            if (reader != null)
            {
                if (reader.Read())
                {
                    Store s = new Store();
                    s.Name = reader["Name"].ToString();
                    s.Latitude = reader["Latitude"].ToString();
                    s.Longitude = reader["Longitude"].ToString();
                    s.Address = reader["Address"].ToString();
                    s.MasksRequired = reader["ReqMasks"].ToString();

                    s.Masks = reader["Masks"].ToString();
                    s.Gloves = reader["Gloves"].ToString();
                    s.HandSanitizer = reader["HandSanitizer"].ToString();
                    s.PaperTowels = reader["PaperTowels"].ToString();
                    s.ToiletPaper = reader["ToiletPaper"].ToString();
                    s.LiquidSoap = reader["LiquidSoap"].ToString();
                    s.BarSoap = reader["BarSoap"].ToString();
                    s.CleaningWipes = reader["CleaningWipes"].ToString();
                    s.AerosolDisinfectant = reader["AerosolDisinfectants"].ToString();
                    s.Bleach = reader["Bleach"].ToString();
                    s.FlushableWipes = reader["FlushableWipes"].ToString();
                    s.Tissues = reader["Tissues"].ToString();
                    s.Diapers = reader["Diapers"].ToString();
                    s.WaterFilters = reader["WaterFilters"].ToString();
                    s.ColdRemedies = reader["ColdRemedies"].ToString();
                    s.CoughRemedies = reader["CoughRemedies"].ToString();
                    s.RubbingAlcohol = reader["RubbingAlcohol"].ToString();
                    s.Antiseptic = reader["Antiseptic"].ToString();
                    s.Thermometer = reader["Thermometer"].ToString();
                    s.FirstAidKit = reader["FirstAidKit"].ToString();
                    s.WaterBottles = reader["WaterBottles"].ToString();
                    s.Eggs = reader["Eggs"].ToString();
                    s.Milk = reader["Milk"].ToString();
                    s.Bread = reader["Bread"].ToString();
                    s.Beef = reader["Beef"].ToString();
                    s.Chicken = reader["Chicken"].ToString();
                    s.Pork = reader["Pork"].ToString();
                    s.Yeast = reader["Yeast"].ToString();
                    s.ReportedBy = reader["ReportedBy"].ToString();
                    s.Timestamp = reader["Timestamp"].ToString();

                    db.Close();
                    return s;
                }
            }

            //If no store is returned by the table, the database connection is closed and null is returned
            db.Close();

            return null;
        }

        public Boolean AddStore(Store newStore)
        {
            //The fields of the supplied store are obtained
            string name = newStore.Name;
            string latitude = newStore.Latitude;
            string longitude = newStore.Longitude;
            string address = newStore.Address;
            string reqMasks = newStore.MasksRequired;
            string masks = newStore.Masks;
            string gloves = newStore.Gloves;
            string sanitizer = newStore.HandSanitizer;
            string towels = newStore.PaperTowels;
            string tp = newStore.ToiletPaper;
            string liquid = newStore.LiquidSoap;
            string bar = newStore.BarSoap;
            string wipes = newStore.CleaningWipes;
            string aerosol = newStore.AerosolDisinfectant;
            string bleach = newStore.Bleach;
            string flush = newStore.FlushableWipes;
            string tissues = newStore.Tissues;
            string diapers = newStore.Diapers;
            string filters = newStore.WaterFilters;
            string cold = newStore.ColdRemedies;
            string cough = newStore.CoughRemedies;
            string rubbingAlc = newStore.RubbingAlcohol;
            string antiseptic = newStore.Antiseptic;
            string thermometer = newStore.Thermometer;
            string firstAid = newStore.FirstAidKit;
            string bottles = newStore.WaterBottles;
            string eggs = newStore.Eggs;
            string milk = newStore.Milk;
            string bread = newStore.Bread;
            string beef = newStore.Beef;
            string chicken = newStore.Chicken;
            string pork = newStore.Pork;
            string yeast = newStore.Yeast;
            string by = newStore.ReportedBy;
            string time = newStore.Timestamp;

            //A connection to our SQL Database is opened
            using (SqlConnection db = new SqlConnection())
            {
                db.ConnectionString = "Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                db.Open();

                /*
                 * If a current store exists with the name, address, and coordinates supplied then the rest of the fields are updated with the supplied information.
                 * If a store does not exist with the supplied name, address, and coordinates then a new store is added to the database with the supplied information.
                 */
                SqlCommand cmd = new SqlCommand("IF EXISTS(SELECT * FROM Stores WHERE (Name = @Name AND Address = @Address AND Longitude = @Long AND Latitude = @Lat)) " +
                    "UPDATE Stores SET ReqMasks = @MasksRequired, Masks = @Masks, Gloves = @Gloves, HandSanitizer = @HandSanitizer, PaperTowels = @PaperTowels, " +
                    "ToiletPaper  =  @ToiletPaper, LiquidSoap = @LiquidSoap, BarSoap = @BarSoap, CleaningWipes = @CleaningWipes, " +
                    "AerosolDisinfectants = @AerosolDisinfectant, Bleach = @Bleach, FlushableWipes = @FlushableWipes, Tissues = @Tissues, " +
                    "Diapers = @Diapers, WaterFilters = @WaterFilters, ColdRemedies = @ColdRemedies, CoughRemedies = @CoughRemedies, RubbingAlcohol = @RubbingAlcohol, " +
                    "Antiseptic = @Antiseptic, Thermometer = @Thermometer, FirstAidKit = @FirstAidKit, WaterBottles = @WaterBottles, Eggs = @Eggs, " +
                    "Milk = @Milk, Bread = @Bread, Beef = @Beef, Chicken = @Chicken, Pork = @Pork, Yeast = @Yeast, ReportedBy = @By, Timestamp = @Time " +
                    "WHERE (Name = @Name AND Address = @Address AND Longitude = @Long AND Latitude = @Lat)" +
                    "ELSE INSERT INTO Stores(Name, Latitude, Longitude, Address, ReqMasks, Masks, Gloves, HandSanitizer, PaperTowels, " +
                    "ToiletPaper, LiquidSoap, BarSoap, CleaningWipes, AerosolDisinfectants, Bleach, FlushableWipes, Tissues, Diapers, WaterFilters, ColdRemedies, CoughRemedies, RubbingAlcohol," +
                    "Antiseptic, Thermometer, FirstAidKit, WaterBottles, Eggs, Milk, Bread, Beef, Chicken, Pork, Yeast, ReportedBy, Timestamp) " +
                    "VALUES(@Name, @Lat, @Long, @Address, @MasksRequired, @Masks, @Gloves, @HandSanitizer, @PaperTowels, @ToiletPaper, @LiquidSoap, @BarSoap, @CleaningWipes, " +
                    "@AerosolDisinfectant, @Bleach, @FlushableWipes, @Tissues, @Diapers, @WaterFilters, @ColdRemedies, @CoughRemedies, @RubbingAlcohol, " +
                    "@Antiseptic, @Thermometer, @FirstAidKit, @WaterBottles, @Eggs, @Milk, @Bread, @Beef, @Chicken, @Pork, @Yeast, @By, @Time)");
                cmd.Connection = db;

                //Each of the fields of the supplied store object is turned into a SQL parameter to be used in the above query
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", DbType = System.Data.DbType.String, Value = name });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lat", DbType = System.Data.DbType.String, Value = latitude });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Long", DbType = System.Data.DbType.String, Value = longitude });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Address", DbType = System.Data.DbType.String, Value = address });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@MasksRequired", DbType = System.Data.DbType.String, Value = reqMasks });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Masks", DbType = System.Data.DbType.String, Value = masks});
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Gloves", DbType = System.Data.DbType.String, Value = gloves });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@HandSanitizer", DbType = System.Data.DbType.String, Value = sanitizer });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@PaperTowels", DbType = System.Data.DbType.String, Value = towels });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@ToiletPaper", DbType = System.Data.DbType.String, Value = tp });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@LiquidSoap", DbType = System.Data.DbType.String, Value = liquid });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@BarSoap", DbType = System.Data.DbType.String, Value = bar });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@CleaningWipes", DbType = System.Data.DbType.String, Value = wipes });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@AerosolDisinfectant", DbType = System.Data.DbType.String, Value = aerosol });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Bleach", DbType = System.Data.DbType.String, Value = bleach });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@FlushableWipes", DbType = System.Data.DbType.String, Value = flush });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Tissues", DbType = System.Data.DbType.String, Value = tissues });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Diapers", DbType = System.Data.DbType.String, Value = diapers });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@WaterFilters", DbType = System.Data.DbType.String, Value = filters });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@ColdRemedies", DbType = System.Data.DbType.String, Value = cold });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@CoughRemedies", DbType = System.Data.DbType.String, Value = cough });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@RubbingAlcohol", DbType = System.Data.DbType.String, Value = rubbingAlc });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Antiseptic", DbType = System.Data.DbType.String, Value = antiseptic });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Thermometer", DbType = System.Data.DbType.String, Value = thermometer });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@FirstAidKit", DbType = System.Data.DbType.String, Value = firstAid });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@WaterBottles", DbType = System.Data.DbType.String, Value = bottles });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Eggs", DbType = System.Data.DbType.String, Value = eggs });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Milk", DbType = System.Data.DbType.String, Value = milk });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Bread", DbType = System.Data.DbType.String, Value = bread });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Beef", DbType = System.Data.DbType.String, Value = beef });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Chicken", DbType = System.Data.DbType.String, Value = chicken });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Pork", DbType = System.Data.DbType.String, Value = pork });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Yeast", DbType = System.Data.DbType.String, Value = yeast });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@By", DbType = System.Data.DbType.String, Value = by });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Time", DbType = System.Data.DbType.String, Value = time });

                cmd.ExecuteNonQuery();
            }

            //true is returned upon successful query
            return true;
        }
    }
}

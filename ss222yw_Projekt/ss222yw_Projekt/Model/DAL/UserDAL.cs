﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model.DAL
{
    public class UserDAL : DALBase
    {
        //Hämtar alla Users i databasen.
        public IEnumerable<User> GetUser()
        {
            //Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till User-objekt.
                    var users = new List<User>(100);

                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur. 
                    var cmd = new SqlCommand("appSchema.uspGetUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        var userIDIndex = reader.GetOrdinal("UserID");
                        var nameIndex = reader.GetOrdinal("Name");

                        // Så länge som det finns poster att läsa returnerar Read true annars false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post.
                            users.Add(new User
                            {
                                UserID = reader.GetInt32(userIDIndex),
                                Name = reader.GetString(nameIndex)
                            });
                        }

                    }

                    //avallokerar minne som inte används.
                    users.TrimExcess();

                    // Returnerar referensen till List-objektet.
                    return users;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting Users from the database.");

                }
            }

        }


        // Hämtar user en i taget .
        public User GetUserByID(int userID)
        {
            //Skapar en anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetUserByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    //cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har.
                            var userIDIndex = reader.GetOrdinal("UserID");
                            var nameIndex = reader.GetOrdinal("Name");

                            // Returnerar referensen till de skapade User-objektet.
                            return new User
                            {
                                UserID = reader.GetInt32(userIDIndex),
                                Name = reader.GetString(nameIndex)
                            };
                        }
                    }
                    return null;
                }

                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        //Skapar en ny User i tabellen User.
        public void InsertUser(User user)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = user.Name;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar User-objektet värdet.
                    user.UserID = (int)cmd.Parameters["@UserID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        //Uppdaterar en User i tabellen User.
        public void UpdateUser(User user)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = user.Name;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        //Tar bort en User .
        public void DeleteUser(int userID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}
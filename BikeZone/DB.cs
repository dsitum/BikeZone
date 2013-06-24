using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BikeZone
{
    class DB
    {
            private static DB instance;       
  
            private NpgsqlConnection conn;

            #region Konstruktor
            private DB()
            {
                Konekcija = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=BikeZone;User Id=postgres;Password=postgres;");
                Konekcija.Open();
            }
            #endregion

            #region Destruktor
            ~DB()
            {
                Konekcija.Close();
                Konekcija = null;
            }
            #endregion

            #region Singletone Instanca
            public static DB Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new DB();
                    }
                    return instance;
                }
            }
            #endregion

            #region Getter Setter konekcija
            public NpgsqlConnection Konekcija
            {
                get { return conn; }
                private set { conn = value; }
            }
            #endregion

            /// <summary>
            /// Napravi novi objekt za izvršavanje upita nad bazom, izvrši upit i vrati rezultate upita
            /// </summary>
            /// <param name="sql"></param>
            /// Sql SELECT upit korisnika
            /// <returns>Kolekciju podataka iz baze ili prazan data reader</returns>
            public NpgsqlDataReader dohvati_podatke(string sql)
            {
                NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
                return naredba.ExecuteReader();
            }

            /// <summary>
            /// izvrši drugi upit po želji  ( delete, update, insert )
            /// </summary>
            /// <param name="sql">Upit kojeg je zadala druga forma</param>
            /// <returns></returns>
            public int izvrsi_upit(string sql)
            {
                NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
                return naredba.ExecuteNonQuery();
            }
        }
    }

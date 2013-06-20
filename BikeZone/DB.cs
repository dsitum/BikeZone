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
        class BazaPodataka
        {

            private static BazaPodataka instance;       
  
            private NpgsqlConnection conn;

            #region Konstruktor
            private BazaPodataka()
            {
                Konekcija = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=BikeZone;User Id=postgres;Password=postgres;");
                Konekcija.Open();
            }
            #endregion

            #region Destruktor
            ~BazaPodataka()
            {
                Konekcija.Close();
                Konekcija = null;
            }
            #endregion

            #region Singletone instanca
            public static BazaPodataka Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new BazaPodataka();
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

            #region CRUD naredbe
            /// <summary>
            /// Napravi novi objekt za izvršavanje upita nad bazom, izvrši upit i vrati rezultate upita
            /// </summary>
            /// <param name="sql"></param>
            /// Sql SELECT upit korisnika
            /// <returns>Kolekciju podataka iz baze ili prazan data reader</returns>
            public NpgsqlDataReader DohvatiDataReader(string sql)
            {
                NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
                return naredba.ExecuteReader();
            }

            /// <summary>
            /// Vrati samo jedan zapis iz baze
            /// </summary>
            /// <param name="sql">sql upit</param>
            /// <returns>jedan objekt, odnosno jedan zapis iz baze</returns>
            public object DohvatiJedanZapis(string sql)
            {
                NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
                return naredba.ExecuteScalar();
            }

            /// <summary>
            /// izvrši drugi upit po želji  ( delete update, insert )
            /// </summary>
            /// <param name="sql">Upit kojeg je zadala druga forma</param>
            /// <returns></returns>
            public int IzvrsiUpit(string sql)
            {
                NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
                return naredba.ExecuteNonQuery();
            }
            #endregion
        }
    }
}

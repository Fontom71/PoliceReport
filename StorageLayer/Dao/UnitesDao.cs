﻿using LogicLayer.Unite;

namespace StorageLayer.Dao
{
    public class UnitesDao : BaseDao, IUniteDao
    {
        private static UnitesDao? _instance;

        private UnitesDao() : base() { }

        public static UnitesDao Instance
        {
            get
            {
                _instance ??= new UnitesDao();
                return _instance;
            }
        }

        public void Add(Unite unite)
        {
            var req = "INSERT INTO Unites (Nom, Type, UnitSpecialisation) VALUES ('" + unite.Nom + "', '" + unite.Type + "', '" + unite.UnitSpecialisation + "')";
            ExecuteNonQuery(req);
        }

        public void Remove(Unite unite)
        {
            var req = "DELETE FROM Unites WHERE Id = " + unite.Id;
            ExecuteNonQuery(req);
        }

        public Unite GetType(string type)
        {
            var req = "SELECT * FROM Unites WHERE Type = '" + type + "'";
            var reader = ExecuteReader(req);
            reader.Read();
            var unite = new Unite(reader.GetString(1), reader.GetString(2), reader.GetString(3));
            reader.Close();
            CloseConnection();
            return unite;
        }

        public List<Unite> GetAll()
        {
            var req = "SELECT * FROM Unites";
            var reader = ExecuteReader(req);
            var unites = new List<Unite>();
            while (reader.Read())
            {
                unites.Add(new Unite(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();
            CloseConnection();
            return unites;
        }

        public List<Unite> GetAllBySpecialisation(string specialisation)
        {
            var req = "SELECT * FROM Unites WHERE UnitSpecialisation = '" + specialisation + "' ORDER BY UnitSpecialisation ASC";
            var reader = ExecuteReader(req);
            var unites = new List<Unite>();
            while (reader.Read())
            {
                unites.Add(new Unite(reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();
            CloseConnection();
            return unites;
        }

        public List<Unite> GetAllByNom(string nom)
        {
            var req = "SELECT * FROM Unites WHERE Nom = '" + nom + "' ORDER BY Nom ASC";
            var reader = ExecuteReader(req);
            var unites = new List<Unite>();
            while (reader.Read())
            {
                unites.Add(new Unite(reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();
            CloseConnection();
            return unites;
        }

        public void Update(Unite unite)
        {
            var req = "UPDATE Unites SET Nom = '" + unite.Nom + "', Type = '" + unite.Type + "', UnitSpecialisation = '" + unite.UnitSpecialisation + "' WHERE Id = " + unite.Id;
            ExecuteNonQuery(req);
        }
    }
}

using Dapper;
using System.Data.SqlClient;


namespace TP_Elecciones
{
    public class BD{
        private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
        private static List<Candidato> _ListadoCandidatos = new List<Candidato>{};

        public static void LevantarCandidatos(){
            string sql = "SELECT * FROM Candidatos";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                _ListadoCandidatos = db.Query<Candidato>(sql).ToList();
            }
        }
    }
}
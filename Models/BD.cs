using Dapper;
using System.Data.SqlClient;


namespace TP_Elecciones
{
    public static class BD{
        private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
        private static List<Candidato> _ListadoCandidatos = new List<Candidato>{};
        private static List<Partido> _ListadoPartidos = new List<Partido>{};

        public static void LevantarCandidatos(){
            string sql = "SELECT * FROM Candidatos";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                _ListadoCandidatos = db.Query<Candidato>(sql).ToList();
            }
        }

        public static void LevantarPartidos(){
            string sql = "SELECT * FROM Partidos";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                _ListadoPartidos = db.Query<Partido>(sql).ToList();
            }
        }

        public static void AgregarCandidato(Candidato can){
            string sql = "INSERT INTO Candidatos(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pidPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pidPartido = can.idPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion});
            }
        }

        public static void AgregarPartido(Partido par){
            string sql = "INSERT INTO Partidos(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores) VALUES (@pNombre, @pLogo, @pSitioWeb, @pFechaFundacion, @pCantidadDiputados, @pCantidadSenadores)";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pNombre = par.Nombre, pLogo = par.Logo, pSitioWeb = par.SitioWeb, pFechaFundacion = par.FechaFundacion, pCantidadDiputados = par.CantidadDiputados, pCantidadSenadores = par.CantidadSenadores});
            }
        }

        public static void EliminarCandidato(int idAEliminar)
        {
            string sql = "DELETE FROM Candidatos WHERE idCandidato = @id";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new {id = idAEliminar});
            }
        }

        public static Partido VerInfoPartido(int idPartido){
            for (int i = 0; i<_ListadoPartidos.Count(); i++){
                if (_ListadoPartidos[i].idPartido == idPartido) { return _ListadoPartidos[i]; }
            }
            return null;
        }

        public static Candidato VerInfoCandidato(int idCandidato){
            for (int i = 0; i<_ListadoCandidatos.Count(); i++){
                if (_ListadoCandidatos[i].idCandidato == idCandidato) { return _ListadoCandidatos[i]; }
            }
            return null;
        }

        public static List<Partido> ListarPartidos(){
            return _ListadoPartidos;
        }

        public static int GetCantPartidos(){
            return _ListadoPartidos.Count();
        }

        public static int GetCantCandidatos(int idPartido){
            int cont = 0;
            for (int i = 0; i<_ListadoCandidatos.Count(); i++){
                if (_ListadoCandidatos[i].idPartido == idPartido){
                    cont++;
                }
            }
            return cont;
        }

        public static List<Candidato> ListarCandidatos(int idPartido){
            List<Candidato> listaADevolver = new List<Candidato>{};
            for (int i = 0; i<_ListadoCandidatos.Count(); i++){
                if (_ListadoCandidatos[i].idPartido == idPartido){ listaADevolver.Add(_ListadoCandidatos[i]); }
            }
            return listaADevolver;
        }
    }
}
using System.Reflection.Metadata.Ecma335;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlTypes;
using Dapper;
using System.Data.SqlClient;


namespace TP_Elecciones
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";

        public static List<Candidato> LevantarCandidatos(int idPartido)
        {
            string sql = "SELECT * FROM Candidatos WHERE idPartido = @idPartido";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Candidato>(sql, new { idPartido = idPartido }).ToList();
            }
        }

        public static List<Partido> LevantarPartidos()
        {
            string sql = "SELECT * FROM Partidos";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Partido>(sql).ToList();
            }
        }

        public static void AgregarCandidato(Candidato can)
        {
            string sql = "INSERT INTO Candidatos(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pidPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pidPartido = can.idPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion });
            }
        }

        public static void AgregarPartido(Partido par)
        {
            string sql = "INSERT INTO Partidos(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores, ColorPrimario, ColorSecundario) VALUES (@pNombre, @pLogo, @pSitioWeb, @pFechaFundacion, @pCantidadDiputados, @pCantidadSenadores, @pColorPrimario, @pColorSecundario)";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pNombre = par.Nombre, pLogo = par.Logo, pSitioWeb = par.SitioWeb, pFechaFundacion = par.FechaFundacion, pCantidadDiputados = par.CantidadDiputados, pCantidadSenadores = par.CantidadSenadores, pColorPrimario = par.ColorPrimario, pColorSecundario = par.ColorSecundario });
            }
        }

        public static void EliminarCandidato(int idAEliminar)
        {
            string sql = "DELETE FROM Candidatos WHERE idCandidato = @id";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { id = idAEliminar });
            }
        }

        public static void EliminarPartido(int idAEliminar)
        {
            string sql = "DELETE FROM Partidos WHERE idPartido = @id";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { id = idAEliminar });
            }
        }

        public static void ActualizarCandidato(Candidato can, int idCandidato)
        {
            string sql = "UPDATE Candidatos SET idPartido = @nIdPartido, Apellido = @nApellido, Nombre = @nNombre, FechaNacimiento = @nFechaNacimiento, Foto = @nFoto, Postulacion = @nPostulacion WHERE idCandidato = @id;";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { id = idCandidato, nIdPartido = can.idPartido, nApellido = can.Apellido, nNombre = can.Nombre, nFechaNacimiento = can.FechaNacimiento, nFoto = can.Foto, nPostulacion = can.Postulacion });
            }
        }

        public static void ActualizarPartido(Partido par, int idPartido)
        {
            string sql = "UPDATE Partidos SET Nombre = @nNombre, Logo = @nLogo, SitioWeb = @nSitioWeb, FechaFundacion = @nFechaFundacion, CantidadDiputados = @nCantidadDiputados, CantidadSenadores = @nCantidadSenadores, ColorPrimario = @nColorPrimario, ColorSecundario = @nColorSecundario WHERE idPartido = @id;";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { id = idPartido, nNombre = par.Nombre, nLogo = par.Logo, nSitioWeb = par.SitioWeb, nFechaFundacion = par.FechaFundacion, nCantidadDiputados = par.CantidadDiputados, nCantidadSenadores = par.CantidadSenadores, nColorPrimario = par.ColorPrimario, nColorSecundario = par.ColorSecundario });
            }
        }

        public static Partido VerInfoPartido(int idPartido)
        {
            string sql = "SELECT * FROM Partidos WHERE idPartido = @id";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Partido>(sql, new { id = idPartido }).SingleOrDefault();
            }
        }

        public static Candidato VerInfoCandidato(int idCandidato)
        {
            string sql = "SELECT * FROM Candidatos WHERE idCandidato = @id";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Candidato>(sql, new { id = idCandidato }).SingleOrDefault();
            }
        }

        public static int GetCantCandidatos(int idPartido)
        {
            string sql = "SELECT COUNT(*) FROM Candidatos WHERE idPartido = @id";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.QuerySingle<int>(sql, new { id = idPartido });
            }
        }

        public static int GetCantPartidos()
        {
            string sql = "SELECT COUNT(*) FROM Partidos";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.QuerySingle<int>(sql);
            }
        }
    }
}
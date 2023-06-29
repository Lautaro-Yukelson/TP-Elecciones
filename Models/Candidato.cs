public class Candidato{
    public int idCandidato {get; set;}
    public int idPartido {get; set;}
    public string Apellido {get; set;}
    public string Nombre {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public string Foto {get; set;}
    public string Postulacion {get; set;}

    public Candidato(){}

    public Candidato(int ip, string ap, string no, DateTime fn, string ft, string po){
        idPartido = ip;
        Apellido = ap;
        Nombre = no;
        FechaNacimiento = fn;
        Foto = ft;
        Postulacion = po;
    }
}
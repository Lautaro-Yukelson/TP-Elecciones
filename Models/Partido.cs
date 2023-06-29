public class Partido{
    public int idPartido {get; set;}
    public string Nombre {get; set;}
    public string Logo {get; set;}
    public string SitioWeb {get; set;}
    public DateOnly FechaFundacion {get; set;}
    public int CantidadDiputados {get; set;}
    public int CantidadSenadores {get; set;}

    public Partido(){}

    public Partido(string n, string l, string sw, DateOnly ff, int cd, int cs){
        Nombre = n;
        Logo = l;
        SitioWeb = sw;
        FechaFundacion = ff;
        CantidadDiputados = cd;
        CantidadSenadores = cs;
    }
}
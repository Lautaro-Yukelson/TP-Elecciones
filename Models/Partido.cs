public class Partido
{
    public int idPartido { get; set; }
    public string Nombre { get; set; }
    public string Logo { get; set; }
    public string SitioWeb { get; set; }
    public DateTime FechaFundacion { get; set; }    
    public int CantidadDiputados { get; set; }
    public int CantidadSenadores { get; set; }
    public string ColorPrimario { get; set; }
    public string ColorSecundario { get; set; }


    public Partido(){}

    public Partido(string n, string l, string sw, DateTime ff, int cd, int cs, string CPrimario, string CSecundario){
        Nombre = n;
        Logo = l;
        SitioWeb = sw;
        FechaFundacion = ff;
        CantidadDiputados = cd;
        CantidadSenadores = cs;
        ColorPrimario = CPrimario;
        ColorSecundario = CSecundario;
    }
}
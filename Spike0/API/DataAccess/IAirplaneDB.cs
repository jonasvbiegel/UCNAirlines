namespace API.DataAccess;

using API.Model;

public interface IAirplaneDB
{
    public List<Airplane> GetAirplanes();
    public Airplane? GetAirplane(string airplaneId);
}

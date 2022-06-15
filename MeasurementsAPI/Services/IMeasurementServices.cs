using MeasurementsAPI.Models;

namespace MeasurementsAPI.Services
{
    public interface IMeasurementServices
    {
        List<Measurements> GetAll();
        Measurements get(string id);
        List<Measurements> GetCertificate(string plantName);

        void create(Measurements measurement);





    }
}

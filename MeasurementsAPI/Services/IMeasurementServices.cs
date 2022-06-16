using MeasurementsAPI.Models;

namespace MeasurementsAPI.Services
{
    public interface IMeasurementServices
    {
        // The interface is used for dependency injection, in order to avoid tight coupling
        List<Measurements> GetAll();
        Measurements get(string id);
        List<Measurements> GetCertificate(string plantName);

        void create(Measurements measurement);

        void update(Measurements measurement, string id);
        void delete(string id);


    }
}

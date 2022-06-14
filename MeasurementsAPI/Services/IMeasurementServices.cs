using MeasurementsAPI.Models;

namespace MeasurementsAPI.Services
{
    public interface IMeasurementServices
    {
        List<Measurements> GetAll();
        Measurements get(string id);

        void create(Measurements measurement);





    }
}

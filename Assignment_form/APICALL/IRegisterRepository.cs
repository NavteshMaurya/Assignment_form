using Assignment_models;

namespace Assignment_form.APICALL
{
    public interface IRegisterRepository
    {
        public Task<List<City>> CityGet();

        public Task<Registration> Registration(Registration obj);

        public Task<List<Alldetail>> ListGet(Alldetail obj);

    }
}

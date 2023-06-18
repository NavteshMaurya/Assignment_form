using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Assignment_models;
using Assignment_form_api.Modal;


namespace Assignment_form_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("ListGet")]

        public List<Alldetail> Listdetail()
        {
            var vm = _context.details.FromSqlRaw("EXEC getDetail", new List<SqlParameter>().ToArray());
            return vm.ToList();
        }


        [HttpGet("CityDetail")]
        public List<City> CityGet()
        {
            List<City> citeee = _context.Citys.ToList();
            return citeee;
        }

        [HttpPost("Registrationdetail")]
        public Registration Registrationdetail(Registration obj)
        { 
            //dbcontext

            List<SqlParameter> parms = new List<SqlParameter>
            {
                  new SqlParameter { ParameterName = "@firstname", Value = obj.Firstname },
                  new SqlParameter { ParameterName = "@lastname", Value = obj.Lastname},
                  new SqlParameter { ParameterName = "@email", Value = obj.Email },
                  new SqlParameter { ParameterName = "@phone", Value = obj.Phone },
                  new SqlParameter { ParameterName = "@cityid", Value = obj.cityid },
                  new SqlParameter { ParameterName = "@gender", Value = obj.gender },

            };

            int n = _context.Database.ExecuteSqlRaw("EXEC Registrationproc @firstname,@lastname,@email,@phone,@cityid,@gender", parms.ToArray());


            return obj;

        }

    }
}

using LocationFood.Common.Models;
using LocationFood.Web.Controllers.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace LocationFood.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetCustomerByEmail")]
        public async Task<IActionResult> GetCustomer(EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = await _dataContext.Customers
                .Include(c => c.User)
                .Include(c => c.Reservations)
                .FirstOrDefaultAsync(c => c.User.UserName.ToLower() == emailRequest.Email.ToLower());
            var response = new CustomerResponse
            {
                Id = customer.Id,
                FirstName = customer.User.FirstName,
                LastName = customer.User.LastName,
                Address = customer.User.Address,
                Document = customer.User.Document,
                Email = customer.User.Email,
                PhoneNumber = customer.User.PhoneNumber,
                Reservations = customer.Reservations.Select(r => new ReservationResponse
                {
                    Id = r.Id,
                    Quantity = r.Quantity,
                    ReservationDate = r.ReservationDate,
                    ReservationHour = r.ReservationHour,
                    ReservationStates = r.ReservationStates.Select(s => new ReservationStateResponse
                    {
                        Id = s.Id,
                        StateDate = s.StateDate,
                    }).ToList()

                }).ToList()
            };
            return Ok(response);
        }
    }
}

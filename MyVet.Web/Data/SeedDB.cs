using MyVet.Web.Data.Entities;
using MyVet.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context,
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("8357499", "Juan Pablo", "Ossa Rios", "3104958561", "4175173", "Calle Robledo", "paoxxa@gmail.com", "Admin", "123123");
            var customer = await CheckUserAsync("8357499", "Juan Pablo", "Ossa Rios", "3104958561", "4175173", "Calle Robledo", "paoxxa@hotmail.com", "customer", "123123");
            await CheckPetTypeAsync();
            await CheckServiceTypeAsync();
            await CheckOwnersAsync(customer);
            await CheckManagersAsync(manager);
            await CheckPetsAsync();
            await CheckAgendasAsync();
        }

        private async Task CheckManagersAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });

                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string cellPhone,
            string fixedPhone,
            string address,
            string email,
            string role,
            string password)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {

                    FirstName = firstName,
                    LastName = lastName,
                    Document = document,
                    CellPhone = cellPhone,
                    FixedPhone = fixedPhone,
                    Address = address,
                    Email = email,
                    UserName = email
                };
                await _userHelper.AddUserAsync(user, password);
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task CheckAgendasAsync()
        {
            if (!_dataContext.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var endDate = initialDate.AddYears(1);

                while (initialDate < endDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _dataContext.Agendas.Add(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvailable = true
                            });

                            initialDate = initialDate.AddMinutes(30);
                        }
                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                    await _dataContext.SaveChangesAsync();
                }
            }
        }

        private async Task CheckPetsAsync()
        {
            var owner = _dataContext.Owners.FirstOrDefault();
            var petType = _dataContext.PetTypes.FirstOrDefault();

            if (!_dataContext.Pets.Any())
            {
                _dataContext.Pets.Add(new Pet { Name = "Laica" });
                _dataContext.Pets.Add(new Pet { Name = "Zoica" });
                _dataContext.Pets.Add(new Pet { Name = "Pepa" });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckOwnersAsync(User user)
        {
            if (!_dataContext.Owners.Any())
            {
                _dataContext.Owners.Add(new Owner { User = user });

                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckServiceTypeAsync()
        {
            if (!_dataContext.ServiceTypes.Any())
            {
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Query" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Surgery" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Treatment" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetTypeAsync()
        {
            if (!_dataContext.PetTypes.Any())
            {
                _dataContext.PetTypes.Add(new PetType { Name = "Dog" });
                _dataContext.PetTypes.Add(new PetType { Name = "Cat" });
                _dataContext.PetTypes.Add(new PetType { Name = "Turtle" });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}

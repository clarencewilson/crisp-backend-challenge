using CRISP.BackendChallenge.Context.Models;
using CRISP.BackendChallenge.Models;
using CRISP.BackendChallenge.Repository;

namespace CRISP.BackendChallenge.Service
{
    public class EmployeeService: IEmployeeService 
    {
        private readonly IRepository<Employee> _repository;
        private readonly IRepository<Login> _loginRepository;

        public EmployeeService(IRepository<Employee> repository, IRepository<Login> loginRepository)
        {
            _repository = repository;
            _loginRepository = loginRepository;
        }
        public bool Add(EmployeeResponse entity)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
                _repository.Add(employee);
                _repository.Save();

                foreach (var item in entity.LoginDates)
                {
                    var login = new Login()
                    {
                        EmployeeId = entity.Id,
                        LoginDate = item
                    };
                    _loginRepository.Add(login);
                    _loginRepository.Save();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                var employee = _repository.GetById(id);
                _repository.Delete(employee);
                _repository.Save();

                var login = _loginRepository.GetById(id);
                _loginRepository.Delete(login);
                _loginRepository.Save();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            

        }

        public IEnumerable<EmployeeResponse> GetAll()
        {
            var result = _repository.Query()
            .ToList().Select(x => new EmployeeResponse
            {
                Id = x.Id,
                Name = x.Name,
                // TODO: Include the login date information...LoginDate
                LoginDates = _loginRepository.Query().ToList().Where(l => l.Id == x.Id).Select(l => l.LoginDate).ToList(),
            });

            return result;
        }

        public EmployeeResponse GetById(int id)
        {
            try
            {
                var result = new EmployeeResponse
                {
                    Id = id,
                    Name = _repository.GetById(id).Name,
                    LoginDates = _loginRepository.Query().ToList().Where(l => l.Id == id).Select(l => l.LoginDate).ToList()
                };

                return result;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public EmployeeResponse Update(EmployeeResponse entity)
        {
            try
            {
                var employee = _repository.GetById(entity.Id);
                employee.Name = entity.Name;
                
                _repository.Update(employee);
                _repository.Save();

                var login = _loginRepository.GetById(entity.Id);

                foreach (var item in entity.LoginDates)
                {
                    login.LoginDate = item;
                    _loginRepository.Update(login);
                    _loginRepository.Save();
                }

                return GetById(entity.Id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }
    }
}

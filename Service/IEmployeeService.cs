using CRISP.BackendChallenge.Context.Models;
using CRISP.BackendChallenge.Models;

namespace CRISP.BackendChallenge.Service
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeResponse> GetAll();

        public EmployeeResponse GetById(int id);

        public bool Add(EmployeeResponse entity);

        public bool Delete(int id);

        public EmployeeResponse Update(EmployeeResponse entity);
    }
}

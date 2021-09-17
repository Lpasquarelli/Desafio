using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class OperatorService
    {
        private Repository _repository;
        public OperatorService(Repository repository)
        {
            _repository = repository;
        }
        public Operator GetOperatorByCode(string code)
        {
            var operators = _repository.GetAll<Operator>();
            var selectedOperator = operators.Where(o => o.Code == code).FirstOrDefault();
            var operador = new Operator();

            if (selectedOperator == null)
            {
                operador.Code = code;
                operador.Id = Guid.NewGuid();
                Create(operador);
                selectedOperator = GetOperatorById(operador.Id);
            }

            selectedOperator = GetOperatorById(selectedOperator.Id);

            return selectedOperator;
        }

        public Operator GetOperatorById(Guid id)
        {
            var selectedOperator = _repository.GetById<Operator>(id);
            return selectedOperator;
        }

        public List<Operator> GetOperators()
        {
            var operators = _repository.GetAll<Operator>();
            return operators;
        }

        public void Create(Operator insertingOperator)
        {
            _repository.Insert(insertingOperator);
        }

        public void Update(Operator updatingOperator)
        {
            _repository.Update(updatingOperator);
        }
    }
}

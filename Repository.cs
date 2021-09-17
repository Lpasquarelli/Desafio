using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class Repository
    {
        private List<IModel> _fakeDatabase = new List<IModel>();

        public void Insert(IModel model)
        {
            DateTime _dataToday = DateTime.Today;

            if (model.Id == Guid.Empty)
                throw new Exception("Não é possível salver um registro com Id não preenchido");
            
            
            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Id}'");


            //SE FOR TARIFA
            if (model.GetType() == typeof(Fare))
            {
                //TRAZER TODAS AS TARIFAS CADASTRADAS COM O OPERATORID = model
                // Uma "Fare" só pode ser cadastrada caso aquela operadora não possua nenhuma tarifa ativa (Fare.Status == 1) de mesmo valor dentro de um período de 6 meses
                // pegar a assinatura  = operador que tenha id = Operator id de um assinatura = Tarifa
                Fare fare = (Fare)model;

                var objOp = GetById<Operator>(fare.OperatorId);
                ///pega todas os operadores que tenham ligação com o operador ID
                var fares = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(Operator)) && fare.OperatorId == savedModel.Id).ToList();

                    

            }

            _fakeDatabase.Add(model);
        }

        public void Update(dynamic model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }

        public T GetById<T>(Guid id)
        {
            var model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return (T) model;
        }

        public List<T> GetAll<T>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T))).ToList();
            var convertedModels = allModels.Select(genericModel => (T)genericModel).ToList();
            return convertedModels;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        private Repository _repository;
        public FareService(Repository repository)
        {
            _repository = repository;
        }

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Guid fareId)
        {
            _repository.Update(fareId);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService;

        public FareController(Repository repository)
        {
            _operatorService = new OperatorService(repository);
            FareService = new FareService(repository);
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorId = selectedOperator.Id;
            fare.DataCadastro = DateTime.Today;


            //Teste para se estiver ativa nao deixar passar 
            //fare.Status = 1;
            //teste para se estiver ativo porem com mais de 6 meses 
            //fare.DataCadastro = Convert.ToDateTime("30/12/2020");
            


            FareService.Create(fare);
        }
    }
}

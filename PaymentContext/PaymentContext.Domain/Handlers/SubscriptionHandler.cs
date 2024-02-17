using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Flunt.Notifications;
using paymentcontext.Domain.Commands;
using paymentcontext.Domain.Entities;
using paymentcontext.Domain.Enums;
using paymentcontext.Domain.Service;
using paymentcontext.Domain.ValueObjects;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace paymentcontext.Domain.Handlers
{
    public class SubscriptionHandler :
            Notifiable,
            IHandler<CreateBoletoSubscriptionCommand>,
            IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailservice;
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailservice = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            // Verificar se o Documento já está cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se Email já está cadastrado
            if(_repository.EmailExists(command.Document))
                AddNotification("Email", "Este Email já está em uso");

            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
                
            //Gerar as Entidades
            var student = new Student(name, document, email);     
            var subscription = new Subscription(DateTime.Now.AddMonths(1));  
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Checar as informações
            if(Invalid)
                return new CommandResult(false, "Não foi possivel realizar a sua assinatura");

            //Salvar as informações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailservice.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao balta.io", "Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            // Verificar se o Documento já está cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se Email já está cadastrado
            if(_repository.EmailExists(command.Document))
                AddNotification("Email", "Este Email já está em uso");

            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
                
            //Gerar as Entidades
            var student = new Student(name, document, email);     
            var subscription = new Subscription(DateTime.Now.AddMonths(1));    
            //Handler igual o de boleto só foi alterado a forma de pagamento  
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Salvar as informações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailservice.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao balta.io", "Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
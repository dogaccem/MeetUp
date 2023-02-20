using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;
using MeetUp.Application.Abstractions;
using MeetUp.Application.Abstractions.UnitOfWork;

namespace MeetUp.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ISaveableCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var response = await next();
                    await _unitOfWork.Save(cancellationToken);
                    transactionScope.Complete();
                    return response;
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }

            
            
        }
    }
}

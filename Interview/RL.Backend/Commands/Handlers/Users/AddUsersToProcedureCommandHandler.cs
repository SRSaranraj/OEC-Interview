using MediatR;
using Microsoft.EntityFrameworkCore;
using RL.Backend.Exceptions;
using RL.Backend.Models;
using RL.Data;
using RL.Data.DataModels;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace RL.Backend.Commands.Handlers.Users
{
	public class AddUsersToProcedureCommandHandler : IRequestHandler<AddUsersToProcedureCommand, ApiResponse<int>>
	{
		private readonly RLContext _context;

		public AddUsersToProcedureCommandHandler(RLContext context)
		{
			_context = context;
		}
		public async Task<ApiResponse<int>> Handle(AddUsersToProcedureCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var usersList = _context.UserMapping.Where((u) => u.ProcedureId == request.Users[0].ProcedureId).ToList();
				_context.UserMapping.RemoveRange(usersList);
                await _context.SaveChangesAsync();

				for(int i = 0; i < request.Users.Count(); i++)
				{
                    _context.UserMapping.Add(new UserMapping
                    {
                        UserMappingId = i,
                        PlanId = request.Users[i].PlanId,
                        ProcedureId = request.Users[i].ProcedureId,
                        UserId = request.Users[i].UserId,
                        CreateDate = DateTime.Now.ToUniversalTime(),
                        UpdateDate = DateTime.Now.ToUniversalTime()
                    });
                }
					await _context.SaveChangesAsync();
					return ApiResponse<int>.Succeed(1);


			}
			catch (Exception e)
			{
				return ApiResponse<int>.Fail(e);
			}
		}
	}
}
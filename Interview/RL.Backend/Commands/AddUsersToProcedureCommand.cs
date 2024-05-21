using MediatR;
using RL.Backend.Models;

namespace RL.Backend.Commands
{
    public class AddUsersToProcedureCommand : IRequest<ApiResponse<int>>

    {
        public List<UsersDetails> Users { get; set; }
    }

    public class UsersDetails

    {
        public int PlanId { get; set; }
        public int ProcedureId { get; set; }
        public int UserId { get; set; }
    }
}
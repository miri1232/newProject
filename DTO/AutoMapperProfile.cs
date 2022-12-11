using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<BudgetDTO, Budget>();
            CreateMap<Budget, BudgetDTO>();
            CreateMap<ExpenseDTO, Expense>();
            CreateMap<Expense, ExpenseDTO>();
            CreateMap<IncomeDTO, Income>();
            CreateMap<Income, IncomeDTO>();
            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();
            CreateMap<MessagesForUserDTO, MessagesForUser>();
            CreateMap<MessagesForUser, MessagesForUserDTO>();
            CreateMap<NumberPaymentsDTO, NumberPayments>();
            CreateMap<NumberPayments, NumberPaymentsDTO>();
            CreateMap<BankDTO, Bank>();
            CreateMap<Bank, BankDTO>();
            CreateMap<BankOfBudgetDTO, BankOfBudget>();
            CreateMap<BankOfBudget, BankOfBudgetDTO>();
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<PermissionLevelDTO, PermissionLevel>();
            CreateMap<PermissionLevel, PermissionLevelDTO>();
        }

    }
   
}

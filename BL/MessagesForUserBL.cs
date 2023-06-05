using AutoMapper;
using DAL;
using Entities.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MessagesForUserBL : IMessagesForUserBL
    {
        private IMessagesForUserDAL _messagesForUserDAL;
        IMapper mapper;

        public MessagesForUserBL(IMessagesForUserDAL messagesForUserDAL)
        {
            _messagesForUserDAL = messagesForUserDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<MessagesForUserDTO> GetAllMessagesForUser()
        {
            List<MessagesForUser> messagesForUserList = _messagesForUserDAL.GetAllMessagesForUser();
            List<MessagesForUserDTO> listMessagesForUserDTO = mapper.Map<List<MessagesForUser>, List<MessagesForUserDTO>>(messagesForUserList);
            return listMessagesForUserDTO;
        }


        public bool AddMessagesForUser(MessagesForUserDTO messagesForUserDTO)
        {
            MessagesForUser currentMessagesForUser = mapper.Map<MessagesForUserDTO, MessagesForUser>(messagesForUserDTO);
            bool isSucsess = _messagesForUserDAL.AddMessagesForUser(currentMessagesForUser);
            return isSucsess;
        }

        public bool UpdateMessagesForUser(MessagesForUserDTO messagesForUserDTO)
        {
            MessagesForUser currentMessagesForUser = mapper.Map<MessagesForUserDTO, MessagesForUser>(messagesForUserDTO);
            bool isSucsess = _messagesForUserDAL.UpdateMessagesForUser(currentMessagesForUser.IdUser, currentMessagesForUser);
            return isSucsess;
        }

        public bool DeleteMessagesForUser(MessagesForUserDTO messagesForUserDTO)
        {
            string idToDelete = messagesForUserDTO.IdUser;
            bool isSucsess = _messagesForUserDAL.DeleteMessagesForUser(idToDelete);
            return isSucsess;
        }
    }
}

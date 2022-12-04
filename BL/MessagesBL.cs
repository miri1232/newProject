using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MessagesBL  : IMessagesBL
    {
        private IMessagesDAL _messagesDAL;
        IMapper mapper;

        public MessagesBL(IMessagesDAL messagesDAL)
        {
            _messagesDAL = messagesDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<MessagesDTO> GetAllMessages()
        {
            List<Messages> messagesList = _messagesDAL.GetAllMessages();
            List<MessagesDTO> listMessagesDTO = mapper.Map<List<Messages>, List<MessagesDTO>>(messagesList);
            return listMessagesDTO;
        }


        public bool AddMessages(MessagesDTO messagesDTO)
        {
            Messages currentMessages = mapper.Map<MessagesDTO, Messages>(messagesDTO);
            bool isSucsess = _messagesDAL.AddMessages(currentMessages);
            return isSucsess;
        }

        public bool UpdateMessages(MessagesDTO messagesDTO)
        {
            Messages currentMessages = mapper.Map<MessagesDTO, Messages>(messagesDTO);
            bool isSucsess = _messagesDAL.UpdateMessages(currentMessages.Id, currentMessages);
            return isSucsess;
        }

        public bool DeleteMessages(MessagesDTO messagesDTO)
        {
            int idToDelete = messagesDTO.Id;
            bool isSucsess = _messagesDAL.DeleteMessage(idToDelete);
            return isSucsess;
        }
    }
}

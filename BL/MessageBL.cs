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
    public class MessageBL  : IMessageBL
    {
        private IMessageDAL _messageDAL;
        IMapper mapper;

        public MessageBL(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<MessageDTO> GetAllMessages()
        {
            List<Message> messagesList = _messageDAL.GetAllMessages();
            List<MessageDTO> listMessagesDTO = mapper.Map<List<Message>, List<MessageDTO>>(messagesList);
            return listMessagesDTO;
        }


        public bool AddMessages(MessageDTO messageDTO)
        {
            Message currentMessages = mapper.Map<MessageDTO, Message>(messageDTO);
            bool isSucsess = _messageDAL.AddMessage(currentMessages);
            return isSucsess;
        }

        public bool UpdateMessages(MessageDTO messageDTO)
        {
            Message currentMessage = mapper.Map<MessageDTO, Message>(messageDTO);
            bool isSucsess = _messageDAL.UpdateMessage(currentMessage.Id, currentMessage);
            return isSucsess;
        }

        public bool DeleteMessage(MessageDTO messageDTO)
        {
            int idToDelete = messageDTO.Id;
            bool isSucsess = _messageDAL.DeleteMessage(idToDelete);
            return isSucsess;
        }
    }
}

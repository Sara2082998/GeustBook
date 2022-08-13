using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Guestbook.Models;
using Guestbook.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Guestbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        readonly IMessageRepository messageRepository;
        readonly IConfiguration configuration;
        public MessageController(IMessageRepository messageRepository, IConfiguration config)
        {
            this.messageRepository = messageRepository;
            configuration = config;


        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            List<Message> msgList = messageRepository.getAll();
            return Ok(msgList);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            Message msg = messageRepository.FindById(id);
            return Ok(msg);
        }
        [HttpPost]
        public IActionResult PostMessage(Message message)
        {
            try
            {
                var checkMassage = messageRepository.FindById(message.id);

                if (checkMassage != null) return Problem("the city name is already exist");

                var addMessage = messageRepository.Insert(message);
                return Ok(addMessage);
            }
            catch
            {
                return Problem("something went wrong");
            }
        }
            [HttpPut("{id:int}")]
            public IActionResult Update([FromRoute] int id, [FromBody] Message message)
            {
                if (ModelState.IsValid == true)
                {

                    messageRepository.Edit(id, message);
                    return Ok(message);


                }
                return BadRequest(ModelState);
            }
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            Message msg = messageRepository.FindById(id);
            if (msg != null)
            {
                try
                {
                    messageRepository.Delete(id);
                    return StatusCode(204, "Record Remove Success");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Id Not Found");


        }
    }

    }

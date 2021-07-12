using AutoMapper;
using Core.Utilities.Mail;
using Entity.Dto.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public HomeController(IMailService mailService,IMapper mapper)
        {
            _mailService = mailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost("contact")]
        public async Task<IActionResult> SendMessage(MailSenderDto mailSenderDto)
        {
            var mailRequest = _mapper.Map<MailRequest>(mailSenderDto);
            await _mailService.SendEmailAsync(mailRequest);
            return Ok("Mail Gonderildi...");
        }

    }
}

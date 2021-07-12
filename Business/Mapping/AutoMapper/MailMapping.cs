using AutoMapper;
using Core.Utilities.Mail;
using Entity.Dto.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class MailMapping : Profile
    {
        public MailMapping()
        {
            CreateMap<MailSenderDto, MailRequest>().ForMember(dest => dest.Body,
                opt => opt.MapFrom(src=> ($"Isim:  {src.Name} \n Email:  {src.SenderEmail}  \n Aciklama:  {src.Body}")))
                .ForMember(dest => dest.ToEmail, opt => opt.MapFrom(src => "olcanpindukcontact@gmail.com"));
        }
    }
}

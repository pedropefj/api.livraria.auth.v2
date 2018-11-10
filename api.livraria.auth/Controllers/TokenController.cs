using System;
using System.Net;
using System.Net.Http;
using api.livraria.auth.model.Interfaces.Business.Login;
using api.livraria.auth.model.Request;
using api.livraria.auth.model.Response;
using api.livraria.auth.model.Util;
using api.livraria.auth.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Examples;

namespace api.livraria.auth.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class TokenController : BaseController
    {
        private ILoginBusiness _loginBusiness;

        public TokenController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        //[AllowAnonymous]
        /// <summary>
        /// Recurso de autenticação.
        /// </summary>
        /// <response code="200">Autenticado</response>
        /// <response code="400">Usuário não encontrado."</response>
        /// <response code="401">"Ocorreu um erro na execução."</response>
        [HttpPost]

        [SwaggerResponseExample(200, typeof(TokenResponseModelExample), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(401, typeof(UsuarioResponse401), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerRequestExample(typeof(TokenRequest), typeof(TokenRequestModelExample), jsonConverter: typeof(StringEnumConverter))]
        [ProducesResponseType(200, Type = typeof(TokenResponse))]
        [ProducesResponseType(401, Type = typeof(MensagemError))]

        public HttpResponseMessage Post([FromBody]TokenRequest user)
        {

            try
            {

                return ResponseBasicJson(HttpStatusCode.OK,_loginBusiness.FindByLogin(user));

            }
            catch (ValidacaoException e)
            {
                return ResponseBasicJson(e.MensagemError.StatusCode, e.MensagemError);
            }
            catch (Exception e)
            {
                MensagemError msg = MensagensUtil.ObterMensagem(HttpStatusCode.BadRequest, "M199");
                return ResponseBasicJson(msg.StatusCode, msg);
            }
        }

        /// <summary>
        /// Validador de autenticação.
        /// </summary>
        /// <response code="200">Autenticado</response>
        /// <response code="401">"Sem autorização."</response>
        
        [HttpGet]
        
        [SwaggerResponseExample(200, typeof(TokenResponse200), jsonConverter: typeof(StringEnumConverter))]
        [ProducesResponseType(200, Type = typeof(MensagemError))]
        [ProducesResponseType(401, Type =null)]
        [Authorize("Bearer")]
        public HttpResponseMessage Get()
        {

            try
            {
                MensagemError msg = MensagensUtil.ObterMensagem(HttpStatusCode.OK, "M0007");
                return ResponseBasicJson(msg.StatusCode, msg);

            }
            catch (ValidacaoException e)
            {
                return ResponseBasicJson(e.MensagemError.StatusCode, e.MensagemError);
            }
            catch (Exception e)
            {
                MensagemError msg = MensagensUtil.ObterMensagem(HttpStatusCode.BadRequest, "M199");
                return ResponseBasicJson(msg.StatusCode, msg);
            }
        }
    }
}
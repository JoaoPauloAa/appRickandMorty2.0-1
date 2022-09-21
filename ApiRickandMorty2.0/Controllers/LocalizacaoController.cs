using ApiRickandMorty2._0.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRickandMorty2._0.Controllers
{
    public class LocalizacaoController : ApiController
    {
        // GET: Localizacao
        [HttpGet]
        public IEnumerable Get()
        {
            var localizacaoDAO = new LocalizacaoDAO();
            var localizacaolist = localizacaoDAO.SelectTodosLocalizacaos();
            return localizacaolist;
        }


        // GET: api/Localizacao/5
        [System.Web.Http.HttpGet]
        public Localizacao Get(int id)
        {
            var localizacaoDAO = new LocalizacaoDAO();
            var localizacao = localizacaoDAO.SelectLocalizacaoPeloId(id);
            return localizacao;
        }

        // POST: api/Localizacao
        [System.Web.Http.HttpPost]
        public void Post([FromBody] Localizacao localizacao)
        {
            if (localizacao == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var localizacaoDAO = new LocalizacaoDAO();
            localizacaoDAO.Insert(localizacao);
        }

        // PUT: api/Localizacao/5
        public void Put(int id, [FromBody] Localizacao localizacao)
        {
            if (localizacao == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var localizacaoDAO = new LocalizacaoDAO();
            localizacaoDAO.Update(localizacao);
        }

        // DELETE: api/Localizacao/5
        public Localizacao Delete(int id)
        {
            var localizacaoDAO = new LocalizacaoDAO();
            var localizacao = localizacaoDAO.SelectLocalizacaoPeloId(id);
            if (localizacao == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            localizacaoDAO.Delete(id);
            return localizacao;
        }
    }
}
